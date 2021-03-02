using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Data.Services
{
    public interface IProductRepository
    {
        Task<Product[]> GetAllProducts();

        //IEnumerable<Product> GetAllProducts();

        Task<Product> GetProduct(int id);

        void UpdateProduct(int id, Product product);

        void CreateProduct(Product product);

        void DeleteProduct(int id);

        Task<bool> SaveChangesAsync();
    }
}
