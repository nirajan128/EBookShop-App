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
        public void Update(Category obj)
        {
            _db.Update(obj);
        }
    }
}
