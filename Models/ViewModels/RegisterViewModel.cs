using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AgricultDetailMarket.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Укажите email")]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Укажите пароль")]
        [DataType(DataType.Password)]
        [Column("password")]
        public string Password { get; set; }
    }
}
