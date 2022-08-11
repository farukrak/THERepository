using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public interface IOrderService
    {
        public void Create(Order order);
        public void Edit(Order order);
        public List<Order> GetOrders(int Id);
    }
}
