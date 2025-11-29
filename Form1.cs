using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BankAccountApp
{
    public partial class Form1 : Form
    {
        List<BankAccount> BankAccounts = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateAccountBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OwnerTxt.Text))
                return;

            BankAccount bankAccount = new BankAccount(OwnerTxt.Text);
            BankAccounts.Add(bankAccount);

            RefreshGrid();
            OwnerTxt.Text = string.Empty;
        }

        private void RefreshGrid()
        {
            BankAccountsGrid.DataSource = null;
            BankAccountsGrid.DataSource = BankAccounts;
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            // allow using the current row (cell click) or a selected row (row-header selection)
            if (BankAccountsGrid.CurrentRow != null || BankAccountsGrid.SelectedRows.Count == 1)
            {
                var row = BankAccountsGrid.CurrentRow ?? BankAccountsGrid.SelectedRows[0];
                BankAccount selectedBankAccount = row.DataBoundItem as BankAccount;
                if (selectedBankAccount == null)
                    return;

                string message = selectedBankAccount.Deposit(AmountNum.Value);
                RefreshGrid();
                AmountNum.Value = 0;
                MessageBox.Show(message);
            }
        }

        private void WithdrawBtn_Click(object sender, EventArgs e)
        {
            if (BankAccountsGrid.CurrentRow != null || BankAccountsGrid.SelectedRows.Count == 1)
            {
                var row = BankAccountsGrid.CurrentRow ?? BankAccountsGrid.SelectedRows[0];
                BankAccount selectedBankAccount = row.DataBoundItem as BankAccount;
                if (selectedBankAccount == null)
                    return;

                string message = selectedBankAccount.Withdraw(AmountNum.Value);
                RefreshGrid();
                AmountNum.Value = 0;
                MessageBox.Show(message);
            }
        }
    }
}