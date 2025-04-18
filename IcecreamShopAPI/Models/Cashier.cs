using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IcecreamShopAPI.Models {
    [Table("Cashiers")]
    public class Cashier {
        [Required]
        public string Name {get; set;} = string.Empty;
        [Key]
        public string PhoneNumber {get; set;} = string.Empty;

        public List<Transaction> TransactionHistory {get; set;} = [];
    }
}
