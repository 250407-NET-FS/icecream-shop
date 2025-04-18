using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ITransactionRepo {
        public List<Transaction> GetTransactions();
        public List<Transaction> GetTransactionsByDate(DateTime date);
        public Transaction GetTransactionById(int id);
        public Transaction AddTransaction(Transaction transaction);
        public Transaction UpdateTransaction(Transaction transaction);
        public Transaction DeleteTransaction(int id);
    }
}