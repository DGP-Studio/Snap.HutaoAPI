using Snap.Genshin.Website.Entities;
using Snap.Genshin.Website.Models.Statistics;

namespace Snap.Genshin.Website.Services.StatisticCalculation
{
    public class OverviewDataCalculator : IStatisticCalculator
    {
        public OverviewDataCalculator(ApplicationDbContext dbContext, IStatisticsProvider statisticsProvider)
        {
            this.dbContext = dbContext;
            this.statisticsProvider = statisticsProvider;
        }

        private readonly ApplicationDbContext dbContext;
        private readonly IStatisticsProvider statisticsProvider;

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

            await statisticsProvider.SaveStatistics<OverviewDataCalculator>(new OverviewData
            {
                CollectedPlayerCount = collectedPlayerCount,
                TotalPlayerCount = totalPlayerCount,
                FullStarPlayerCount = fullStarPassedPlayerCount,
            });
        }
    }
}
