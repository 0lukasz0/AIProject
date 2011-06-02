using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore.ViewModels
{
    public class ShoppingWishListRemoveViewModel
    {
        public string Message { get; set; }
        public decimal WishListTotal { get; set; }
        public int WishListCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }
    }
}