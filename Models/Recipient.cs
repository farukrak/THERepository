using Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Models
{
    public class Recipient
    {
        [Key]
        [MinLength(2), MaxLength(100)]
        public string FullName { get; set; }
        public virtual List<Order> Orders { get; set; }
        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }
        public int SecurityCode { get; set; }
    }
}
