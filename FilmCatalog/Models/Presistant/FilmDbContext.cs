using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FilmCatalog.Models.Presistant
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("MyConnectionString")
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
    }
}