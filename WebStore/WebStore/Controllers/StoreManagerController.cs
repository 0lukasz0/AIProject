using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.DataBase;

namespace WebStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StoreManagerController : Controller
    {
        private readonly StoreItemsEntities db = new StoreItemsEntities();

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var items = db.Items.Include(a => a.Category).Include(a => a.SubCategory);
            return View(items.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            Item item = db.Items.Find(id);
            return View(item);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            ViewBag.AuthorId = new SelectList(db.Authors, "SubCategoryId", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.AuthorId = new SelectList(db.Authors, "SubCategoryId", "Name", item.SubCategoryId);
            return View(item);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            Item item = db.Items.Find(id);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);
            ViewBag.AuthorId = new SelectList(db.Authors, "SubCategoryId", "Name", item.SubCategoryId);
            return View(item);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var model = db.Items.Where(i => i.ItemId == id).Single();

            if (ModelState.IsValid)
            {
                bool zm = TryUpdateModel(model, null, null, new[] {"Id"});


                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", model.CategoryId);
            ViewBag.AuthorId = new SelectList(db.Authors, "SubCategoryId", "Name", model.SubCategoryId);
            return View(model);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            Item item = db.Items.Find(id);
            ViewBag.Category = db.Categories.Find(item.CategoryId);
            ViewBag.Author = db.Authors.Find(item.SubCategoryId);
            return View(item);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}