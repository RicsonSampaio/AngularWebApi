using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.Models;

namespace WebAPI.Data.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebAPIContext _context;

        public ProductRepository(WebAPIContext context)
        {
            _context = context;
        }
        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Product[]> GetAllProducts()
        {
            IQueryable<Product> query = _context.Products.OrderByDescending(or => or.Id);

            return await query.ToArrayAsync();
        }

        //public IEnumerable<Product> GetAllProducts()
        //{
        //    return _context.Products.OrderBy(or => or.ProductName);
        //}

        public async Task<Product> GetProduct(int id)
        {
            IQueryable<Product> query = _context.Products.Where(pr => pr.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }
    }
}
