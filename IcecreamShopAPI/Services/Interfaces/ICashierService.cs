using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Services.Interfaces {
    interface ICashierService {
        public bool ValidateCashier(Cashier cashier);
        public Cashier AddCashier(Cashier cashier);
        public Cashier UpdateCashier(Cashier cashier);
        public Cashier DeleteCashier(Cashier cashier);
        public List<Cashier> GetCashierList();
    }
}