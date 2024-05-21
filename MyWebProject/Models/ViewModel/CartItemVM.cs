using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWebProject.Models.ViewModel
{
    public class CartItemVM
    {
        public CartItem cartItem { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ProductList { get; set; }
    }
}
