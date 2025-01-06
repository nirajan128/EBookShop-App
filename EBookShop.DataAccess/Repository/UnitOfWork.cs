using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookShop.DataAccess.Data;
using EBookShop.DataAccess.Repository.IRepository;

namespace EBookShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        //Dependency Injection
        //Db connection used from application DbContext
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
