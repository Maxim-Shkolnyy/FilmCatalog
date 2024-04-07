using FilmCatalog.Migrations;
using FilmCatalog.Models;
using FilmCatalog.Models.Presistant;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity.Migrations;
using FilmCatalog.Models;

namespace FilmCatalog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //FilmDbContext context = new FilmDbContext();
            
            //bool anyCategoriesExist = context.Categories.Any();
            //bool rootCategoryExist = context.Categories.Where(m => m.Id == 1).Any();
            //var isCategoriesTableExists = context.Database.ExecuteSqlCommand(
            //    "SELECT CASE WHEN EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Categories')" +
            //    " THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS TableExists;");

            //Debug.WriteLine(isCategoriesTableExists);



            //if (isCategoriesTableExists > 0 & !rootCategoryExist)
            //{
            //    context.Categories.AddOrUpdate(
            //        c => c.Id,
            //        new Category { Name = "RootCategory", ParentCategoryId = 0 }
            //    );

            //    context.SaveChanges();
            //}

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmDbContext, Configuration>());
        }
    }
}
