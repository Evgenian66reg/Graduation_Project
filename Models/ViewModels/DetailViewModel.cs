using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace AgricultDetailMarket.Models.ViewModels
{
    public class DetailViewModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Discription { get; set; }

        [Display(Name = "Код детали")]
        public string CodeDetail { get; set; }

        [Display(Name = "Цена")]
        public int Price { get; set; }

        [Display(Name = "Категория")]
        public int CategoryId { get; set; }

    }
}
