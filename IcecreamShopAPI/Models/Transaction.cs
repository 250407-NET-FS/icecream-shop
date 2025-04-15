using IcecreamShopAPI.Models;

namespace IcecreamShopAPI {
    public class Transaction {
        public Guid Id {get;} = Guid.NewGuid();
        public string CashierPhoneNumber {get; set;} = string.Empty;
        public string CustomerEmail {get; set;} = string.Empty;
        public List<Icecream> Icecreams {get; set;} = [];
        public Double TotalCost {get; set;} = 0.00;
        public DateTime CreatedDate {get; set;} = DateTime.Now;
    }
}