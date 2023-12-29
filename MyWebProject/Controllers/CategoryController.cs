using Microsoft.AspNetCore.Mvc;
using MyWebProject.Data;
using MyWebProject.Models;

namespace MyWebProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationdbContext _db;
        public CategoryController(ApplicationdbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
