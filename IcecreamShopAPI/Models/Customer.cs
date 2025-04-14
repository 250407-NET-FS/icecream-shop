namespace IcecreamShopAPI.Models {
    class Customer {
        public Guid Id {get;} = Guid.NewGuid();
        public string Name {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        // Can be associated with many ice creams
        public List<Icecream> IcecreamHistory {get; set;} = [];
    }
}