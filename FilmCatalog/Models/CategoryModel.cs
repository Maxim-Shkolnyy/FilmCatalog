using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmCatalog.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }        
        public int? ParentCategoryId { get; set; }        
        public virtual ICollection<FilmCategory> FilmCategories { get; set; } = null;
    }
}
