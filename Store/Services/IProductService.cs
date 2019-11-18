using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface IProductService
    {
        ICollection<Product> GetAll();
        Product Get(Guid id);
        Product AddProduct(string name);
    }
}
