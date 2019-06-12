using System.Collections.Generic;
using System.Threading.Tasks;
using Commerce.Domain.Entities.Catalog;

namespace Commerce.Contracts.Repository
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Product product);
        Task<Product> GetProduct(int id);
        Task<bool> RemoveProduct(int id);
        Task<ICollection<Product>> GetAllProducts();
    }
}