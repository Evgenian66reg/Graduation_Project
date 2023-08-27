using AgricultDetailMarket.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricultDetailMarket.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Column ("password")]
        public string Password { get; set; }

        [Column("role")]
        public Role Role { get; set; }
        
        public Basket Basket { get; set; }
    }
}
