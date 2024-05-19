using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }    
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
