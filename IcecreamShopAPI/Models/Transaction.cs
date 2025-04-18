namespace IcecreamShopAPI.Models {
    public class Transaction {
        public int Id {get; set;}
        public string CashierPhoneNumber {get; set;} = string.Empty;
        public string CustomerEmail {get; set;} = string.Empty;
        public List<Icecream> Icecreams {get; set;} = [];
        public Double TotalCost {get; set;} = 0.00;
        public DateTime CreatedDate {get; set;} = DateTime.Now;
    }
}