using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class OrderDetails
    {
        public int orderId { get; set; }

        [ForeignKey("orderId")]
        public Order order { get; set; }

        public int productId { get; set; }

        public float Price { get; set; }

        public int quantity { get; set; }
    }
}
