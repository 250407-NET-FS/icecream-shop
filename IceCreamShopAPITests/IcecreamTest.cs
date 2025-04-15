using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IceCreamShopAPITests {
    public class IcecreamTest {
        private readonly Mock<IIcecreamRepo> _icecreamRepo = new();

        private readonly IcecreamService icecreamService;

        // Test data 
        private const int Scoops = 1;
        // To be converted as a list in the test
        private const string Flavor = "Blueberry";
        private const bool OnCone = true;
        // To be converted as a list in the test
        private const string Topping = "Cherry";
        //  to be converted as an enum value in the test
        private const int TestSize = 2;
        // to be given to a test customer object
        private const string Name = "Lucas Rodriguez";
        // to be given to a test customer object
        private const string Email = "coldcoder9225@proton.me";

        private readonly Customer TestCustomer = new() {Name = "Lucas Rodriguez", Email = "coldcoder9225@proton.me"};

        public IcecreamTest() {
            icecreamService = new(_icecreamRepo.Object);
        }
        [Theory]
        [InlineData(Scoops, Flavor, OnCone, Topping, TestSize, Name, Email)]
        public void AddIcecream_ValidRequest(
            int _scoops, string _flavor, bool _onCone, string _topping, 
            int _size, string _name, string _email
        ) 
        {
            // Arrange
            Icecream icecream = new () {
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            // Act
            Icecream addedIcecream = icecreamService.AddIcecream(icecream);

            // Assert
            Assert.Equal(icecream, addedIcecream);
        }
    }
}

