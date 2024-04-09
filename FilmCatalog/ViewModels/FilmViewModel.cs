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
    public class FilmViewModel
    {
        public int Id { get; set; }        
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<FilmCategory> FilmCategories { get; set; }
        public List<Category> Categories { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
