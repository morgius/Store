using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Controllers;
using Store.Models;

namespace Store.Services
{
    public class ProductsService : IProductService
    {
        private List<Product> products = new List<Product>();
        public ProductsService()
        {
            for (int i = 0; i < 10; i++)
            {
                products.Add(new Product { Id = Guid.NewGuid(), Name = $"Nazwa {i}" });
            }
        }
        public ICollection<Product> GetAll()
        {
            return products;
        }

        public Product Get(Guid idProduct)
        {
            //var test = products.Where(x => x.Id == idProduct).SingleOrDefault();
            return products.SingleOrDefault(x => x.Id == idProduct);
        }

        public Product AddProduct(string name)
        {
            var product = new Product { Id = Guid.NewGuid(), Name = name };
            products.Add(product);
            return product;
        }
    }
}
