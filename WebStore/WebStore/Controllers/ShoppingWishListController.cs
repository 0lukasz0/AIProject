using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.Cart;
using WebStore.Models.DataBase;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class ShoppingWishListController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();

        [Authorize]
        public ActionResult Index()
        {
            var wishList = ShoppingWishList.GetWishList(this.HttpContext);

            var viewModel = new ShoppingWishListViewModel
            {
                WishListItems = wishList.GetWishListItems(),
                WishListTotal = wishList.GetTotal()
            };
            return PartialView(viewModel);
        }

        [Authorize]
        public ActionResult AddToWishList(int id)
        {
            var addedItem = storeItemsDb.Items
                .Single(item => item.ItemId == id);

            var wishList = ShoppingWishList.GetWishList(this.HttpContext);

            wishList.AddToWishList(addedItem);

            return RedirectToAction("Index", "ShoppingCart");
        }

        [Authorize]
        [HttpPost]
        public ActionResult RemoveFromWishList(int id)
        {
            var wishList = ShoppingWishList.GetWishList(this.HttpContext);
            string itemName = storeItemsDb.WishLists
                .Single(item => item.RecordId == id).Item.Title;
            
            int itemCount = wishList.RemoveFromWishList(id);

            var results = new ShoppingWishListRemoveViewModel
            {
                Message = itemName +
                    " has been removed from your wish list.",
                WishListTotal = wishList.GetTotal(),
                WishListCount = wishList.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }


        [ChildActionOnly]
        public ActionResult WishListSummary()
        {
            var wishList = ShoppingWishList.GetWishList(this.HttpContext);

            ViewBag.WishListCount = wishList.GetCount();
            return PartialView("WishListSummary");
        }

    }
}
