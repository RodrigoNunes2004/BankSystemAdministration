namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BankAccount bankAccount1 = new BankAccount();
            bankAccount1.Owner = "Saldina Nurak";
            bankAccount1.AccountNumber = Guid.NewGuid();
            bankAccount1.Balance = 5000;

            BankAccount bankAccount2 = new BankAccount();
            bankAccount2.Owner = "Elon Musk";
            bankAccount2.AccountNumber = Guid.NewGuid();
            bankAccount2.Balance = 500000;

            BankAccount bankAccount3 = new BankAccount();
            bankAccount3.Owner = "Bob Thanob";
            bankAccount3.AccountNumber = Guid.NewGuid();
            bankAccount3.Balance = 300000;

            List<BankAccount> bankAccounts = new List<BankAccount>();
            bankAccounts.Add(bankAccount1);
            bankAccounts.Add(bankAccount2);
            bankAccounts.Add(bankAccount3);

            BankAccountsGrid.DataSource = bankAccounts;
        }
    }
}
