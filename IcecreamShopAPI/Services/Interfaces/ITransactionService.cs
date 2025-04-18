using IcecreamShopAPI.DTOs;
using IcecreamShopAPI.Models;

namespace IcecreamShopAPI.Services.Interfaces {
    interface ITransactionService {
        public Transaction MakeTransaction(TransactionRequestDTO transactionRequest);
        public double CalculateTotalCost(List<Icecream> icecreamList);
        public List<Transaction> GetTransactions();
        public Transaction UpdateTransaction(Transaction transaction);
        public Transaction DeleteTransaction(int id);
    }
}