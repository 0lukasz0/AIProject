using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.DataBase;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        //
        // GET: /Home/
        private List<Item> GetTopSellingItems(int count)
        {
            // Group the order details by item and return
            // the items with the highest count
            return storeItemsDb.Items
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(count)
                .ToList();
        }

        public ActionResult Index()
        {
            // Get most popular items
            var items = GetTopSellingItems(5);
            return View(items);
        }

    }
}
