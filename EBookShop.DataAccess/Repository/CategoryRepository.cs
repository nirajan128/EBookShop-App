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
    //Inherits REpository Generic type and Icategory Interface whic allows this class to use base method and rcreate its own
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        //Db connectio n used from application DbContext
        //Passes the db to the base class REpository
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Category obj)
        {
           _db.Categories.Update(obj);
        }
    }
}
