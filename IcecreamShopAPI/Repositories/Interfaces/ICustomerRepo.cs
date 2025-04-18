using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ICustomerRepo {
        public List<Customer> GetCustomers();
        public Customer GetCustomerByEmail(string email);
        public Customer AddCustomer(Customer customer);
        public Customer UpdateCustomer(Customer customer);
        public Customer RemoveCustomer(string email);
    }
}