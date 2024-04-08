using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmCatalog.Models
{
    public class FilmCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int CategoryId { get; set; } 
        public virtual Film Film { get; set; }
        public virtual Category Category { get; set; }
    }
}