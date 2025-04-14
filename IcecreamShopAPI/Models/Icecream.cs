using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Models {
    enum Size {
        XSMALL,
        SMALL,
        MEDIUM,
        LARGE,
        XLARGE
    }
    
    class Icecream {
        public int Scoops {get; set;}
        public List<string> Flavors {get; set;} = [];
        // Icecream on a cone or on a bowl?
        public bool OnCone {get; set;}
        public List<string> Toppings {get; set;} = [];
        public Size Size {get; set;}
        // Can be associated with many customers
        public List<Customer> Customer {get; set;} = [];
    }
}