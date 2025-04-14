using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    interface ICustomerRepo {
        public List<Customer> GetCustomers();
        public Customer GetCustomerByEmail(string email);
        public Customer AddCustomer(Customer customer);
        public void SaveCustomerList(List<Customer> customers);
        public Customer UpdateCustomer(Customer customer);
        public Customer RemoveCustomer(Customer customer);
    }
}