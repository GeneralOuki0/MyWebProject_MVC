using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebProject.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }    
        public int ProductId { get; set; }
        [Required]
        [Range(1, 500)]
        public int Quantity { get; set; }
        [ForeignKey("ProductId")]
        [ValidateNever]
        public Product Product { get; set; }
    }
}
