using Microsoft.AspNetCore.Mvc;
using MyWebProject.Models;
using MyWebProject.Repository.IRepository;
using MyWebProject.ViewModels;
using System.Diagnostics;

namespace MyWebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        private readonly ILogger<AdminHomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public AdminHomeController(ILogger<AdminHomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var dashboardViewModel = new DashboardViewModel
            {
                ProductCount = _unitOfWork.Product.GetAll().Count(),
                PublisherCount = _unitOfWork.Publisher.GetAll().Count(),
                CategoryCount = _unitOfWork.Category.GetAll().Count()
            };

            return View(dashboardViewModel);
        }

    }
}
