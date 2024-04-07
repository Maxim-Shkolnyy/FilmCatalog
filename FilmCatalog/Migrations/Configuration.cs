namespace FilmCatalog.Migrations
{
    using FilmCatalog.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FilmCatalog.Models.Presistant.FilmDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.Presistant.FilmDbContext context)
        {
            //bool anyCategoriesExist = context.Categories.Any();

            //if (!anyCategoriesExist)
            //{
            //    context.Categories.AddOrUpdate(
            //        c => c.Id,
            //        new Category {Name = "RootCategory", ParentCategoryId = 0}
            //    );

            //    context.SaveChanges();
            //}
        }
    }
}
