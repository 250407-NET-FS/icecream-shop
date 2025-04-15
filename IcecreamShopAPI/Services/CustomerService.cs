using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.Models;
using System.Text.RegularExpressions;

namespace IcecreamShopAPI.Services {
    public partial class CustomerService: ICustomerService {
        private readonly ICustomerRepo _customerRepo;

        public CustomerService(ICustomerRepo customerRepo) {
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