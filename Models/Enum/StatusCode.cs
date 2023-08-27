using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricultDetailMarket.Models.Enum
{
    public enum StatusCode
    {
        UserNotFound = 0,
        DetailNotFound = 1,
        CategoryNotFound = 2,
        OrdersNotFound = 3,
        UserAlreadyExists = 4,
        Ok = 200,
        InnerErrorService = 500
    }
}
