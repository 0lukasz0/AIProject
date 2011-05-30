using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models;
using WebStore.Models.Cart;
using WebStore.Models.DataBase;

namespace WebStore.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        //
        // GET: /Checkout/

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                var cart = ShoppingCart.GetCart(this.HttpContext);
                var test = cart.GetCartItems().Select(x=> x.Item).ToList();

                foreach (var item in test)
                {
                    var toDelete = storeItemsDb.Items.Where(x => x.ItemId == item.ItemId).Single();
                    storeItemsDb.Items.Remove(toDelete);
                }

                storeItemsDb.SaveChanges();
                return RedirectToAction("Complete");
            }
            catch
            {
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete()
        {
                return View();
        }
    }
}
