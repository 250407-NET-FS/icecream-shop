using System.Text.Json;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    class CustomerRepo : ICustomerRepo {
        private readonly string _jsonPath;

        public CustomerRepo() {
            _jsonPath = "./Data-Files/customers.json";
        }
        public List<Customer> GetCustomers() {
            try {
                if (!File.Exists(_jsonPath)) {
                    return [];
                }

                using FileStream reader = File.OpenRead(_jsonPath);
                return JsonSerializer.Deserialize<List<Customer>>(reader) ?? [];
            }
            catch (Exception) {
                throw new Exception("Could not retrieve list of customers");
            }
        }
        public Customer GetCustomerByEmail(string email) {
            try {
                List<Customer> customers = GetCustomers();
                return customers.Find(c => c.Email.Equals(email))!;
            }
            catch (ArgumentNullException) {
                throw new ("Could not find customer with specified email");
            }

        }
        public Customer AddCustomer(Customer customer) {
            List<Customer> customers = GetCustomers();
            if (customers.Any(c => c.Email.Equals(customer.Email))) {
                throw new Exception("Customer already exists");
            }
            customers.Add(customer);
            SaveCustomerList(customers);
            return customer;
        }
        public void SaveCustomerList(List<Customer> customers) {
            FileStream writer = File.OpenWrite(_jsonPath);
            JsonSerializer.Serialize(writer, customers);
            writer.Close();
        }
        public Customer UpdateCustomer(Customer customer) {
            List<Customer> customers = GetCustomers();
            var index = customers.FindIndex(c => c.Email.Equals(customer.Email));
            customers[index] = customer;
            SaveCustomerList(customers);
            return customer;
        }
        public Customer RemoveCustomer(Customer customer) {
            List<Customer> customers = GetCustomers();
            customers.Remove(customer);
            SaveCustomerList(customers);
            return customer;
        }
    }
}