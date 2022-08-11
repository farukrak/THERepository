using Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Models
{
    public class Order : IEntity<int>
    {
        public int Id { get; set; }
        public int RecipientId { get; set; }
        [Display(Name = "Creation Date")]
        public DateTime Created { get; set; }
        [Display(Name = "Product")]
        public virtual Product Product { get; set; }
        [Display(Name = "Type Of Product")]
        public virtual ProductType ProductType { get; set; }
        [Display(Name = "Deleted?")]
        public bool IsDeleted { get; set; }
        [Display(Name ="Recipient's full name")]
        public string RecipientFullName { get; set; }
    }
}
