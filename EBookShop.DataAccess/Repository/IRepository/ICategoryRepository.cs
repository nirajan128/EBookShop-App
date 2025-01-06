using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookShop.Models;

namespace EBookShop.DataAccess.Repository.IRepository
{
    //This inter face implments IRepository interface and gets all its base method [getAll, getfirstorDefault, Remove, REove Range]
    //Since its a Interface it does not need implement the base method
    public interface ICategoryRepository : IRepository<Category>
    {
        //IN Addition to the base method [Update and Save method are added to this Interface]
        public void Update(Category obj);
    }
}
