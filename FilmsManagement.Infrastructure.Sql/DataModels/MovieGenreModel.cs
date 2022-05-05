using System.Collections.Generic;

namespace FilmsManagement.Infrastructure.Sql.DataModels
{
    public class MovieGenreModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    
        public virtual ICollection<FilmModel> Films { get; set; }
    }
}
