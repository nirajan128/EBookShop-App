using EBookShop.DataAccess.Repository.IRepository;
using EBookShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace EBookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //ICategory Repository from Repository is used to replace the application DB context in controller [Same REpository can be used for different controller]
        //All the method except for [Update and Save ] are derived from base Interface Irepository
        private readonly IUnitOfWork _unitOfWork;
      public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            return View(objProductList);
        }

        //http get
        public IActionResult Create()
        {
            return View();
        }

        //Used for post requests/method
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            //IF state of the category Model is valid meaning it completes all validation requirements
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj); //Method of entity fame work: Keeps track of the changes
                _unitOfWork.Save(); //Goes to the db and make changes
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //Redirects to Index ation of category controller
            }
            return View(); //if model is not valid it stays on the create view
        }


        //http get
        public IActionResult Edit(int? id)
        {

            //Checks if the provided paramenter is valid
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id); //find the category onject in db based on the id
            if (productFromDb == null)
            {
                return NotFound();
            }


            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj); //Method of entity fame work: Keeps track of the changes
                _unitOfWork.Save();
                TempData["success"] = "Product Edited Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        //http get
        public IActionResult Delete(int? id)
        {

            //Checks if the provided paramenter is valid
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id); //find the category onject in db based on the id
            if (productFromDb == null)
            {
                return NotFound();
            }


            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")] //Specifies the name of the action since we have a different actionName
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj); //Method of entity fame work: Keeps track of the changes
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
