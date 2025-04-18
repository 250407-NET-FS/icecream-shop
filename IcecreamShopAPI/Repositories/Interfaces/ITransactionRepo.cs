using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ITransactionRepo {
        public List<Transaction> GetTransactions();
        public List<Transaction> GetTransactionsByDate(DateTime date);
        public Transaction GetTransactionById(int id);
        public Transaction AddTransaction(Transaction transaction);
        public void SaveTransactionList(List<Transaction> transactions);
        public Transaction UpdateTransaction(Transaction transaction, int id);
        public Transaction DeleteTransaction(int id);
    }
}