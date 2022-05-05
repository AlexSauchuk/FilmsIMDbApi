namespace FilmsManagement.Infrastructure.Sql.AdditionalStates
{
    public class TvSeriesAdditionalState : IAdditionalState
    {
        public int SeasonsCount { get; set; }

        public int SeriesCount { get; set; }
    }
}
