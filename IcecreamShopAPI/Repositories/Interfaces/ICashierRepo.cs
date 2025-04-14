using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    interface ICashierRepo {
        public List<Cashier> GetCashiers();
        public Cashier GetCashierByPhone(string phoneNumber);
        public Cashier AddCashier(Cashier cashier);
        public void SaveCashierList(List<Cashier> cashiers);
        public Cashier UpdateCashier(Cashier cashier);
        public Cashier RemoveCashier(Cashier cashier);
    }
}