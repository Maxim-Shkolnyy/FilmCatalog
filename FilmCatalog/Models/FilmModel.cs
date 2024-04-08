using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCatalog.Models
{
    public class FilmModel
    {
        public string Name { get; set; }
        public string Director { get; set; }        
        public DateTime ReleaseDate { get; set; }
        public virtual ICollection<FilmCategory> FilmCategories { get; set; } = null;
    }
}
