﻿using FilmCatalog.Models;
using FilmCatalog.Models.Presistant;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity.Migrations;
using System.Web.Http;

namespace FilmCatalog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);            
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<FilmDbContext, Configuration>());

            FilmDbContext context = new FilmDbContext();

            bool anyCategoriesExist;
            bool rootCategoryExist;

            try
            {
                anyCategoriesExist = context.Categories.Any();
                rootCategoryExist = context.Categories.Where(m => m.Id == 1).Any();

                if (!anyCategoriesExist  & !rootCategoryExist)
                {
                    context.Categories.AddOrUpdate(
                        c => c.Id,
                        new Category { Name = "RootCategory", ParentCategoryId = 0 }
                    );

                    context.SaveChanges();
                }


                var rootCategory = context.Categories.FirstOrDefault(c => c.Id == 1);
                if (anyCategoriesExist && rootCategory == null)
                {
                    context.Categories.Add(new Category {Name = "RootCategory", ParentCategoryId = 0 });
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                Debug.WriteLine("Root category does not created!!!");
            }

            
            
        }
    }
}
