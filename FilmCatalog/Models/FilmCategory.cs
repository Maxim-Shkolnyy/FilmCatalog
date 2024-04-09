using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FilmCatalog.Models
{
    public class FilmCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Index("IX_FilmCategory", 1, IsUnique = true)]
        public int FilmId { get; set; }
        [Index("IX_FilmCategory", 2, IsUnique = true)]
        public int CategoryId { get; set;}       
    }
}