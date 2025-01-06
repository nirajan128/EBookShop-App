using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EBookShop.Models;

namespace EBookShop.DataAccess.Repository.IRepository
{
    public interface IProductRepository: IRepository<Product>
    {
        //IN Addition to the base method [Update and Save method are added to this Interface]
        public void Update(Category obj);
    }
}
