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

namespace FilmCatalog.Controllers
{
    public class FilmsController : Controller
    {
        private FilmDbContext db = new FilmDbContext();

        // GET: Films
        public async Task<ActionResult> Index()
        {
            return View(await db.Films.ToListAsync());
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
                    new Film { Name = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseDate = new DateTime(1994, 9, 22), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 1, CategoryId = 1 } } },
                    new Film { Name = "The Godfather", Director = "Francis Ford Coppola", ReleaseDate = new DateTime(1972, 3, 24), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 2, CategoryId = 2 } } },
                    new Film { Name = "The Dark Knight", Director = "Christopher Nolan", ReleaseDate = new DateTime(2008, 7, 18), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 3, CategoryId = 3 } } },
                    new Film { Name = "12 Angry Men", Director = "Sidney Lumet", ReleaseDate = new DateTime(1957, 4, 10), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 4, CategoryId = 4 } } },
                    new Film { Name = "Schindler's List", Director = "Steven Spielberg", ReleaseDate = new DateTime(1993, 12, 15), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 5, CategoryId = 5 } } },
                    new Film { Name = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseDate = new DateTime(1994, 10, 14), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 6, CategoryId = 6 } } },
                    new Film { Name = "The Lord of the Rings: The Return of the King", Director = "Peter Jackson", ReleaseDate = new DateTime(2003, 12, 17), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 7, CategoryId = 7 } } },
                    new Film { Name = "The Good, the Bad and the Ugly", Director = "Sergio Leone", ReleaseDate = new DateTime(1966, 12, 23), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 8, CategoryId = 8 } } },
                    new Film { Name = "Fight Club", Director = "David Fincher", ReleaseDate = new DateTime(1999, 10, 15), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 9, CategoryId = 9 } } },
                    new Film { Name = "Forrest Gump", Director = "Robert Zemeckis", ReleaseDate = new DateTime(1994, 7, 6), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 10, CategoryId = 10 } } },
                    new Film { Name = "Inception", Director = "Christopher Nolan", ReleaseDate = new DateTime(2010, 7, 16), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 11, CategoryId = 11 } } },
                    new Film { Name = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", ReleaseDate = new DateTime(1999, 3, 31), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 12, CategoryId = 12 } } },
                    new Film { Name = "Goodfellas", Director = "Martin Scorsese", ReleaseDate = new DateTime(1990, 9, 19), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 13, CategoryId = 13 } } },
                    new Film { Name = "The Silence of the Lambs", Director = "Jonathan Demme", ReleaseDate = new DateTime(1991, 2, 14), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 14, CategoryId = 14 } } },
                    new Film { Name = "Star Wars: Episode V - The Empire Strikes Back", Director = "Irvin Kershner", ReleaseDate = new DateTime(1980, 5, 21), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 15, CategoryId = 15 } } },
                    new Film { Name = "Se7en", Director = "David Fincher", ReleaseDate = new DateTime(1995, 9, 22), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 16, CategoryId = 1 } } },
                    new Film { Name = "It's a Wonderful Life", Director = "Frank Capra", ReleaseDate = new DateTime(1946, 1, 7), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 17, CategoryId = 2 } } },
                    new Film { Name = "The Usual Suspects", Director = "Bryan Singer", ReleaseDate = new DateTime(1995, 8, 16), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 18, CategoryId = 3 } } },
                    new Film { Name = "Léon: The Professional", Director = "Luc Besson", ReleaseDate = new DateTime(1994, 11, 18), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 19, CategoryId = 4 } } },
                    new Film { Name = "Saving Private Ryan", Director = "Steven Spielberg", ReleaseDate = new DateTime(1998, 7, 24), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 20, CategoryId = 5 } } },
                    new Film { Name = "City of God", Director = "Fernando Meirelles, Kátia Lund", ReleaseDate = new DateTime(2002, 2, 5), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 21, CategoryId = 6 } } },
                    new Film { Name = "Interstellar", Director = "Christopher Nolan", ReleaseDate = new DateTime(2014, 11, 7), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 22, CategoryId = 7 } } },
                    new Film { Name = "The Green Mile", Director = "Frank Darabont", ReleaseDate = new DateTime(1999, 12, 10), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 23, CategoryId = 8 } } },
                    new Film { Name = "The Intouchables", Director = "Olivier Nakache, Éric Toledano", ReleaseDate = new DateTime(2011, 11, 2), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 24, CategoryId = 9 } } },
                    new Film { Name = "The Prestige", Director = "Christopher Nolan", ReleaseDate = new DateTime(2006, 10, 20), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 25, CategoryId = 10 } } },
                    new Film { Name = "Gladiator", Director = "Ridley Scott", ReleaseDate = new DateTime(2000, 5, 1), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 26, CategoryId = 11 } } },
                    new Film { Name = "American History X", Director = "Tony Kaye", ReleaseDate = new DateTime(1998, 10, 30), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 27, CategoryId = 12 } } },
                    new Film { Name = "The Lion King", Director = "Roger Allers, Rob Minkoff", ReleaseDate = new DateTime(1994, 6, 24), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 28, CategoryId = 13 } } },
                    new Film { Name = "Back to the Future", Director = "Robert Zemeckis", ReleaseDate = new DateTime(1985, 7, 3), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 29, CategoryId = 14 } } },
                    new Film { Name = "The Departed", Director = "Martin Scorsese", ReleaseDate = new DateTime(2006, 10, 6), FilmCategories = new List<FilmCategory> { new FilmCategory { FilmId = 30, CategoryId = 15 } } }
                };

                db.Films.AddRange(filmsList);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Director,ReleaseDate,FilmCategories")] Film film, int[] selectedCategories)
        {
            if (ModelState.IsValid)
            {
                if (selectedCategories != null)
                {
                    film.FilmCategories = new List<FilmCategory>();
                    foreach (var categoryId in selectedCategories)
                    {
                        var category = db.Categories.Find(categoryId);
                        if (category != null)
                        {
                            film.FilmCategories.Add(new FilmCategory { CategoryId = categoryId });
                        }
                    }
                }

                db.Films.Add(film);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
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
