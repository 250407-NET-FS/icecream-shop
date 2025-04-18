using System.Text.RegularExpressions;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.Services.Interfaces;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

namespace IcecreamShopAPI.Services {
    public partial class CashierService: ICashierService {
        private readonly ICashierRepo _cashierRepo;

        public CashierService(ICashierRepo cashierRepo) {
            _cashierRepo = cashierRepo;
        }
        public bool ValidateCashier(Cashier cashier) {
            // Name must not be empty && Number must have the 16 digits
            Regex pattern = PhoneRegex();
            return (
                cashier.Name.Length > 0 &&
                pattern.IsMatch(cashier.PhoneNumber)
            );
            
        }
        public Cashier AddCashier(Cashier cashier) {
            if (ValidateCashier(cashier)) {
                return _cashierRepo.AddCashier(cashier);
            }
            else {
                throw new ArgumentException("Cashier contains invalid input!");
            }
        }
        public Cashier UpdateCashier(Cashier cashier) {
            if (ValidateCashier(cashier)) {
                return _cashierRepo.UpdateCashier(cashier);
            }
            else {
                throw new ArgumentException("Cashier contains invalid input!");
            }
        }
        public Cashier DeleteCashier(Cashier cashier) {
            return _cashierRepo.RemoveCashier(cashier);
        }
        public List<Cashier> GetCashierList() {
            return _cashierRepo.GetCashiers();
        }
        public Cashier GetCashierByPhone(string phoneNumber) {
            Regex pattern = PhoneRegex();
            if (pattern.IsMatch(phoneNumber)) {
                return _cashierRepo.GetCashierByPhone(phoneNumber);
            }
            else {
                throw new ArgumentException("Phone number invalid");
            }
        }
        [GeneratedRegex(@"[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]")]
        private static partial Regex PhoneRegex();
    }
}