using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public interface IProductService
    {
        public void Create(Product product);
        public void Edit(Product product);
        public Product GetProduct(int Id);
    }
}
