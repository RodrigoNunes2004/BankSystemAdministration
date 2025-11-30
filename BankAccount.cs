using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp
{
    public class BankAccount
    {
        public string Owner { get; set; } = string.Empty;
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount() { }

        public BankAccount(string owner ) 
        {
            Owner = owner;
            AccountNumber = Guid.NewGuid();
            Balance = 0;
        }

        public string Deposit(decimal amount)
        {
            if (amount <= 0)
                return "You can not deposit $" + amount;
            if (amount > 20000)
                return "AML Deposit Limit Reached.";

            Balance += amount;
            return "Deposit completed successfully.";
        }

        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
                return "You can not withdraw $" + amount;
            if (amount > Balance)
                return "Insufficient funds.";
            Balance -= amount;
            return "Withdrawal completed successfully.";
        }
                    
        // Validation helper used by the UI before calling repository.DeleteAccount
        public bool CanDelete(out string reason)
        {
            if (Balance != 0m)
            {
                reason = "Account balance must be zero to delete the account.";
                return false;
            }
            reason = string.Empty;
            return true;
        }

        public string DeleteAccount()
        {   
            if (Balance != 0)
                return "Account balance must be zero to delete the account.";
            return "Account deleted successfully.";

        }
    }
}
