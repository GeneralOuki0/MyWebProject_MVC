using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebProject.Data;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;
using MyWebProject.StaticDetails;

namespace MyWebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create() //Get action method
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj) //post action method
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display order cannot exactly match the name."); //This is custom validation (server side)
            }

            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category created succesfully!";
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
            Category categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj) //post action method
        {

            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Category updated succesfully!";
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
            Category categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //post action method
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Category deleted succesfully!";
            return RedirectToAction("Index");
        }
    }
}
