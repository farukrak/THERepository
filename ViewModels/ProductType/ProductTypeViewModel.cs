using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels.ProductType
{
    public class ProductTypeViewModel
    {
        [Required(ErrorMessage = "Product type name is required")]
        [MinLength(1, ErrorMessage = "Empty fields are not allowed")]
        [Display(Name = "Name")]
        [Key]
        public string Name { get; set; }

        [Required(ErrorMessage = "Tariff is required")]
        [Display(Name = "Container Tariff")]
        public float TariffContainer { get; set; }
        [Required(ErrorMessage = "Tariff is required")]
        [Display(Name = "Avia Tariff")]
        public float TariffAvia { get; set; }
    }
}
