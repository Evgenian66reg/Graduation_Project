
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AgricultDetailMarket.Models.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Укажите имя")]
        [MaxLength(20, ErrorMessage = "Имя должно иметь длину меньше 20 символов")]
        [MinLength(3, ErrorMessage = "Имя должно иметь длину больше 3 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [MaxLength(50, ErrorMessage = "Фамилия должно иметь длину меньше 50 символов")]
        [MinLength(2, ErrorMessage = "Фамилия должно иметь длину больше 2 символов")]
        public string LastName { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime DateCreated { get; set; }

        public int DetailId { get; set; }
        [ForeignKey("DetailId")]
        public virtual Detail Detail { get; set; }

        public string EmailUser { get; set; }

        [Display(Name = "Количество")]
        public uint Quantity { get; set; } = 1;

    }
}
