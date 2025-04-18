using System.Text.Json;
using IcecreamShopAPI.Data;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    public class CustomerRepo : ICustomerRepo {
        private readonly ShopDbContext _shopDb;

        public CustomerRepo(ShopDbContext context) {
            _shopDb = context;
        }
        public List<Customer> GetCustomers() {
            return _shopDb.Customers.ToList();
        }
        public Customer GetCustomerByEmail(string email) {
            return _shopDb.Customers.Find(email)!;
        }
        public Customer AddCustomer(Customer customer) {
            _shopDb.Customers.Add(customer);
            _shopDb.SaveChanges();
            return customer;
        }

        public Customer UpdateCustomer(Customer customer) {
            _shopDb.Customers.Update(customer);
            _shopDb.SaveChanges();
            return customer;
        }

        public Customer RemoveCustomer(string email) {
            Customer customer = GetCustomerByEmail(email);
            _shopDb.Customers.Remove(customer);
            _shopDb.SaveChanges();
            return customer;
        }
    }
}