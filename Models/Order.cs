using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricultDetailMarket.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DetailId { get; set; }
        [ForeignKey("DetailId")]
        public virtual Detail Detail { get; set; }

        public DateTime DateTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BasketId { get; set; }

        public virtual Basket Basket { get; set;}

        public uint Quantity { get; set; } = 1;

    }
}
