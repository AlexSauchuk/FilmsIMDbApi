using System.Collections.Generic;

namespace FilmsManagement.Infrastructure.Http.DataModels
{
    public class SearchResultDataModel
    {
        public IEnumerable<MovieTitleDataModel> Results { get; set; }
    }
}
