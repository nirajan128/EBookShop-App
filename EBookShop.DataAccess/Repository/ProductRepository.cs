using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookShop.DataAccess.Data;
using EBookShop.DataAccess.Repository.IRepository;
using EBookShop.Models;

namespace EBookShop.DataAccess.Repository
{
    public class ProductRepository: Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        //Db connection used from application DbContext
        //Passes the db to the base class REpository

        public ProductRepository(ApplicationDbContext db) : base(db) //Where base is the class wheich is being inherited
        {
            _db = db;
        }

        public void Update(Product obj)
        {
           var objFromDb =  _db.Product.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null) 
            { 
              objFromDb.Title = obj.Title;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.Category = obj.Category;
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;

                if (obj.ImageUrl != null) 
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
              
            
            }
        }
    }
}
