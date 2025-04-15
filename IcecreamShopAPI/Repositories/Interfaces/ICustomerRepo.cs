using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ICustomerRepo {
        public List<Customer> GetCustomers();
        public Customer GetCustomerByEmail(string email);
        public Customer AddCustomer(Customer customer);
        public void SaveCustomerList(List<Customer> customers);
        public Customer UpdateCustomer(Customer customer);
        public Customer RemoveCustomer(string email);
        public List<Icecream> GetIcecreamsByDate(Customer customer, DateTime dateTime);
    }
}