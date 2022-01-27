﻿using Snap.Genshin.Website.Entities;
using Snap.Genshin.Website.Entities.Record;
using Snap.Genshin.Website.Models.Statistics;

namespace Snap.Genshin.Website.Services.StatisticCalculation
{
    public class AvatorParticipationCalculator : IStatisticCalculator
    {
        public AvatorParticipationCalculator(ApplicationDbContext dbContext, IStatisticsProvider statisticsProvider)
        {
            this.dbContext = dbContext;
            this.statisticsProvider = statisticsProvider;
        }

        private readonly ApplicationDbContext dbContext;
        private readonly IStatisticsProvider statisticsProvider;

        public async Task Calculate()
        {
            int count = dbContext.SpiralAbyssAvatars.Count();

            // 忽略九层以下数据
            IQueryable<IGrouping<int, SpiralAbyssAvatar>>? floorGroup = dbContext.SpiralAbyssAvatars
                .Where(avatar => avatar.SpiralAbyssBattle.AbyssLevel.FloorIndex >= 9)
                .GroupBy(avatar => avatar.SpiralAbyssBattle.AbyssLevel.FloorIndex);

            List<AvatarParticipation>? result = new();

            // 处理每层数据
            foreach (IGrouping<int, SpiralAbyssAvatar>? floor in floorGroup)
            {
                IEnumerable<IGrouping<int, SpiralAbyssAvatar>>? avatarGroups = floor
                    .AsEnumerable()
                    .GroupBy(avatar => avatar.AvatarId);

                IEnumerable<Rate<int>>? currentFloorData = avatarGroups
                    .Select(avararGroup => new Rate<int>
                    {
                        Id = avararGroup.Key,
                        Value = (double)avararGroup.Count() / count
                    });

                result.Add(new()
                {
                    Floor = floor.Key,
                    AvatarUsage = currentFloorData,
                });
            }

            await statisticsProvider.SaveStatistics<AvatorParticipationCalculator>(result);
        }
    }
}