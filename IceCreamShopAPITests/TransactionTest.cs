using Moq;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Services;
using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.DTOs;

namespace IceCreamShopAPITests {
    public class TransactionTest {
        private readonly Mock<IIcecreamRepo> _icecreamRepo = new();
        private readonly Mock<ITransactionRepo> _transactionRepo = new();
        private readonly Mock<ICashierRepo> _cashierRepo = new();
        private readonly Mock<ICustomerRepo> _customerRepo = new();

        private TransactionService _transactionService;

        // Test Data
        private const int Id = 0;
        private const string CashierName = "John Pickleberry";
        private const string PhoneNumber = "786-123-4567";
        private const string CustomerName = "Lucas Rodriguez";
        private const string Email = "coldcoder9225@proton.me";
        private const double Total = 6.61;
        // To be given to the icecream object
        private const int Scoops = 1;
        // To be converted as a list in the test
        private const string Flavor = "Blueberry";
        private const bool OnCone = true;
        // To be converted as a list in the test
        private const string Topping = "Cherry";
        //  to be converted as an enum value in the test
        private const int TestSize = 2;

        public TransactionTest() {
            _transactionService = new(
                _icecreamRepo.Object, _customerRepo.Object, 
                _cashierRepo.Object, _transactionRepo.Object
            );
        }

        [Theory]
        [InlineData 
            (
                Id, PhoneNumber, CustomerName, Email, Total, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void CalculateTotalCost(
            int _id, string _phone, string _customerName, string _email, 
            double _total, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            transaction.TotalCost = _transactionService.CalculateTotalCost(transaction.Icecreams);

            Assert.Equal(_total, transaction.TotalCost);
        }

        [Theory]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void GetTransactions_ValidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Cashier cashier1 = new () {Name = _cashierName, PhoneNumber = _phone};
            Cashier cashier2 = new () {Name = "Jessica Pickleberry", PhoneNumber = "305-123-4567"};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier1, cashier2]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            _transactionRepo.Setup(r => r.GetTransactions()).Returns([transaction]);

            Assert.Equal([transaction], _transactionService.GetTransactions());
        }

        [Theory, Trait("Category", "MakeTransaction")]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void MakeTransaction_ValidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Cashier cashier = new () {Name = _cashierName, PhoneNumber = _phone};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            TransactionRequestDTO transactionRequest = new () {
                CashierPhone = _phone, CustomerEmail = _email
            };

            Assert.Equal(transaction, _transactionService.MakeTransaction(transactionRequest));
        }

        [Theory, Trait("Category", "MakeTransaction")]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, null, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        [InlineData 
            (
                Id, CashierName, null, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void MakeTransaction_InvalidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Cashier cashier = new () {Name = _cashierName, PhoneNumber = _phone};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            TransactionRequestDTO transactionRequest = new () {
                CashierPhone = _phone, CustomerEmail = _email
            };

            Assert.Throws<ArgumentNullException>(() => _transactionService.MakeTransaction(transactionRequest));
        }

        [Theory, Trait("Category", "UpdateTransaction")]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void UpdateTransaction_ValidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Cashier cashier1 = new () {Name = _cashierName, PhoneNumber = _phone};
            Cashier cashier2 = new () {Name = "Jessica Pickleberry", PhoneNumber = "305-123-4567"};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            Transaction newTransaction = new () 
            {
                Id = _id,
                CashierPhoneNumber = cashier2.PhoneNumber,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier1, cashier2]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            _transactionRepo.Setup(r => r.GetTransactions()).Returns([transaction]);

            Assert.Equal(newTransaction, _transactionService.UpdateTransaction(newTransaction));
        }

        [Theory, Trait("Category", "UpdateTransaction")]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void UpdateTransaction_InvalidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer1 = new() {Name = _customerName, Email = _email};
            Customer customer2 = new() {Name = "M Andy", Email = "mail@potatoes.vore"};
            Cashier cashier = new () {Name = _cashierName, PhoneNumber = _phone};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer1]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            Transaction newTransaction = new () 
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = customer2.Email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer1]);

            _transactionRepo.Setup(r => r.GetTransactions()).Returns([transaction]);

            Assert.Throws<ArgumentException>(() => _transactionService.UpdateTransaction(newTransaction));
        }

        [Theory, Trait("Category", "DeleteTransaction")]
        [InlineData 
            (
                Id, CashierName, PhoneNumber, CustomerName, Email, Scoops, 
                Flavor, OnCone, Topping, TestSize
            )
        ]
        public void DeleteTransaction_ValidRequest(
            int _id, string _cashierName, string _phone, string _customerName, 
            string _email, int _scoops, string _flavor, bool _onCone,
            string _topping, int _size
        ) {
            Customer customer = new() {Name = _customerName, Email = _email};
            Cashier cashier = new () {Name = _cashierName, PhoneNumber = _phone};
            Icecream icecream = new () {
                Id = _id,
                Scoops = _scoops, 
                Flavors = [_flavor], 
                OnCone = _onCone, 
                Toppings = [_topping], 
                Size = (Size) _size, 
                Customers = [customer]
            };

            Transaction transaction = new()
            {
                Id = _id,
                CashierPhoneNumber = _phone,
                CustomerEmail = _email,
                Icecreams = [icecream],
                CreatedDate = DateTime.Now
            };

            _cashierRepo.Setup(r => r.GetCashiers()).Returns([cashier]);

            _customerRepo.Setup(r => r.GetCustomers()).Returns([customer]);

            _transactionRepo.Setup(r => r.GetTransactions()).Returns([transaction]);

            Assert.Equal(transaction, _transactionService.DeleteTransaction(_id));
        }        
    }
}