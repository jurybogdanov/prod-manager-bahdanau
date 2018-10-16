using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductionManager.Services
{
    public interface IProductService
    {
        ICollection<Product> GetProducts();
        Product GetProductById(int id);
        Product UpdateProduct(Product product);
        void DeleteProduct(int productId);
        Product CreateProduct(Product product);
    }
}
