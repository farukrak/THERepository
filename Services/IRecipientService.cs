using AloeExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Services
{
    public interface IRecipientService
    {
        public void Create(Recipient recipient);
        public void Edit(Recipient recipient);
    }
}
