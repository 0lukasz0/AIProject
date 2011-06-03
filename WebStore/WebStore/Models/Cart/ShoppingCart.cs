using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.DataBase;

namespace WebStore.Models.Cart
{
    public class ShoppingCart
    {
        public static readonly TimeSpan MaxTimeInBasket = TimeSpan.FromSeconds(30);

        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        string ShoppingCartId { get; set; }
   
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public void AddToCart(Item item)
        {
            // Get the matching cart and item instances
            var cartItem = storeItemsDb.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.ItemId == item.ItemId);

            if (cartItem == null)
            {
                cartItem = new Cart
                {
                    ItemId = item.ItemId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeItemsDb.Carts.Add(cartItem);
            }

            var dbItem = storeItemsDb.Items.Where(x => x.ItemId == item.ItemId).SingleOrDefault();
            
            if(dbItem!=null)
            {
                dbItem.IsReserved = true;
                dbItem.LastInCart = DateTime.Now;
            }
            storeItemsDb.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = storeItemsDb.Carts.Single(
                cart => cart.RecordId == id);
            var itemToDelete = storeItemsDb.Items.Single(it => it.ItemId == cartItem.ItemId);

            if (cartItem != null)
            {
                itemToDelete.IsReserved = false;
                storeItemsDb.Carts.Remove(cartItem);
                storeItemsDb.SaveChanges();
            }
            return 0;
        }

        public void EmptyCart()
        {
            var cartItems = storeItemsDb.Carts.Where(
                cart => cart.CartId == ShoppingCartId).Select(x=>x.RecordId);

            foreach (var record in cartItems)
            {
                RemoveFromCart(record);
            }
            storeItemsDb.SaveChanges();
        }

        public List<Cart> GetCartItems()
        {
            return storeItemsDb.Carts.Where(
                cart => cart.CartId == ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            int? count = (from cartItems in storeItemsDb.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in storeItemsDb.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Item.Price).Sum();

            return total ?? decimal.Zero;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (!string.IsNullOrEmpty(context.User.Identity.Name))
                return context.User.Identity.Name;
            return "0";
        }
    }
}