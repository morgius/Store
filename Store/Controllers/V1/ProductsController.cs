using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Contracts.V1.Requests;
using Store.Contracts.V1.Responses;
using Store.Models;
using Store.Services;

namespace Store.Controllers.V1
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet("api/v1/products")]
        public IActionResult GetAll()
        {
            //var response = new List<ProductResponse>();
            //productService.GetAll().ToList().ForEach(x => response.Add(new ProductResponse { Id = x.Id, Name = x.Name }));
            var response = productService.GetAll().Select(x => new ProductResponse { Id = x.Id, Name = x.Name });
            return Ok(response);
        }
        [HttpGet("api/v1/products/{id}")]
        public IActionResult Get([FromRoute]Guid id)
        {
            var product = productService.Get(id);
            if (product==null)
            {
                return NotFound();
            }
            var response = new ProductResponse { Id = product.Id, Name = product.Name };
            return Ok(response);
        }
        [HttpPost("api/v1/products")]
        public IActionResult AddProduct([FromBody]ProductRequest productRequest)
        {
            var product = productService.AddProduct(productRequest.Name);
            var response = new ProductResponse { Id = product.Id, Name = product.Name };
            return CreatedAtAction(nameof(Get), new { product.Id }, product);
        }
    }
}
