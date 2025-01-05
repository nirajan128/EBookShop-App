using EBookShop.DataAccess.Data;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        //Connects to the database using the services from program.cs adn applicationDbContext.cs
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; //connection
        }
        public IActionResult Index()
        {
            //_db is the connection while Categories is the Table name in the database, .toList is the method used
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
    }
}
