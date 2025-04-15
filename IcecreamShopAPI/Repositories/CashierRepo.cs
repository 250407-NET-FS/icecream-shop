using System.Text.Json;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    public class CashierRepo : ICashierRepo {
        private readonly string _jsonPath;

        public CashierRepo() {
            _jsonPath = "./Data-Files/cashiers.json";
        }
        public List<Cashier> GetCashiers() {
            try {
                if (!File.Exists(_jsonPath)) {
                    return [];
                }

                using FileStream reader = File.OpenRead(_jsonPath);
                return JsonSerializer.Deserialize<List<Cashier>>(reader) ?? [];
            }
            catch (Exception) {
                throw new Exception("Could not retrieve list of cashiers");
            }
        }
        public Cashier GetCashierByPhone(string phoneNumber) {
            try {
                List<Cashier> cashiers = GetCashiers();
                return cashiers.Find(c => c.PhoneNumber.Equals(phoneNumber))!;
            }
            catch (ArgumentNullException) {
                throw new ("Could not find cashier with specified number");
            }
        }
        public Cashier AddCashier(Cashier cashier) {
            List<Cashier> cashiers = GetCashiers();
            if (cashiers.Any(c => c.PhoneNumber.Equals(cashier.PhoneNumber))) {
                throw new Exception("Cashier already exists!");
            }

            cashiers.Add(cashier);
            SaveCashierList(cashiers);
            return cashier;

        }
        public void SaveCashierList(List<Cashier> cashiers) {
            FileStream writer = File.Create(_jsonPath);
            JsonSerializer.Serialize(writer, cashiers);
            writer.Close();
        }
        public Cashier UpdateCashier(Cashier cashier) {
            List<Cashier> cashiers = GetCashiers();
            int index = cashiers.FindIndex(c => c.Name.Equals(cashier.Name));
            cashiers[index] = cashier;
            SaveCashierList(cashiers);
            return cashier;
        }
        public Cashier RemoveCashier(Cashier cashier) {
            List<Cashier> cashiers = GetCashiers();
            cashiers.Remove(cashier);
            SaveCashierList(cashiers);
            return cashier;
        }
    }
}