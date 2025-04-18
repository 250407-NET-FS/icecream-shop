using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IceCreamShopAPITests {
    public class IcecreamTest {
        private readonly Mock<IIcecreamRepo> _icecreamRepo = new();

        private readonly IcecreamService _icecreamService;

        // Test data 
        private const int Id = 0;
        private const int Scoops = 2;
        // To be converted as a list in the test
        private const string Flavor1 = "Blueberry";
        private const string Flavor2 = "Strawberry";
        private const bool OnCone = true;
        // To be converted as a list in the test
        private const string Topping = "Cherry";
        //  to be converted as an enum value in the test
        private const int TestSize = 2;
        // to be given to a test customer object
        private const string Name = "Lucas Rodriguez";
        // to be given to a test customer object
        private const string Email = "coldcoder9225@proton.me";

        public IcecreamTest() {
            _icecreamService = new(_icecreamRepo.Object);
        }

        [Theory, Trait("Category", "AddIcecream")]
        [InlineData(Id, Scoops, Flavor1, Flavor2, OnCone, Topping, TestSize, Name, Email)]
        public void AddIcecream_ValidRequest(
            int _id, int _scoops, string _flavor1, string _flavor2, bool _onCone, 
            string _topping, int _size, string _name, string _email
        ) 
        {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1, _flavor2], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            // Act
            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([]);

            // Assert
            Assert.Equal(icecream, _icecreamService.AddIcecream(icecream));
        }
        [Theory, Trait("Category", "AddIcecream")]
        [InlineData(Id, Scoops, Flavor1, OnCone, Topping, TestSize, Name, Email)]
        public void AddIcecream_InvalidRequest(
            int _id, int _scoops, string _flavor1, bool _onCone, string _topping, 
            int _size, string _name, string _email
        ) {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            // Act
            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([]);

            // Assert
            Assert.Throws<ArgumentException>(() => _icecreamService.AddIcecream(icecream));
        }

        [Theory]
        [InlineData(Scoops, Flavor1, Flavor2, OnCone, Topping, TestSize, Name, Email)]
        public void GetIcecreamList_ValidRequest(           
            int _scoops, string _flavor1, string _flavor2, bool _onCone, string _topping, 
            int _size, string _name, string _email
            ) {
            // Arrange
            Icecream icecream = new () {
                Scoops = _scoops, 
                Flavors = [_flavor1, _flavor2], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            // Act
            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([icecream]);

            // Assert
            Assert.Equal([icecream], _icecreamService.GetIcecreamList());
        }

        [Theory, Trait("Category", "UpdateIcecream")]
        [InlineData(Id, Scoops, Flavor1, Flavor2, OnCone, Topping, TestSize, Name, Email)]
        public void UpdateIcecream_ValidRequest(
            int _id, int _scoops, string _flavor1, string _flavor2, 
            bool _onCone, string _topping, int _size, string _name, string _email
        ) {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1, _flavor2], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Icecream newIcecream = new () {
                Id = _id,
                Scoops = 1, 
                Flavors = [_flavor1], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            }; 

            // Act
            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([icecream]);

            // Assert
            Assert.Equal(newIcecream, _icecreamService.UpdateIcecream(newIcecream, _id));
        }

        [Theory, Trait("Category", "UpdateIcecream")]
        [InlineData(Id, Scoops, Flavor1, Flavor2, OnCone, Topping, TestSize, Name, Email)]
        public void UpdateIcecream_InvalidRequest(
            int _id, int _scoops, string _flavor1, string _flavor2, 
            bool _onCone, string _topping, int _size, string _name, string _email
        ) {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1, _flavor2], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Icecream newIcecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            }; 

            // Act
            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([icecream]);

            // Assert
            Assert.Throws<ArgumentException>(() => _icecreamService.UpdateIcecream(newIcecream, _id));
        }

        [Theory, Trait("Category", "DeleteIcecream")]
        [InlineData(Id, Scoops, Flavor1, Flavor2, OnCone, Topping, TestSize, Name, Email)]
        public void DeleteIcecream_ValidRequest(
            int _id, int _scoops, string _flavor1, string _flavor2, 
            bool _onCone, string _topping, int _size, string _name, string _email
        ) {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor1, _flavor2], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            _icecreamRepo.Setup(r => r.GetAllIcecream()).Returns([icecream]);

            // Act & Assert
            Assert.Equal(icecream, _icecreamService.DeleteIcecream(_id));
        }
    }
}

