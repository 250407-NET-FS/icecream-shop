using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcecreamShopAPI.Models {
    [Table("Customers")]
    public class Customer {
        [Required]
        public string Name {get; set;} = string.Empty;
        [Key]
        public string Email {get; set;} = string.Empty;
        public List<Icecream> IcecreamHistory {get; set;} = [];
        public List<Transaction> TransactionHistory {get; set;} = [];
    }
}