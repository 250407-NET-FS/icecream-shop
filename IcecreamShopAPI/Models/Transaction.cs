using System.ComponentModel.DataAnnotations.Schema;

namespace IcecreamShopAPI.Models {
    [Table("Transactions")]
    public class Transaction {
        public int Id {get; set;}
        [ForeignKey("CashierNumber")]
        public string CashierPhoneNumber {get; set;} = string.Empty;
        [ForeignKey("CustomerEmail")]
        public string CustomerEmail {get; set;} = string.Empty;
        public List<Icecream> Icecreams {get; set;} = [];
        public Double TotalCost {get; set;} = 0.00;
        public DateTime CreatedDate {get; set;} = DateTime.Now;
    }
}