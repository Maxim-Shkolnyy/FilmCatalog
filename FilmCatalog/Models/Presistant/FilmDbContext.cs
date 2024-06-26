﻿using System.Data.Entity;

namespace FilmCatalog.Models.Presistant
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext() : base("MyConnectionString")
        {
            //var categoryWithId1 = Categories.FirstOrDefault(c => c.Id == 1);

            //if (categoryWithId1 == null)
            //{
            //    Categories.Add(new Category { Id = 1, Name = "Root Category" });
            //    SaveChanges();
            //}
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }

        //public class DbContextInitializer : DropCreateDatabaseIfModelChanges<FilmDbContext>
        //{
        //    protected override void Seed(FilmDbContext context)
        //    {
        //        var categoryWithId1 = context.Categories.FirstOrDefault(c => c.Id == 1);

        //        if (categoryWithId1 == null)
        //        {
        //            context.Categories.Add(new Category { Id = 1, Name = "Root Category" });
        //            context.SaveChanges();
        //        }

        //        base.Seed(context);
        //    }
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //Database.SetInitializer(new DbContextInitializer());

        //    modelBuilder.Entity<FilmCategory>()
        //        .HasKey(fc => fc.Id);
        //    Property(fc => fc.FilmId).IsRequired();
        //    Property(fc => fc.CategoryId).IsRequired();
        //}
    }
}