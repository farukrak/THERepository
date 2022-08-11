using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels.Recipient
{
    public class RecipientViewModel
    {
        [Key]
        [MinLength(2), MaxLength(100)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Searching Code")]
        public int SecurityCode { get; set; }
    }
}
