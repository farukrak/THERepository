using AloeExpress.Data;
using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        public  ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Product product)
        {
            var prod = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Volume = product.Volume,
                Quantity = product.Quantity,
                Weight = product.Weight
            };

            _context.Products.Add(prod);

            _context.SaveChanges();
        }
        public void Edit(Product product)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            prod.Name = product.Name;
            prod.Volume = product.Volume;
            prod.Quantity = product.Quantity;
            prod.Weight = product.Weight;

            _context.SaveChanges();
        }
        public Product GetProduct(int Id)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == Id);
            return prod;
        }
    }
}
