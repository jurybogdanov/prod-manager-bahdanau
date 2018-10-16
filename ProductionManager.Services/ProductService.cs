using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductionManager.DbModel.Models;

namespace ProductionManager.Services
{
    public class ProductService : IProductService
    {
        private readonly AdventureContext _dbContext;

        public ProductService(AdventureContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Product> GetProducts()
        {
            return _dbContext.Product.Select(prd => new Product
            {
                Class = prd.Class,
                Name = prd.Name,
            }).ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Product
                .Where(prd => prd.ProductId == id)
                .Select(prd => new Product
                {
                    Class = prd.Class,
                    Name = prd.Name
                }).FirstOrDefault();
        }

        public Product UpdateProduct(Product product)
        {
            var result = _dbContext.Product.FirstOrDefault(prd => prd.ProductId == product.ProductId);

            if (result == null)
            {
                return null;
            }

            result.Name = product.Name;
            _dbContext.Entry(result).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return product;
        }

        public void DeleteProduct(int productId)
        {
            var result = _dbContext.Product.FirstOrDefault(prd => prd.ProductId == productId);

            if (result != null)
            {
                _dbContext.Entry(result).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
        }

        public Product CreateProduct(Product product)
        {
            _dbContext.Product.Add(new DbModel.Models.Product
            {
                Name = product.Name
            });

            _dbContext.SaveChanges();

            return product;
        }
    }
}
