using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Areas.Customer.Controllers;
using MyWebProject.Data;
using MyWebProject.Models;
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
            List<CartItem> objCartItemList = _unitOfWork.CartItem.GetAll().ToList();
            return View(objCartItemList);
        }
        public IActionResult AddToCart() //Get action method
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(CartItem obj) //post action method
        {
            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.CartItem.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Item added succesfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id) //Get action method
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CartItem cartItemFromDb = _unitOfWork.CartItem.Get(u => u.CartItemId == id);
            if (cartItemFromDb == null)
            {
                return NotFound();
            }
            return View(cartItemFromDb);
        }
        [HttpPost]
        public IActionResult Edit(CartItem obj) //post action method
        {

            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.CartItem.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "CartItem updated succesfully!";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id) //Get action method
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CartItem cartItemFromDb = _unitOfWork.CartItem.Get(u => u.CartItemId == id);
            if (cartItemFromDb == null)
            {
                return NotFound();
            }
            return View(cartItemFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //post action method
        {
            CartItem? obj = _unitOfWork.CartItem.Get(u => u.CartItemId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.CartItem.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Cart Item deleted succesfully!";
            return RedirectToAction("Index");
        }
    }
}
