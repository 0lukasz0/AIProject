﻿using System;
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


        public ActionResult Browse(string category)
        {

            ViewBag.ReturnUrl = HttpContext.Request.RawUrl;
            var categoryModel = storeItemsDb.Categories.Include("Items")
                .Single(g => g.Name == category);

            return View(categoryModel);
        }

        public ActionResult Details(int id)
        {
            ViewBag.ReturnUrl = HttpContext.Request.RawUrl;
            var item = storeItemsDb.Items.Find(id);
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

            var categoryQuery = from d in storeItemsDb.Categories
                           orderby d.Name
                           select d.Name;

            categoryList.AddRange(categoryQuery.Distinct());
            ViewBag.itemCategory = new SelectList(categoryList);

            var items = from m in storeItemsDb.Items
                         select m;
            var it = items.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Title.Contains(searchString));
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
