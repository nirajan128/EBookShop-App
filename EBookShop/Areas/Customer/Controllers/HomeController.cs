using System.Diagnostics;
using EBookShop.DataAccess.Repository.IRepository;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties:"Category");
            return View(productList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
 
    }
}
