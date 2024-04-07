namespace FilmCatalog.Migrations
{
    using FilmCatalog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FilmCatalog.Models.Presistant.FilmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.Presistant.FilmDbContext context)
        {
            
        }
    }
}
