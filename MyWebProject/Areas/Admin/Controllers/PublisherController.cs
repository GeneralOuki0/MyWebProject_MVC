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
    public class PublisherController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublisherController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Publisher> objPublisherList = _unitOfWork.Publisher.GetAll().ToList();
            return View(objPublisherList);
        }
        public IActionResult Create() //Get action method
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Publisher obj) //post action method
        {
            
            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.Publisher.Add(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Publisher Added succesfully!";
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
            Publisher PublisherFromDb = _unitOfWork.Publisher.Get(u => u.PublisherId == id);
            if (PublisherFromDb == null)
            {
                return NotFound();
            }
            return View(PublisherFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Publisher obj) //post action method
        {

            if (ModelState.IsValid)//This checks the validation(from the annotations in the category Model) of the category that we created 
            {
                _unitOfWork.Publisher.Update(obj);
                _unitOfWork.Save();
                TempData["Success"] = "Publisher updated succesfully!";
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
            Publisher PublisherFromDb = _unitOfWork.Publisher.Get(u => u.PublisherId == id);
            if (PublisherFromDb == null)
            {
                return NotFound();
            }
            return View(PublisherFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id) //post action method
        {
            Publisher? obj = _unitOfWork.Publisher.Get(u => u.PublisherId == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Publisher.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Publisher deleted succesfully!";
            return RedirectToAction("Index");
        }
    }
}
