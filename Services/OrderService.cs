using AloeExpress.Data;
using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Create(Order order)
        {

            var ordr = new Order
            {
                Created = DateTime.Now,
                RecipientFullName = order.RecipientFullName,
                RecipientId = _context.Recipients.Find(order.RecipientFullName).SecurityCode,
                Product = order.Product,
                ProductType = order.ProductType,
                IsDeleted = order.IsDeleted
            };

            _context.Orders.Add(ordr);
            _context.SaveChanges();
        }

        public void Edit(Order order)
        {
            var ordr = _context.Orders.FirstOrDefault(x => x.Id == order.Id);

            ordr.RecipientFullName = order.RecipientFullName;
            ordr.RecipientId = order.RecipientId;
            ordr.Product = order.Product;
            ordr.ProductType = order.ProductType;
            ordr.IsDeleted = order.IsDeleted;

            _context.SaveChanges();
        }
        public List<Order> GetOrders(int Id)
        {
            var ordr = _context.Orders.Where(x => x.RecipientId == Id)
                .ToList();
            return ordr;
        }
    }
}
