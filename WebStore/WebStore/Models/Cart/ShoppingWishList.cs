using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebStore.Models.DataBase;

namespace WebStore.Models.Cart
{
    public partial class ShoppingWishList
    {
        StoreItemsEntities storeItemsDb = new StoreItemsEntities();
        string ShoppingWishListId { get; set; }

        public static ShoppingWishList GetWishList(HttpContextBase context)
        {
            var wishList = new ShoppingWishList();
            wishList.ShoppingWishListId = wishList.GetWishListId(context);
            return wishList;
        }

        public void AddToWishList(Item item)
        {
            var wishListItem = storeItemsDb.WishLists.SingleOrDefault(
                c => c.WishListId == ShoppingWishListId
                && c.ItemId == item.ItemId);

            if (wishListItem == null)
            {
                wishListItem = new WishList
                {
                    ItemId = item.ItemId,
                    WishListId = ShoppingWishListId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeItemsDb.WishLists.Add(wishListItem);
                storeItemsDb.SaveChanges();
            }


        }

        public int RemoveFromWishList(int id)
        {
            var wishListItem = storeItemsDb.WishLists.Single(
                wishList => wishList.WishListId == ShoppingWishListId
                && wishList.RecordId == id);

            int itemCount = 0;

            if (wishListItem != null)
            {
                if (wishListItem.Count > 1)
                {
                    wishListItem.Count--;
                    itemCount = wishListItem.Count;
                }
                else
                {
                    storeItemsDb.WishLists.Remove(wishListItem);
                }
                storeItemsDb.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyWishList()
        {
            var wishListItems = storeItemsDb.WishLists.Where(
                wishList => wishList.WishListId == ShoppingWishListId);

            foreach (var wishListItem in wishListItems)
            {
                storeItemsDb.WishLists.Remove(wishListItem);
            }
            storeItemsDb.SaveChanges();
        }

        public List<WishList> GetWishListItems()
        {
            return storeItemsDb.WishLists.Where(
                wishList => wishList.WishListId == ShoppingWishListId).ToList();
        }

        public int GetCount()
        {
            int? count = (from wishListItems in storeItemsDb.WishLists
                          where wishListItems.WishListId == ShoppingWishListId
                          select (int?)wishListItems.Count).Sum();
            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from wishListItems in storeItemsDb.WishLists
                              where wishListItems.WishListId == ShoppingWishListId
                              select (int?)wishListItems.Count *
                              wishListItems.Item.Price).Sum();

            return total ?? decimal.Zero;
        }

        public string GetWishListId(HttpContextBase context)
        {
            if (!string.IsNullOrEmpty(context.User.Identity.Name))
                return context.User.Identity.Name;
            return "0";
        }
    }
}