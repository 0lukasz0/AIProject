using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Models;
using WebStore.Models.Cart;

namespace WebStore.ViewModels
{
    public class ShoppingWishListViewModel
    {
        public List<WishList> WishListItems { get; set; }
        public decimal WishListTotal { get; set; }
    }
}