using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricultDetailMarket.Models
{
    public class Detail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Название детали: ")]
        [Column("name")]
        public string Name { get; set; }

        [Display(Name = "Описание: ")]
        [Column("discription")]
        public string Discription { get; set; }

        [Required]
        [Display(Name = "Код детали: ")]
        [Column("code_detal")]
        public string CodeDetail { get; set; }

        [Required]
        [Display(Name = "Стоимость: ")]
        [Column("price")]
        public int Price { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
         
    }
}
