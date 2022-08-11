using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels.Order
{
    public class ProductAddViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Product Name")]
        public string Name { get; set; }
        [Display(Name = "Product Volume")]
        public string Volume { get; set; }
        [Display(Name = "Product Quantity")]
        public int Quantity { get; set; }
    }
}
