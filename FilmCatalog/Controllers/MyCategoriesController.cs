using FilmCatalog.ApiModels;
using FilmCatalog.Models;
using FilmCatalog.Models.Presistant;
using FilmCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FilmCatalog.Controllers
{
    public class MyCategoriesController : ApiController
    {
        private FilmDbContext db = new FilmDbContext();

        //[HttpGet]
        public HttpResponseMessage GetCategoriesForFilm(int? FilmId)
        {
            List<FilmCategory> dbFilmCategories = db.FilmCategories.Where(x => x.FilmId == FilmId).ToList();
            
            List<FilmCategoryApiModel> lsFilmCategoryApiModels = new List<FilmCategoryApiModel>();
            
            foreach (FilmCategory dbFilmCategory in dbFilmCategories)
            {
                Category dbCategory = db.Categories.FirstOrDefault(x=>x.Id == dbFilmCategory.CategoryId);

                lsFilmCategoryApiModels.Add(new FilmCategoryApiModel
                {
                    CategoryId = dbFilmCategory.CategoryId,
                    CategoryName = dbCategory?.Name
                });

            }

            return Request.CreateResponse(HttpStatusCode.OK, lsFilmCategoryApiModels);
            
        }
    }
}

