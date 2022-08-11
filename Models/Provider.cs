using Cinema.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.Models
{
    public class Provider : IdentityUser, IEntity<string>
    {
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Display(Name ="Email")]
        [EmailAddress]
        [Key]
        public override string Email { get; set; }
    }
}
