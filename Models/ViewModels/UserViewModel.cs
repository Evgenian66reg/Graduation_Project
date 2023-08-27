using AgricultDetailMarket.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace AgricultDetailMarket.Models.ViewModels
{
    public class UserViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Укажите роль")]
        [Display(Name = "Роль")]
        public Role Role { get; set; }
    }
}
