using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FilmCatalog.Models;
using FilmCatalog.Models.Presistant;
using FilmCatalog.ViewModels;

namespace FilmCatalog.Controllers
{
    public class FilmsController : Controller
    {
        private FilmDbContext db = new FilmDbContext();

        // GET: Films
        public async Task<ActionResult> Index()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");

            List<FilmViewModel> films = db.Films
                   .Select(f => new FilmViewModel
                   {
                       Id = f.Id,
                       Name = f.Name,
                       Director = f.Director,
                       ReleaseDate = f.ReleaseDate,
                       FilmCategories = db.FilmCategories
                           .Where(fc => fc.FilmId == f.Id)
                           .ToList()
                   })
                   .ToList();


            return View(films);
        }

        public ActionResult FillTable()
        {
            if (db.Films.Count() > 2)
            {
                ViewBag.Message = "Таблиця вже заповнена!";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                var categoriesList = new List<Category>()
                {
                    new Category { Name = "Root category", ParentCategoryId = null },
                    new Category { Name = "Драма", ParentCategoryId = 1 },
                    new Category { Name = "Комедія", ParentCategoryId = 1 },
                    new Category { Name = "Жахи", ParentCategoryId = 1 },
                    new Category { Name = "Романтика", ParentCategoryId = 1 },
                    new Category { Name = "Триллер", ParentCategoryId = 1 },
                    new Category { Name = "Детектив", ParentCategoryId = 1 },
                    new Category { Name = "Фантастика", ParentCategoryId = 1 },
                    new Category { Name = "Бойовик", ParentCategoryId = 1 },
                    new Category { Name = "Кримінальна драма", ParentCategoryId = 1 },
                    new Category { Name = "Фентезі", ParentCategoryId = 1 },
                    new Category { Name = "Містика", ParentCategoryId = 1 },
                    new Category { Name = "Психологічний триллер", ParentCategoryId = 1 },
                    new Category { Name = "Історичний", ParentCategoryId = 1 },
                    new Category { Name = "Екшн", ParentCategoryId = 1 },
                    new Category { Name = "Біографічний", ParentCategoryId = 1 },
                };

                db.Categories.AddRange(categoriesList);
                db.SaveChanges();

                var filmsList = new List<Film>()
                {
                    new Film { Name = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseDate = new DateTime(1994, 9, 22) },
                    new Film { Name = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = new DateTime(1972, 3, 24) },
                    new Film { Name = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = new DateTime(2008, 7, 18) },
                    new Film { Name = "12 Angry Men", Director = "Sidney Lumet", ReleaseDate = new DateTime(1957, 4, 10) },
                    new Film { Name = "Schindler's List", Director = "Steven Spielberg", ReleaseDate = new DateTime(1993, 12, 15) },
                    new Film { Name = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseDate = new DateTime(1994, 10, 14) },
                    new Film { Name = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", ReleaseDate = new DateTime(2003, 12, 17) },
                    new Film { Name = "The Good, the Bad and the Ugly", Director = "Sergio Leone", ReleaseDate = new DateTime(1966, 12, 23) },
                    new Film { Name = "Fight Club", Director = "David Fincher", ReleaseDate = new DateTime(1999, 10, 15) },
                    new Film { Name = "Forrest Gump", Director = "Robert Zemeckis", ReleaseDate = new DateTime(1994, 7, 6) },
                    new Film { Name = "Inception", Director = "Christopher Nolan", ReleaseDate = new DateTime(2010, 7, 16) },
                    new Film { Name = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", ReleaseDate = new DateTime(1999, 3, 31) },
                    new Film { Name = "Goodfellas", Director = "Martin Scorsese", ReleaseDate = new DateTime(1990, 9, 19) },
                    new Film { Name = "The Silence of the Lambs", Director = "Jonathan Demme", ReleaseDate = new DateTime(1991, 2, 14) },
                    new Film { Name = "Star Wars: Episode V - The Empire Strikes Back", Director = "Irvin Kershner", ReleaseDate = new DateTime(1980, 5, 21) },
                    new Film { Name = "Se7en", Director = "David Fincher", ReleaseDate = new DateTime(1995, 9, 22) },
                    new Film { Name = "It's a Wonderful Life", Director = "Frank Capra", ReleaseDate = new DateTime(1946, 1, 7) },
                    new Film { Name = "The Usual Suspects", Director = "Bryan Singer", ReleaseDate = new DateTime(1995, 8, 16) },
                    new Film { Name = "Léon: The Professional", Director = "Luc Besson", ReleaseDate = new DateTime(1994, 11, 18) },
                    new Film { Name = "Saving Private Ryan", Director = "Steven Spielberg", ReleaseDate = new DateTime(1998, 7, 24) },
                    new Film { Name = "City of God", Director = "Fernando Meirelles, Kátia Lund", ReleaseDate = new DateTime(2002, 2, 5) },
                    new Film { Name = "Interstellar", Director = "Christopher Nolan", ReleaseDate = new DateTime(2014, 11, 7) },
                    new Film { Name = "The Green Mile", Director = "Frank Darabont", ReleaseDate = new DateTime(1999, 12, 10) },
                    new Film { Name = "The Intouchables", Director = "Olivier Nakache, Éric Toledano", ReleaseDate = new DateTime(2011, 11, 2) },
                    new Film { Name = "The Prestige", Director = "Christopher Nolan", ReleaseDate = new DateTime(2006, 10, 20) },
                    new Film { Name = "Gladiator", Director = "Ridley Scott", ReleaseDate = new DateTime(2000, 5, 1) },
                    new Film { Name = "American History X", Director = "Tony Kaye", ReleaseDate = new DateTime(1998, 10, 30) },
                    new Film { Name = "The Lion King", Director = "Roger Allers, Rob Minkoff", ReleaseDate = new DateTime(1994, 6, 24) },
                    new Film { Name = "Back to the Future", Director = "Robert Zemeckis", ReleaseDate = new DateTime(1985, 7, 3) },
                    new Film { Name = "The Departed", Director = "Martin Scorsese", ReleaseDate = new DateTime(2006, 10, 6) }
                };

                db.Films.AddRange(filmsList);
                db.SaveChanges();

                var filmCategoriesList = new List<FilmCategory>()
                {
                    new FilmCategory { FilmId= filmsList[0].Id, CategoryId = categoriesList[2].Id },
                    new FilmCategory { FilmId= filmsList[0].Id, CategoryId = categoriesList[5].Id },
                    new FilmCategory { FilmId= filmsList[1].Id, CategoryId = categoriesList[8].Id },
                    new FilmCategory { FilmId= filmsList[1].Id, CategoryId = categoriesList[9].Id },
                    new FilmCategory { FilmId= filmsList[1].Id, CategoryId = categoriesList[11].Id },
                    new FilmCategory { FilmId= filmsList[2].Id, CategoryId = categoriesList[2].Id },
                    new FilmCategory { FilmId= filmsList[3].Id, CategoryId = categoriesList[3].Id },
                    new FilmCategory { FilmId= filmsList[4].Id, CategoryId = categoriesList[4].Id },
                    new FilmCategory { FilmId= filmsList[5].Id, CategoryId = categoriesList[5].Id },
                    new FilmCategory { FilmId= filmsList[6].Id, CategoryId = categoriesList[6].Id },
                    new FilmCategory { FilmId= filmsList[7].Id, CategoryId = categoriesList[7].Id },
                    new FilmCategory { FilmId= filmsList[8].Id, CategoryId = categoriesList[8].Id },
                    new FilmCategory { FilmId= filmsList[9].Id, CategoryId = categoriesList[9].Id },
                    new FilmCategory { FilmId= filmsList[10].Id, CategoryId = categoriesList[10].Id },
                    new FilmCategory { FilmId= filmsList[11].Id, CategoryId = categoriesList[11].Id },
                    new FilmCategory { FilmId= filmsList[12].Id, CategoryId = categoriesList[12].Id },
                    new FilmCategory { FilmId= filmsList[13].Id, CategoryId = categoriesList[13].Id },
                    new FilmCategory { FilmId= filmsList[14].Id, CategoryId = categoriesList[14].Id },
                    new FilmCategory { FilmId= filmsList[15].Id, CategoryId = categoriesList[1].Id },
                    new FilmCategory { FilmId= filmsList[16].Id, CategoryId = categoriesList[2].Id },
                    new FilmCategory { FilmId= filmsList[17].Id, CategoryId = categoriesList[3].Id },
                    new FilmCategory { FilmId= filmsList[18].Id, CategoryId = categoriesList[4].Id },
                    new FilmCategory { FilmId= filmsList[19].Id, CategoryId = categoriesList[5].Id }
                };
                db.FilmCategories.AddRange(filmCategoriesList);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // GET: Films/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Director,ReleaseDate,FilmCategories")] Film film, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                if (selectedCategories != null)
                {   
                    if (film != null)
                    {
                        db.Films.Add(film);
                    }
                    db.SaveChanges();                    

                    foreach (var categoryId in selectedCategories)
                    {
                        db.FilmCategories.Add(new FilmCategory {FilmId = film.Id, CategoryId = categoryId });
                    }
                }
                
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Director,ReleaseDate")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = await db.Films.FindAsync(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Film film = await db.Films.FindAsync(id);
            db.Films.Remove(film);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
