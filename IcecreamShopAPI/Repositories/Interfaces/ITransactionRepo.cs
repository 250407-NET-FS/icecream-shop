namespace IcecreamShopAPI.Repositories.Interfaces {
    public interface ITransactionRepo {
        public List<Transaction> GetTransactions();
        public List<Transaction> GetTransactionsByDate(DateTime date);
        public Transaction GetTransactionById(Guid id);
        public Transaction AddTransaction(Transaction transaction);
        public void SaveTransactionList(List<Transaction> transactions);
        public Transaction UpdateTransaction(Transaction transaction);
        public Transaction DeleteTransaction(Transaction transaction);
    }
}