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
    public class CategoriesController : Controller
    {
        private FilmDbContext db = new FilmDbContext();

        // GET: Categories
        public async Task<ActionResult> Index()
        {
            foreach (var category in db.Categories)
            {
                var categoryName = db.Categories
                            .Where(p => p.Id == category.ParentCategoryId)
                            .Select(p => p.Name)
                            .FirstOrDefault();

                var categoriesCount = db.FilmCategories.Count(fc => fc.CategoryId == category.Id);

                var nestingLevel = GetNestingLevel(category);

                var categoryViewModel = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentCategoryId = category.ParentCategoryId,
                    ParentCategoryName = categoryName,
                    FilmCount = categoriesCount,
                    NestingLevel = nestingLevel
                };
            }
            
            var categories = db.Categories.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                ParentCategoryId = c.ParentCategoryId,
                ParentCategoryName = db.Categories
                            .Where(p => p.Id == c.ParentCategoryId)
                            .Select(p => p.Name)
                            .FirstOrDefault(), 
                FilmCount = db.FilmCategories.Count(fc => fc.CategoryId == c.Id),
                NestingLevel = 
            }).ToListAsync();

            


            return View(await categories);


            



            //foreach (var category in categories)
            //{
            //    category.FilmCount = await db.FilmCategories.CountAsync(fc => fc.CategoryId == category.Id);
            //}

            //foreach (var category in categories)
            //{
            //    var categoryViewModel = new CategoryViewModel
            //    {
            //        Id = category.Id,
            //        Name = category.Name,
            //        ParentCategoryId = category.ParentCategoryId,
            //        FilmCount = category.FilmCount
            //    };
            //    categoryViewModel.NestingLevel = GetNestingLevel(categoryViewModel);
            //}

            //var viewModelList = categories.Select(c => new CategoryViewModel
            //{
            //    Id = c.Id,
            //    Name = c.Name,
            //    ParentCategoryId = c.ParentCategoryId,
            //    FilmCount = c.FilmCount,
            //    NestingLevel = c.NestingLevel
            //}).ToList();

            //return View(viewModelList);
        }

        private int GetNestingLevel(Category category)
        {
            int nestingLevel = 0;
            

            while (category.ParentCategory != null)
            {
                nestingLevel++;
                category = category.ParentCategory;
            }

            return nestingLevel;
        }



        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ParentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ParentCategoryId = new SelectList(db.Categories, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ParentCategoryId")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ParentCategoryId = new SelectList(db.Categories, "Id", "Name", category.ParentCategoryId);
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = await db.Categories.FindAsync(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category category = await db.Categories.FindAsync(id);
            db.Categories.Remove(category);
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
