using System;
using System.ComponentModel.DataAnnotations;

namespace WebStore.Models.Cart
{
    public class WishList
    {
        [Key]
        public int RecordId { get; set; }
        public string WishListId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual Item Item { get; set; }
    }
}