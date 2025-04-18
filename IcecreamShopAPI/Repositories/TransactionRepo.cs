using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.Models;
using System.Text.Json;
using IcecreamShopAPI.Data;

namespace IcecreamShopAPI.Repositories {
    public class TransactionRepo: ITransactionRepo {
        private readonly ShopDbContext _shopDb;

        public TransactionRepo(ShopDbContext context) {
            _shopDb = context;
        }

        public List<Transaction> GetTransactions() {
            return _shopDb.Transactions.ToList();
        }

        public List<Transaction> GetTransactionsByDate(DateTime date) {
            return GetTransactions().FindAll(d => d.Equals(date));
        }

        public Transaction GetTransactionById(int id) {
            return _shopDb.Transactions.Find(id)!;
        }

        public Transaction AddTransaction(Transaction transaction) {
            _shopDb.Transactions.Add(transaction);
            _shopDb.SaveChanges();
            return transaction;
        }

        public Transaction UpdateTransaction(Transaction transaction) {
            _shopDb.Transactions.Update(transaction);
            _shopDb.SaveChanges();
            return transaction;
        }
        public Transaction DeleteTransaction(int id) {
            Transaction transaction = GetTransactionById(id);
            _shopDb.Transactions.Remove(transaction);
            _shopDb.SaveChanges();
            return transaction;
        }
    }
}