using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductionManager.Services;

namespace ProductionManager.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILoggerService _loggerService;
        public ProductController(IProductService productService, ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _productService = productService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            _loggerService.LogInformation(" ==============> here some test info");
            throw new Exception("Some test exception");
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Get(int id)
        {
            var result = _productService.GetProductById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        // POST: api/Product
        [HttpPost]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public ActionResult Post([FromBody]Product product)
        {
            return Ok(_productService.CreateProduct(product));
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public ActionResult Put(int id, [FromBody]Product product)
        {
            var result = _productService.UpdateProduct(product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return Ok();
        }
    }
}
