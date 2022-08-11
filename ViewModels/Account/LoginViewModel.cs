using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Неверный Email")]
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Минимум 4 цифр")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}