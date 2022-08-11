using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public interface IProductTypeService
    {
        public void Create(ProductType productType);
        public void Edit(ProductType productType);
        public ProductType GetProductType(string name);
        public List<ProductType> GetAllProductType();
    }
}
