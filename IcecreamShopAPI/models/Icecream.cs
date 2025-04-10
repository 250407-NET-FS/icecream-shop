namespace IcecreamShopAPI.models {
    enum Size {
        XSMALL,
        SMALL,
        MEDIUM,
        LARGE,
        XLARGE
    }
    
    class Icecream {
        public int Scoops {get; set;}
        public List<string> Flavors {get; set;}
        public bool OnCone {get; set;} // Icecream on a cone or on a bowl?
        public List<string> Toppings {get; set;}
        public Size Size {get; set;}
    }
}