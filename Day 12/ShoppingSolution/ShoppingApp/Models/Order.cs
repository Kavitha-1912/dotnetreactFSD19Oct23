using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingApp.Models
{
    public class Order
    {
        [Key]
        public int orderId { get; set; }

        public int cartNumber { get; set; }

        [ForeignKey("cartNumber")]

        public Cart cart { get; set; }

        public string Date { get; set; }
    }
}
