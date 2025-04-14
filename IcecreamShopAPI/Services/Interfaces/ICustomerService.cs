using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Services.Interfaces {
    interface ICustomerService {
        public bool ValidateCustomer(Customer customer);
        public Customer AddCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public Customer DeleteCustomer(Customer customer);
        public List<Customer> GetCustomerList();
    }
}