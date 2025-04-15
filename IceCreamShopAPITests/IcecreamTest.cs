using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories;

namespace IceCreamShopAPITests {
    public class IcecreamTest {
        private readonly Mock<IIceCreamRepo> _icecreamRepo = new();

        private readonly IcecreamService icecreamService;

        // Test data
        private const int Scoops = 2;
        private const List<string> Flavors = ["Blueberry", "Strawberry"];
        private const bool OnCone = true;
        private const List<string> Toppings = ["Cherry"];
        private const Size Size = Size.MEDIUM;
        private readonly List<Customer> customers = [new() {Name = "Lucas Rodriguez", Email = "coldcoder9225@proton.me"}];

        public IcecreamTest() {
            icecreamService = new(_icecreamRepo.Object);
        }
        [Fact]
        public void AddIcecream_ValidRequest(int _scoops, List<string> _flavors, bool _onCone, List<string> _toppings, Size _size, List<Customer> _customers) 
        {
            // Arrange
            Icecream icecream = new () {
                Scoops = _scoops, 
                Flavors = _flavors, 
                OnCone = _onCone, 
                Toppings = _toppings, 
                Size = _size, 
                Customers = _customers
            };

            // Act
            Icecream addedIcecream = icecreamService.AddIcecream(icecream);

            // Assert
            Assert.Equal(icecream, addedIcecream);
        }
    }
}

