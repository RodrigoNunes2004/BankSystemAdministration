using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        private readonly BankAccountRepository repository;
        private const string ConnectionString = "Server=tcp:banking-system-nz-server.database.windows.net,1433;Initial Catalog=BankingSystemDb;Persist Security Info=False;User ID=bankingadmin;Password=Desurf1979$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public Form1()
        {
            InitializeComponent();
            repository = new BankAccountRepository(ConnectionString);
            RefreshGrid();
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
                return;

            try
            {
                BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
                repository.CreateAccount(bankAccount);

                RefreshGrid();
                OwnerTxt.Text = string.Empty;
                MessageBox.Show("Account created successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshGrid()
        {
            try
            {
                var accounts = repository.GetAllAccounts();
                BankAccountsGrid.DataSource = null;
                BankAccountsGrid.DataSource = accounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            // allow using the current row (cell click) or a selected row (row-header selection)
            if (BankAccountsGrid.CurrentRow != null || BankAccountsGrid.SelectedRows.Count == 1)
            {
                var row = BankAccountsGrid.CurrentRow ?? BankAccountsGrid.SelectedRows[0];
                if (row.DataBoundItem is not BankAccount selectedBankAccount)
                    return;

                try
                {
                    string message = selectedBankAccount.Deposit(AmountNum.Value);
                    repository.UpdateBalance(selectedBankAccount.AccountNumber, selectedBankAccount.Balance);
                    RefreshGrid();
                    AmountNum.Value = 0;
                    MessageBox.Show(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing deposit: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountsGrid.CurrentRow != null || BankAccountsGrid.SelectedRows.Count == 1)
            {
                var row = BankAccountsGrid.CurrentRow ?? BankAccountsGrid.SelectedRows[0];
                if (row.DataBoundItem is not BankAccount selectedBankAccount)
                    return;

                try
                {
                    string message = selectedBankAccount.Withdraw(AmountNum.Value);
                    repository.UpdateBalance(selectedBankAccount.AccountNumber, selectedBankAccount.Balance);
                    RefreshGrid();
                    AmountNum.Value = 0;
                    MessageBox.Show(message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error processing withdrawal: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}