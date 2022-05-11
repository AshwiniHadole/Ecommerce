using EcommerceAPI.Model;
using System.Collections.Generic;
namespace EcommerceAPI.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetAllProduct(int StoreId1);
        public Product GetProductById(int id);
        void DeleteProduct(int Id);
        void UpdateProduct(Product p);
        string CreateProduct(Product p);
    }
}
