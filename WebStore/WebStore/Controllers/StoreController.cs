﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.Cart;
using WebStore.Models.DataBase;

namespace WebStore.Controllers
{
    public class StoreController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();


        public ActionResult Browse(string category)
        {

            ViewBag.ReturnUrl = HttpContext.Request.RawUrl;

            var categoryModel = storeItemsDb.Categories.Include("Items")
                .SingleOrDefault(g => g.Name == category);

            return categoryModel==null ? View("Error") : View(categoryModel);
        }

        public ActionResult Details(int id)
        {
            ShoppingCart.TimeExpiresCheck();
            ViewBag.ReturnUrl = HttpContext.Request.RawUrl;
            var item = storeItemsDb.Items.Find(id);

            if (item == null) return View("Error");

            ViewBag.IsReserved = item.IsReserved;
            return View(item);
        }

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = storeItemsDb.Categories.ToList();
            return PartialView(categories);
        }

        public ActionResult Index(string itemCategory, string searchString)
        {
            var categoryList = new List<string>();

            var categoryQuery = storeItemsDb.Categories.OrderBy(d => d.Name).Distinct().Select(d => d.Name);

            categoryList.AddRange(categoryQuery);
            ViewBag.itemCategory = new SelectList(categoryList);

            var items = storeItemsDb.Items.Select(m => m).ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Title.ToLowerInvariant().Contains(searchString.ToLowerInvariant()) ).ToList();
               // items.Where(s => s.Title.Contains())
            }

            if (string.IsNullOrEmpty(itemCategory))
            {
                return View(items);
            }
            else
            {
                return View(items.Where(x => x.Category.Name == itemCategory));
            }

        }


    }
}
