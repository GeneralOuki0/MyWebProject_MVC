using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebProject.Areas.Customer.Controllers;
using MyWebProject.Data;
using MyWebProject.Models;
using MyWebProject.Models.ViewModel;
using MyWebProject.Repository.IRepository;
using MyWebProject.StaticDetails;

namespace MyWebProject.Areas.Admin.Controllers
{
    [Area("Customer")]
    
    public class CartItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public IActionResult Index()
        {
            List<CartItem> objCartItemList = _unitOfWork.CartItem.GetAll(IncludeProperties: "Product").ToList();
            return View(objCartItemList);
        }



        public IActionResult AddToCart() //Get action method
        {
            CartItemVM cartItemVM = new()
            {
                ProductList = _unitOfWork.Product.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Title,
                    Value = u.Id.ToString(),
                }),
                cartItem = new CartItem()
            };
            return View(cartItemVM);
        }
        [HttpPost]
        public IActionResult AddToCart(CartItemVM cartItemVM) //post action method
        {
            _unitOfWork.CartItem.Add(cartItemVM.cartItem);

            _unitOfWork.Save();
            TempData["success"] = "Added to cart successfully";
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var cartItem = _unitOfWork.CartItem.Get(c => c.CartItemId == id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _unitOfWork.CartItem.Remove(cartItem);
            _unitOfWork.Save();
            TempData["success"] = "Cart item deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
