using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IcecreamShopAPI.Models {
    public enum Size {
        XSmall,
        Small,
        Medium,
        Large,
        XLarge
    }
    [Table("Icecreams")]
    public class Icecream {
        public int Id {get; set;}
        [Required]
        public int Scoops {get; set;}
        [Required]
        public List<string> Flavors {get; set;} = [];
        // Icecream on a cone or on a bowl?
        [Required]
        public bool OnCone {get; set;}
        public List<string> Toppings {get; set;} = [];
        [Required]
        public Size Size {get; set;}
        // Can be associated with many customers
        public List<Customer> Customers {get; set;} = [];
        public List<Transaction> Transactions {get; set;} = [];

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