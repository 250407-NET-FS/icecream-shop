using IcecreamShopAPI.Repositories;
using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.Models;
using System.Text.RegularExpressions;

namespace IcecreamShopAPI.Services {
    partial class CustomerService: ICustomerService {
        private readonly CustomerRepo _customerRepo;

        public CustomerService(CustomerRepo customerRepo) {
            _customerRepo = customerRepo;
        }
        public bool ValidateCustomer(Customer customer) {
            Regex pattern = EmailRegex();
            return (
                customer.Name.Length > 0 &&
                pattern.IsMatch(customer.Email)
            );
        }
        public Customer AddCustomer(Customer customer) {
            if (ValidateCustomer(customer)) {
                return _customerRepo.AddCustomer(customer);
            }
            else {
                throw new ArgumentException("Customer contains invalid input");
            }
        }
        public Customer UpdateCustomer(Customer customer) {
            if (ValidateCustomer(customer)) {
                return _customerRepo.AddCustomer(customer);
            }
            else {
                throw new ArgumentException("Customer contains invalid input");
            }
        }
        public Customer DeleteCustomer(string email) {
            Regex pattern = EmailRegex();
            if (pattern.IsMatch(email)) {
                return _customerRepo.RemoveCustomer(email);
            }
            else {
                throw new ArgumentException("Email is invalid");
            }
        }
        public List<Customer> GetCustomerList() {
            return _customerRepo.GetCustomers();
        }
        [GeneratedRegex(@"^[a-z0-9]+@[a-z]\.com")]
        private static partial Regex EmailRegex();
    }
}