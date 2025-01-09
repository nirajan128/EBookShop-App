using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EBookShop.DataAccess.Data;
using EBookShop.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace EBookShop.DataAccess.Repository
{
    public class Repository<T>: IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbSet; //to store the class type

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>(); //sets the dbSet as the class that was recived as generic class, now all the db method can be accessed
        }
        public void Add(T entity)
        {
            dbSet.Add(entity); //Adds data to database
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;  //Stores the class as a Query
            query = query.Where(filter); //APplies the fileter
            return query.FirstOrDefault(); //Returns the first element
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;  //Stores the class as a Query
            return query.ToList(); //Returns the data as a list
        }



        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
