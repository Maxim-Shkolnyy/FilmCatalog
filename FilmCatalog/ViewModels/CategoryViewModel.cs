using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmCatalog.Models;

namespace FilmCatalog.ViewModels
{
    public class CategoryViewModel
    {   public int Id { get; set; }        
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        List<FilmCategory> FilmCategories { get; set; }
        public int FilmCount { get; set; } 
        public int NestingLevel { get; set; }
        public virtual CategoryViewModel ParentCategory { get; set; }
    }
}
