using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.Cart;
using WebStore.Models.DataBase;
using WebStore.ViewModels;

namespace WebStore.Controllers
{

    public class ShoppingCartController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        //
        // GET: /ShoppingCart/
        [Authorize]
        public ActionResult Index(string returnUrl)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);



            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        //
        // GET: /Store/AddToCart/5
        [Authorize]
        public ActionResult AddToCart(int id)
        {
            var addedItem = storeItemsDb.Items
                .Single(item => item.ItemId == id);

            var cart = ShoppingCart.GetCart(this.HttpContext);

            cart.AddToCart(addedItem);
            addedItem.IsReserved = true;
            storeItemsDb.SaveChanges();

            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        [Authorize]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            var itemToDelete = storeItemsDb.Carts
                .Single(item => item.RecordId == id).Item;

            int itemCount = cart.RemoveFromCart(id);

            itemToDelete.IsReserved = false;
            storeItemsDb.SaveChanges();

            var results = new ShoppingCartRemoveViewModel
            {
                Message = itemToDelete.Title +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
           // ViewBag.CartCount = cart.GetCount();
            return PartialView("CartSummary");
        }

        public ActionResult MoveToWishList(int id)
        {
            var wishList = ShoppingWishList.GetWishList(this.HttpContext);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var item = storeItemsDb.Carts.Single(i => i.ItemId == id).Item;

            wishList.AddToWishList(item);
            cart.RemoveFromCart(cart.GetCartItems().Single(x => x.ItemId == id).RecordId);
            var dbItem = storeItemsDb.Items.Where(x => x.ItemId == id).Single();
            dbItem.IsReserved = false;
            storeItemsDb.SaveChanges();
            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
