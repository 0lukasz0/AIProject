using System.Data.Entity;
using WebStore.Models.Cart;

namespace WebStore.Models.DataBase
{
    public class StoreItemsEntities : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Cart.Cart> Carts { get; set; }
        public DbSet<Cart.WishList> WishLists { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}