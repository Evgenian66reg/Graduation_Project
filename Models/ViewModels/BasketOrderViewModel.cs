using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AgricultDetailMarket.Models.ViewModels
{
    public class BasketOrderViewModel
    {
        public int Id { get; set; }

        public string DetailName { get; set; }

        public int DetailPrice { get; set;}

        public string DetailCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string DateCreate { get; set; }

        public OrderViewModel Order { get; set; }

        public uint Quantity { get; set; } = 1;
    }
}
