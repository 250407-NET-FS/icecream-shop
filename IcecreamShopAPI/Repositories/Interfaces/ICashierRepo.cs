using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ICashierRepo {
        public List<Cashier> GetCashiers();
        public Cashier GetCashierByPhone(string phoneNumber);
        public Cashier AddCashier(Cashier cashier);
        public Cashier UpdateCashier(Cashier cashier);
        public Cashier RemoveCashier(Cashier cashier);
    }
}