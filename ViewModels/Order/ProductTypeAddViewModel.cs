using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels.Order
{
    public class ProductTypeAddViewModel
    {
        [Display(Name = "Product Type Name")]
        [Key]
        public string Name { get; set; }

        [Display(Name ="Is Added")]
        public bool IsAdded { get; set; }
    }
}
