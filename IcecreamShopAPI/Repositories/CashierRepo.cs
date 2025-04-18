using System.Text.Json;
using IcecreamShopAPI.Data;
using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;

namespace IcecreamShopAPI.Repositories {
    public class CashierRepo : ICashierRepo {
        private readonly ShopDbContext _shopDb;

        public CashierRepo(ShopDbContext context) {
            _shopDb = context;
        }

        public List<Cashier> GetCashiers() {
            return _shopDb.Cashiers.ToList();
        }

        public Cashier GetCashierByPhone(string phoneNumber) {
            return _shopDb.Cashiers.Find(phoneNumber)!;
        }

        public Cashier AddCashier(Cashier cashier) {
            _shopDb.Cashiers.Add(cashier);
            _shopDb.SaveChanges();
            return cashier;
        }

        public Cashier UpdateCashier(Cashier cashier) {
            _shopDb.Cashiers.Update(cashier);
            _shopDb.SaveChanges();
            return cashier;
        }

        public Cashier RemoveCashier(Cashier cashier) {
            _shopDb.Cashiers.Remove(cashier);
            _shopDb.SaveChanges();
            return cashier;
        }
    }
}