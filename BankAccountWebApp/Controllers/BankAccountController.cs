using Microsoft.AspNetCore.Mvc;
using BankAccountWebApp.Models;

namespace BankAccountWebApp.Controllers
{
    public class BankAccountController : Controller
    {
        private readonly BankAccountRepository _repository;

        public BankAccountController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            _repository = new BankAccountRepository(connectionString);
        }

        public IActionResult Index()
        {
            var accounts = _repository.GetAllAccounts();
            return View(accounts);
        }

        [HttpPost]
        public IActionResult Create(string owner)
        {
            if (string.IsNullOrEmpty(owner))
            {
                TempData["Error"] = "Owner name is required.";
                return RedirectToAction("Index");
            }

            try
            {
                var bankAccount = new BankAccount(owner);
                _repository.CreateAccount(bankAccount);
                TempData["Success"] = "Account created successfully!";
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error creating account: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Deposit(string accountNumber, decimal amount)
        {
            try
            {
                if (string.IsNullOrEmpty(accountNumber) || !Guid.TryParse(accountNumber, out Guid accountGuid))
                {
                    TempData["Error"] = "Please select an account first.";
                    return RedirectToAction("Index");
                }

                if (amount <= 0)
                {
                    TempData["Error"] = "Amount must be greater than zero.";
                    return RedirectToAction("Index");
                }

                var account = _repository.GetAccount(accountGuid);
                
                if (account == null)
                {
                    TempData["Error"] = "Account not found.";
                    return RedirectToAction("Index");
                }

                string message = account.Deposit(amount);
                
                if (message.Contains("successfully"))
                {
                    _repository.UpdateBalance(account.AccountNumber, account.Balance);
                    TempData["Success"] = message;
                }
                else
                {
                    TempData["Error"] = message;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error processing deposit: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Withdraw(string accountNumber, decimal amount)
        {
            try
            {
                if (string.IsNullOrEmpty(accountNumber) || !Guid.TryParse(accountNumber, out Guid accountGuid))
                {
                    TempData["Error"] = "Please select an account first.";
                    return RedirectToAction("Index");
                }

                if (amount <= 0)
                {
                    TempData["Error"] = "Amount must be greater than zero.";
                    return RedirectToAction("Index");
                }

                var account = _repository.GetAccount(accountGuid);
                
                if (account == null)
                {
                    TempData["Error"] = "Account not found.";
                    return RedirectToAction("Index");
                }

                string message = account.Withdraw(amount);
                
                if (message.Contains("successfully"))
                {
                    _repository.UpdateBalance(account.AccountNumber, account.Balance);
                    TempData["Success"] = message;
                }
                else
                {
                    TempData["Error"] = message;
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Error processing withdrawal: {ex.Message}";
            }

            return RedirectToAction("Index");
        }
    }
}

