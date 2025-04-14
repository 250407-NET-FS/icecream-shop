using IcecreamShopAPI.Models;

namespace IcecreamShopAPI {
    class Transaction {
        public Guid Id {get;} = Guid.NewGuid();
        public Cashier Cashier {get; set;}
        public Customer Customer {get; set;}
        public List<Icecream> Icecreams {get; set;} = [];
        public Double TotalCost {get; set;} = 0.00;
        public DateTime CreatedDate {get; set;} = DateTime.Now;
    }
}