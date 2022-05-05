using Newtonsoft.Json;

namespace FilmsManagement.Infrastructure.Http.DataModels
{
    public class MovieWikipediaDataModel
    {
        [JsonProperty("imDbId")]
        public string FilmId { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public PlotShort PlotShort { get; set; }
    }

    public class PlotShort
    {
        public string PlainText { get; set; }

        public string Html { get; set; }
    }
}
