namespace IcecreamShopAPI.Models {
    class Customer {
        public string Name {get; set;} = string.Empty;
        public string Email {get; set;} = string.Empty;
        // Can be associated with many ice creams
        public Dictionary<List<Icecream>, DateTime> IcecreamHistory {get; set;} = [];
    }
}