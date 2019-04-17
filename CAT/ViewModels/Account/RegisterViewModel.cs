using System.ComponentModel.DataAnnotations;

namespace CAT.ViewModels.Account
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirmation { get; set; }

        public string Login { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }
    }
}