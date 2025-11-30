namespace BankAccountWebApp.Models
{
    public class BankAccount
    {
        public string Owner { get; set; } = string.Empty;
        public Guid AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount() { }

        public BankAccount(string owner)
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
    }
}

