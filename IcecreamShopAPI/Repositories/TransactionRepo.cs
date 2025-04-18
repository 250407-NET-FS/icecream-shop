using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.Models;
using System.Text.Json;

namespace IcecreamShopAPI.Repositories {
    public class TransactionRepo: ITransactionRepo {
        private readonly string _jsonPath;

        public TransactionRepo() {
            _jsonPath = "./Data-Files/transactions.json";
        }
        public List<Transaction> GetTransactions() {
            try {
                if (!File.Exists(_jsonPath)) {
                    return [];
                }

                using FileStream reader = File.OpenRead(_jsonPath);
                return JsonSerializer.Deserialize<List<Transaction>>(reader) ?? [];
            }
            catch (Exception) {
                throw new Exception("Could not retrieve list of transactions");
            }
        }
        public List<Transaction> GetTransactionsByDate(DateTime date) {
            List<Transaction> transactions = GetTransactions();
            return transactions.FindAll(t => t.CreatedDate.Date.Equals(date.Date));
        }
        public Transaction GetTransactionById(int id) {
            try {
                List<Transaction> transactions = GetTransactions();
                return transactions[id];
            }
            catch (IndexOutOfRangeException) {
                throw new("Could not find transaction with specified id");
            }
        }
        public Transaction AddTransaction(Transaction transaction) {
            List<Transaction> transactions = GetTransactions();
            transactions.Add(transaction);
            SaveTransactionList(transactions);
            return transaction;
        }
        public void SaveTransactionList(List<Transaction> transactions) {
            FileStream writer = File.Create(_jsonPath);
            JsonSerializer.Serialize(writer, transactions);
            writer.Close();
        }
        public Transaction UpdateTransaction(Transaction transaction, int id) {
            List<Transaction> transactions = GetTransactions();
            transactions[id] = transaction;
            SaveTransactionList(transactions);
            return transaction;
        }
        public Transaction DeleteTransaction(int id) {
            List<Transaction> transactions = GetTransactions();
            Transaction transaction = transactions[id];
            transactions.RemoveAt(id);
            SaveTransactionList(transactions);
            return transaction;
        }
    }
}