using Cinema.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Models
{
    public class ProductType
    {
        [Key]
        public string Name { get; set; }
        public float TariffContainer { get; set; }
        public float TariffAvia { get; set; }

    }
}
