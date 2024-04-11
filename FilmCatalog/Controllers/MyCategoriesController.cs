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

        [HttpGet]
        //[Route("api/Controllers/MyCategories")]
        public HttpResponseMessage GetCategoriesForFilm(int? filmId)
        {
            List<FilmCategoryApiModel> lsFilmCategoryApiModels = new List<FilmCategoryApiModel>();
            
            Category[] dbCategories = db.Categories.ToArray();
            foreach (Category dbCategory in dbCategories)
            {
                bool bSelected = db.FilmCategories.Any(x => x.FilmId == filmId && x.CategoryId == dbCategory.Id);

                lsFilmCategoryApiModels.Add(new FilmCategoryApiModel
                {
                    CategoryId = dbCategory.Id,
                    CategoryName = dbCategory.Name,
                    Selected = bSelected
                });

            }

            return Request.CreateResponse(HttpStatusCode.OK, lsFilmCategoryApiModels);
            
        }

        [HttpPost]
        public HttpResponseMessage SetCategoriesForFilm([FromUri] int? filmId, [FromBody] List<FilmCategoryApiModel> lsModel)
        {
            db.FilmCategories.RemoveRange(db.FilmCategories.Where(x => x.FilmId == filmId));
            db.SaveChanges();

            foreach (FilmCategoryApiModel apiCategory in lsModel)
            {
                if (apiCategory.Selected)
                {
                    db.FilmCategories.Add(new FilmCategory { FilmId = filmId.Value, CategoryId = apiCategory.CategoryId });
                }
            }

            db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}

