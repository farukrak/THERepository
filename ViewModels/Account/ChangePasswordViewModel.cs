using System.ComponentModel.DataAnnotations;

namespace AloeExpress.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "Confirm new Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords do not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
