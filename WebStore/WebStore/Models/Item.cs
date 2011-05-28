using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebStore.Models.Cart;

namespace WebStore.Models
{
    [Bind(Exclude = "ItemId")]
    public class Item
    {
        [ScaffoldColumn(false)]
        public int ItemId { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Author")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "An Item Title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between 0.01 and 1000.00")]
        public decimal Price { get; set; }

        [DisplayName("Item Art URL")]
        [StringLength(1024)]
        public string ItemArtUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}