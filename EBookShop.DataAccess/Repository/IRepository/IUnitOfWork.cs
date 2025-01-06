using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookShop.DataAccess.Repository.IRepository
{
    //This interface will be used by the models
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; } //Category
        public void Save(); //method used by all classes
    }
}
