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
        public Guid Id {get;} = Guid.NewGuid();
        public int Scoops {get; set;}
        public List<string> Flavors {get; set;} = [];
        // Icecream on a cone or on a bowl?
        public bool OnCone {get; set;}
        public List<string> Toppings {get; set;} = [];
        public Size Size {get; set;}
        // Can be associated with many customers
        public List<Customer> Customers {get; set;} = [];

        public bool Equals(Icecream other) {
            return (
                (this.Scoops == other.Scoops) &&
                this.Flavors.SequenceEqual(other.Flavors) &&
                (this.OnCone == other.OnCone) &&
                this.Toppings.SequenceEqual(other.Toppings) &&
                this.Size.Equals(other.Size)
            );
        }
    }
}