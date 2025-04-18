using IcecreamShopAPI.Models;
using IcecreamShopAPI.Repositories.Interfaces;
using IcecreamShopAPI.Services.Interfaces;
using IcecreamShopAPI.DTOs;

namespace IcecreamShopAPI.Services {
    public class TransactionService: ITransactionService {
        private readonly ICustomerRepo _customerRepo;
        private readonly ICashierRepo _cashierRepo;
        private readonly ITransactionRepo _transactionRepo;

        public TransactionService(
            ICustomerRepo customerRepo, 
            ICashierRepo cashierRepo, 
            ITransactionRepo transactionRepo) {
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
                throw new ArgumentNullException(ex.Message);
            } 
        }
        public double CalculateTotalCost(List<Icecream> icecreamList) {
            double cost = 0.0;
            foreach (Icecream icecream in icecreamList) {
                // formula = ((# of scoops) + (toppings * 0.25)) * size + (2 * isCone)
                if (icecream.OnCone) {
                    cost += 2;
                }
                cost += (icecream.Scoops + (icecream.Toppings.Count * 0.25)) * ((int)icecream.Size + 1);
            }
            // tax = 15%
            return Math.Round(cost * 1.15, 2);
        }
        public bool ValidateTransaction(Transaction transaction) {
            return (
                _cashierRepo.GetCashierByPhone(transaction.CashierPhoneNumber) is not null &&
                _customerRepo.GetCustomerByEmail(transaction.CustomerEmail) is not null &&
                transaction.Icecreams.Count > 0
            );
        }
        public List<Transaction> GetTransactions() {
            return _transactionRepo.GetTransactions();
        }
        public Transaction UpdateTransaction(Transaction transaction, int id) {
            if (ValidateTransaction(transaction)) {
                transaction.TotalCost = CalculateTotalCost(transaction.Icecreams);
                return _transactionRepo.UpdateTransaction(transaction, id);
            }
            else {
                throw new ArgumentException("Transaction contains invalid input");
            }
        }
        public Transaction DeleteTransaction(int id) {
                return _transactionRepo.DeleteTransaction(id);
        }
    }
}