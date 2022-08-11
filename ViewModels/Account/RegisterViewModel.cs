using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AloeExpress.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Минимум 2 символа, максимум 50")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Минимум 2 символа, максимум 50")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [EmailAddress(ErrorMessage = "Неверный Email")]
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Минимум 2 символа, максимум 50")]
        [Display(Name = "Email")]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Данный Email занят")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Минимум 4 цифр, максимум 20")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}