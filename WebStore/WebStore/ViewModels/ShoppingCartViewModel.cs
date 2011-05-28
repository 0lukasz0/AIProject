using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebStore.Models;
using WebStore.Models.Cart;

namespace WebStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}