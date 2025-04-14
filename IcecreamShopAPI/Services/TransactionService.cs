using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories;
using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.DTOs;

namespace IcecreamShopAPI.Services {
    class TransactionService: ITransactionService {
        private readonly CustomerRepo _customerRepo;
        private readonly CashierRepo _cashierRepo;
        private readonly TransactionRepo _transactionRepo;

        public TransactionService(
            CustomerRepo customerRepo, 
            CashierRepo cashierRepo, 
            TransactionRepo transactionRepo) {
                _customerRepo = customerRepo;
                _cashierRepo = cashierRepo;
                _transactionRepo = transactionRepo;
        }
        public Transaction MakeTransaction(TransactionRequestDTO transactionRequest) {
            try {
                // Check if cashier exists
                Cashier cashier = _cashierRepo.GetCashierByPhone(transactionRequest.CashierPhone!) ?? throw new ArgumentNullException("Cashier not found");

                // Check if customer exists
                Customer customer = _customerRepo.GetCustomerByEmail(transactionRequest.CustomerEmail!) ?? throw new ArgumentNullException("Customer not found");

                // Create a new transaction
                Transaction transaction = new() {
                    CashierPhoneNumber = cashier.PhoneNumber, 
                    CustomerEmail = customer.Email, 
                };
                transaction.Icecreams = _customerRepo.GetIcecreamsByDate(customer, transaction.CreatedDate);
                transaction.TotalCost = CalculateTotalCost(transaction.Icecreams);

                // Save and add new transaction to list
                _transactionRepo.AddTransaction(transaction);

                return transaction;
            }
            catch (ArgumentNullException ex) {
                throw new(ex.Message);
            } 

            throw new NotImplementedException("Work in progress");
        }
        public double CalculateTotalCost(List<Icecream> icecreamList) {
            double cost = 0.0;
            foreach (Icecream icecream in icecreamList) {
                // formula = ((# of scoops) + (toppings * 0.25)) * size + (2 * isCone)
                if (icecream.OnCone) {
                    cost += 2;
                }
                cost += (icecream.Scoops + (icecream.Toppings.Count * 0.25)) * ((int)icecream.Size);
            }
            // tax = 15%
            return cost *= 1.15;
        }
        // TODO: Set up transaction input validation for CRUD operations
        public List<Transaction> GetTransactions() {
            return _transactionRepo.GetTransactions();
        }
        public Transaction UpdateTransaction(Transaction transaction) {
            return _transactionRepo.UpdateTransaction(transaction);
        }
        public Transaction DeleteTransaction(Transaction transaction) {
            return _transactionRepo.DeleteTransaction(transaction);
        }
    }
}