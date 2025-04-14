namespace IcecreamShopAPI.Models {
    class Cashier {
        public string Name {get; set;} = string.Empty;
        public Guid Id {get;} = Guid.NewGuid();
        public string PhoneNumber {get; set;} = string.Empty;
    }
}
