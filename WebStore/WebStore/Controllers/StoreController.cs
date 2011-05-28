using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.DataBase;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        //
        // GET: /Store/

        public ActionResult Index()
        {
            var categories = storeItemsDb.Categories.ToList();
            return View(categories);
        }

        //
        // GET: /Store/Browse

        public ActionResult Browse(string category)
        {
            // Retrieve Category and its Associated Items from database
            var categoryModel = storeItemsDb.Categories.Include("Items")
                .Single(g => g.Name == category);

            return View(categoryModel);
        }

        //
        // GET: /Store/Details

        public ActionResult Details(int id)
        {
            var item = storeItemsDb.Items.Find(id);
            return View(item);
        }
        //
        // GET: /Store/CategoryMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeItemsDb.Categories.ToList();
            return PartialView(categories);
        }
    }
}
