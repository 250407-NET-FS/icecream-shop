using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IceCreamShopAPITests {
    public class CustomerTest {
        private readonly Mock<ICustomerRepo> _customerRepo = new();

        private readonly CustomerService _customerService;

        // Test Data
        private const string Name = "Lucas Rodriguez";
        private const string Email = "coldcoder9225@proton.me";
        // To be given to the icecream object 
        private const int Id = 0;
        private const int Scoops = 1;
        // To be converted as a list in the test
        private const string Flavor = "Blueberry";
        private const bool OnCone = true;
        // To be converted as a list in the test
        private const string Topping = "Cherry";
        //  to be converted as an enum value in the test
        private const int TestSize = 2;

        public CustomerTest() {
            _customerService = new(_customerRepo.Object);
        }

        [Theory]
        [InlineData (Name, Email, Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void GetCustomerList_ValidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size
        ) {
            // Arrange
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            customer.IcecreamHistory.Add([icecream], DateTime.Now);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            Assert.Equal([customer], _customerService.GetCustomerList());
        }

        [Theory, Trait("Category", "AddCustomer")]
        [InlineData (Name, Email, Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void AddCustomer_ValidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size
        ) {
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            customer.IcecreamHistory.Add([icecream], DateTime.Now);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([]);

            Assert.Equal(customer, _customerService.AddCustomer(customer));
        }

        [Theory, Trait("Category", "AddCashier")]
        [InlineData (Name, "mail@potatoes.vore", Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void AddCustomer_InvalidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size
        ) {
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            customer.IcecreamHistory.Add([icecream], DateTime.Now);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([]);

            Assert.Throws<ArgumentException>(() => _customerService.AddCustomer(customer));            
        }

        [Theory, Trait("Category", "UpdateCustomer")]
        [InlineData (Name, Email, Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void UpdateCustomer_ValidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size
        ) {
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            Customer newCustomer = new () {
                Name = "Cold Coder",
                Email = _email,
                IcecreamHistory = []
            };  

            customer.IcecreamHistory.Add([icecream], DateTime.Now);    
            newCustomer.IcecreamHistory.Add([icecream], DateTime.Now);         

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            Assert.Equal(newCustomer, _customerService.UpdateCustomer(newCustomer)); 
        }

        [Theory, Trait("Category", "UpdateCustomer")]
        [InlineData (Name, Email, Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void UpdateCustomer_InvalidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size
        ) {
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            Customer newCustomer = new () {
                Name = "M Andy",
                Email = "mail@potatoes.vore",
                IcecreamHistory = []
            };  

            customer.IcecreamHistory.Add([icecream], DateTime.Now);    
            newCustomer.IcecreamHistory.Add([icecream], DateTime.Now);         

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            Assert.Throws<ArgumentException>(() => _customerService.UpdateCustomer(newCustomer)); 
        }

        [Theory, Trait("Category", "DeleteCustomer")]
        [InlineData (Name, Email, Id, Scoops, Flavor, OnCone, Topping, TestSize)]
        public void DeleteCustomer_ValidRequest(
            string _name, string _email, int _id, int _scoops, string _flavor, 
            bool _onCone, string _topping, int _size            
        ) {
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [new Customer(){Name = _name, Email = _email}]
            };

            Customer customer = new () {
                Name = _name,
                Email = _email,
                IcecreamHistory = []
            };

            customer.IcecreamHistory.Add([icecream], DateTime.Now);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            Assert.Equal(customer, _customerService.DeleteCustomer(_email));            
        }
    }
}