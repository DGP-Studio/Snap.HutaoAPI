// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Snap.Genshin.Website;
using Snap.Genshin.Website.Configurations;
using Snap.Genshin.Website.Entities;
using Snap.Genshin.Website.Models.Utility;
using Snap.Genshin.Website.Services;
using Snap.Genshin.Website.Services.StatisticCalculation;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.ExitOnWrongEnvironment();

var services = builder.Services;

services.AddControllers()
    .Services
    .AddMemoryCache()
    .AddDbContext<ApplicationDbContext>(optionBuilder =>
    {
        var dbType = builder.Environment.IsDevelopment() ? "LocalDb" : "ProductDb";
        var connectionString = builder.Configuration.GetConnectionString(dbType);

        optionBuilder
            .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            .ConfigureWarnings(b => b.Log(
                (RelationalEventId.CommandExecuted, LogLevel.Debug),
                (CoreEventId.ContextInitialized, LogLevel.Debug)));
    })
    .AddScoped<IStatisticsProvider, StatisticsProvider>()
    .AddGenshinStatisticsService(config =>
        config
            .AddCalculator<OverviewDataCalculator>()
            .AddCalculator<AvatorParticipationCalculator>()
            .AddCalculator<TeamCollocationCalculator>()
            .AddCalculator<WeaponUsageCalculator>()
            .AddCalculator<AvatarReliquaryUsageCalculator>()
            .AddCalculator<ActivedConstellationNumCalculator>()
            .AddCalculator<TeamCombinationCalculator>())
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtConfig = builder.Configuration.GetSection("Jwt");
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromSeconds(30),
            ValidateIssuerSigningKey = true,
            ValidAudience = jwtConfig.GetValue<string>("Audience"),
            ValidIssuer = jwtConfig.GetValue<string>("Issuer"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.GetValue<string>("SecurityKey"))),
        };
    })
    .Services

    .AddUserSecretManager(options =>
    {
        var config = builder.Configuration.GetSection("UserSecret");
        options.SymmetricKey = config.GetValue<string>("SymmetricKey");
        options.SymmetricSalt = config.GetValue<string>("SymmetricSalt");
        options.HashSalt = config.GetValue<string>("HashSalt");
    })

    // TODO 此为测试用服务
    .AddScoped<IMailService, TestMailSender>()

    // 鉴权策略
    .AddAuthorization(options =>
    {
        options.AddPolicy(IdentityPolicyNames.CommonUser, policy =>
        {
            policy.RequireClaim(ClaimTypes.NameIdentifier);
            policy.RequireClaim("TokenType", "AccessToken");
        });
        options.AddPolicy(IdentityPolicyNames.Administrator, policy =>
        {
            policy.RequireClaim(ClaimTypes.NameIdentifier);
            policy.RequireClaim("Administrator", "sg-admin");
        });
        options.AddPolicy(IdentityPolicyNames.RefreshTokenOnly, policy =>
        {
            policy.RequireClaim(ClaimTypes.NameIdentifier);
            policy.RequireClaim("TokenType", "RefreshToken");
        });
    })
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new()
        {
            Version = "1.0.0.0",
            Title = "记录交互",
            Description = "提交记录，查询提交状态",
        });
        c.SwaggerDoc("v2", new()
        {
            Version = "1.0.0.0",
            Title = "数据详情",
            Description = "获取详细的纵深数据",
        });
        c.SwaggerDoc("v3", new()
        {
            Version = "1.0.0.0",
            Title = "物品信息",
            Description = "提交与获取物品Id映射",
        });

        // We only have one executable file so it's fine.
        var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        c.IncludeXmlComments(xmlPath);
    });

var app = builder.Build();

app
    .UseSwagger()
    .UseSwaggerUI(option =>
    {
        option.SwaggerEndpoint("/swagger/v1/swagger.json", "记录交互 API");
        option.SwaggerEndpoint("/swagger/v2/swagger.json", "数据详情 API");
        option.SwaggerEndpoint("/swagger/v3/swagger.json", "物品信息 API");
    });

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();