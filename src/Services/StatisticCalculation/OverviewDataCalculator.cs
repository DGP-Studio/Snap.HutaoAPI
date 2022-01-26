﻿using Snap.Genshin.Website.Entities;
using Snap.Genshin.Website.Models.Statistics;
using System.Text.Json;

namespace Snap.Genshin.Website.Services.StatisticCalculation
{
    public class OverviewDataCalculator : IStatisticCalculator
    {
        public OverviewDataCalculator(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private readonly ApplicationDbContext dbContext;

        public async Task Calculate()
        {
            // 所有玩家数量
            int totalPlayerCount = dbContext.Players.Count();
            // 当期深渊数据量
            int collectedPlayerCount = dbContext.PlayerRecords.Count();
            // 满星玩家
            IQueryable<Guid>? floor12thPassedWithFullStarPlayers =
                (from record in dbContext.SpiralAbyssLevels
                where record.FloorIndex == 12
                where record.Star == 3
                select record.Record.PlayerId).Distinct();
            int fullStarPassedPlayerCount = floor12thPassedWithFullStarPlayers.Count();

            // 新增或修改当期数据
            int periodId = IStatisticCalculator.GetSpiralPeriodId(DateTime.Now);
            Statistics? data = dbContext.Statistics
                .Where(s => s.Source == nameof(OverviewDataCalculator))
                .Where(s => s.Period == periodId)
                .SingleOrDefault();

            if (data is null)
            {
                data = new();
                dbContext.Statistics.Add(data);
            }

            data.Period = periodId;
            data.Source = nameof(OverviewDataCalculator);
            data.Value = JsonSerializer.Serialize(new OverviewData
            {
                CollectedPlayerCount = collectedPlayerCount,
                TotalPlayerCount = totalPlayerCount,
                FullStarPlayerCount = fullStarPassedPlayerCount
            });

            await dbContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}