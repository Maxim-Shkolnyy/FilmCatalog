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
    public class FilmCategoriesController : Controller
    {
        private FilmDbContext db = new FilmDbContext();

        // GET: FilmCategories
        public async Task<ActionResult> Index()
        {
            var filmCategories = db.FilmCategories.Include(f => f.Category).Include(f => f.Film);
            return View(await filmCategories.ToListAsync());
        }

        // GET: FilmCategories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmCategory filmCategory = await db.FilmCategories.FindAsync(id);
            if (filmCategory == null)
            {
                return HttpNotFound();
            }
            return View(filmCategory);
        }

        // GET: FilmCategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name");
            return View();
        }

        // POST: FilmCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FilmId,CategoryId")] FilmCategory filmCategory)
        {
            if (ModelState.IsValid)
            {
                db.FilmCategories.Add(filmCategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", filmCategory.CategoryId);
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", filmCategory.FilmId);
            return View(filmCategory);
        }

        // GET: FilmCategories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmCategory filmCategory = await db.FilmCategories.FindAsync(id);
            if (filmCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", filmCategory.CategoryId);
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", filmCategory.FilmId);
            return View(filmCategory);
        }

        // POST: FilmCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FilmId,CategoryId")] FilmCategory filmCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filmCategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", filmCategory.CategoryId);
            ViewBag.FilmId = new SelectList(db.Films, "Id", "Name", filmCategory.FilmId);
            return View(filmCategory);
        }

        // GET: FilmCategories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilmCategory filmCategory = await db.FilmCategories.FindAsync(id);
            if (filmCategory == null)
            {
                return HttpNotFound();
            }
            return View(filmCategory);
        }

        // POST: FilmCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FilmCategory filmCategory = await db.FilmCategories.FindAsync(id);
            db.FilmCategories.Remove(filmCategory);
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
