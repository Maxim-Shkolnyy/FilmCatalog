using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FilmCatalog.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва категорії обов'язкова")]
        [StringLength(200, ErrorMessage = "Назва категорії повинна містити не більше 200 символів")]
        public string Name { get; set; }

        [ForeignKey("ParentCategory")]
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }

    }
}