using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IceCreamShopAPITests {
    public class CashierTest {
        private readonly Mock<ICashierRepo> _cashierRepo = new();

        private readonly CashierService _cashierService;

        // Test Data
        private const string Name = "John Pickleberry";
        private const string PhoneNumber = "786-123-4567";

        public CashierTest() {
            _cashierService = new(_cashierRepo.Object);
        }

        [Theory]
        [InlineData(Name, PhoneNumber)]
        public void GetCashiers_ValidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};

            // Act
            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            // Assert
            Assert.Equal([cashier], _cashierService.GetCashierList());
        }

        [Theory, Trait("Category", "AddCashier")]
        [InlineData (Name, PhoneNumber)]
        public void AddCashier_ValidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([]);

            // Act & Assert
            Assert.Equal(cashier, _cashierService.AddCashier(cashier));
        }

        [Theory, Trait("Category", "AddCashier")]
        [InlineData (Name, "777")]
        public void AddCashier_InvalidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([]);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _cashierService.AddCashier(cashier));
        }

        [Theory, Trait("Category", "UpdateCashier")]
        [InlineData (Name, PhoneNumber)]
        public void UpdateCashier_ValidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};
            Cashier newCashier = new() {Name = "Jessica Pickleberry", PhoneNumber = _phone};

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            // Act & Assert
            Assert.Equal(newCashier, _cashierService.UpdateCashier(newCashier));
        }
        
        [Theory, Trait("Category", "UpdateCashier")]
        [InlineData (Name, PhoneNumber)]
        public void UpdateCashier_InvalidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};
            Cashier newCashier = new() {Name = "Jessica Pickleberry", PhoneNumber = "777"};

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _cashierService.UpdateCashier(newCashier));
        }

        [Theory, Trait("Category", "DeleteCashier")]
        [InlineData (Name, PhoneNumber)]
        public void DeleteCashier_ValidRequest(string _name, string _phone) {
            // Arrange
            Cashier cashier = new() {Name = _name, PhoneNumber = _phone};

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            // Act & Assert
            Assert.Equal(cashier, _cashierService.DeleteCashier(cashier));
        }
    }
}