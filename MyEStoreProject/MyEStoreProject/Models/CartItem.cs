
using System.ComponentModel.DataAnnotations;

namespace MyEStoreProject.Models
{
    public class CartItem
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public double Total => Quantity * Price;
    }
}
