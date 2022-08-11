using AloeExpress.Data;
using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly ApplicationDbContext _context;
        public RecipientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Recipient recipient)
        {
            var rec = new Recipient
            {
                FullName = recipient.FullName,
                Orders = recipient.Orders,
                SecurityCode = recipient.SecurityCode,
                IsDeleted = false
            };

            _context.Recipients.Add(rec);

            _context.SaveChanges();
        }
        public void Edit(Recipient recipient)
        {
            var rec = _context.Recipients.FirstOrDefault(x => x.FullName == recipient.FullName);

            rec.FullName = recipient.FullName;
            rec.Orders = recipient.Orders;
            rec.IsDeleted = recipient.IsDeleted;
            rec.SecurityCode = recipient.SecurityCode;

            _context.SaveChanges();
        }
    }
}
