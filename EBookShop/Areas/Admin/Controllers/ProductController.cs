using EBookShop.DataAccess.Repository.IRepository;
using EBookShop.Models;
using EBookShop.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EBookShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //ICategory Repository from Repository is used to replace the application DB context in controller [Same REpository can be used for different controller]
        //All the method except for [Update and Save ] are derived from base Interface Irepository
        private readonly IUnitOfWork _unitOfWork;

        //Provides info about web hosting environment, used to access wwwroot
        private readonly IWebHostEnvironment _webHostEnvironment;
      public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            return View(objProductList);
        }

        //http get
        public IActionResult Upsert(int? id) //Up for update ad sert for insert, to be used as both Create and Update action depending on the param
        {
            //Projection: Using SelectListItem type to only get the Id of Category
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            ViewBag.CategoryList = CategoryList;

            //View Model is used, which will be passe to the view
            ProductVM productVM = new ProductVM
            {
                CategoryList = CategoryList,
                Product = new Product()
            };

            //If Id is 0 or null then its a create functionality
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id); //find the category onject in db based on the id
                return View(productVM);
            }
           
        }

        //Used for post requests/method
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            //IF state of the category Model is valid meaning it completes all validation requirements
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath; //gets the root path of the wwwRootFolder

                if(file != null)
                {
                    //to generate a random guid name for image and concatinate its extension
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    //gets the path of the product flder in the images
                    string productPath = Path.Combine(wwwRootPath, @"images\product");


                    //FOR UPDATING - checks if the image file field already has a data in it
                    if (!string.IsNullOrEmpty(productVM.Product.ImageUrl)) {

                      //Delete the old image
                      var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));

                        //checks if the file exists
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath); //deletes the file
                        }
                    }

                    //Writes the file to the location - Creates it
                    using (var filestream = new FileStream(Path.Combine(productPath, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    productVM.Product.ImageUrl =@"\images\product\"+filename;
                }

                //If id exists its a Update, if not its a Create
                if (productVM.Product.Id == 0) 
                {
                    _unitOfWork.Product.Add(productVM.Product); //Method of entity fame work: Keeps track of the changes
                }
                else
                {
                    _unitOfWork.Product.Update(productVM.Product);
                }
               
                _unitOfWork.Save(); //Goes to the db and make changes
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index"); //Redirects to Index ation of category controller
            }
            else
            {
                //Only selects CategorId form Category model
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM); //if model is not valid it stays on the create view
            }
           
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
