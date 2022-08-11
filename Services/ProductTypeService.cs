using AloeExpress.Data;
using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(ProductType productType)
        {
            var prodType = new ProductType
            {
                Name = productType.Name,
                TariffContainer = productType.TariffContainer,
                TariffAvia = productType.TariffAvia
            };

            _context.ProductTypes.Add(prodType);

            _context.SaveChanges();
        }

        public void Edit(ProductType productType)
        {
            var prodType = _context.ProductTypes.FirstOrDefault(x => x.Name == productType.Name);
            prodType.TariffContainer = productType.TariffContainer;
            prodType.TariffAvia = productType.TariffAvia;

            _context.SaveChanges();
        }
        public ProductType GetProductType(string name)
        {
            var prodType = _context.ProductTypes.FirstOrDefault(x => x.Name == name);
            return prodType;
        }
        public List<ProductType> GetAllProductType()
        {
            var prodType = _context.ProductTypes.ToList();
            return prodType;
        }
    }
}
