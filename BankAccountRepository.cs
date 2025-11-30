using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace BankAccountApp
{
    public class BankAccountRepository
    {
        private readonly string connectionString;

        public BankAccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<BankAccount> GetAllAccounts()
        {
            var accounts = new List<BankAccount>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT AccountNumber, Owner, Balance, CreatedDate FROM BankAccounts", connection);
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        accounts.Add(new BankAccount
                        {
                            AccountNumber = reader.GetGuid(0),
                            Owner = reader.GetString(1),
                            Balance = reader.GetDecimal(2)
                        });
                    }
                }
            }

            return accounts;
        }

        public void CreateAccount(BankAccount account)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "INSERT INTO BankAccounts (AccountNumber, Owner, Balance) VALUES (@AccountNumber, @Owner, @Balance)",
                    connection);
                
                command.Parameters.AddWithValue("@AccountNumber", account.AccountNumber);
                command.Parameters.AddWithValue("@Owner", account.Owner);
                command.Parameters.AddWithValue("@Balance", account.Balance);
                
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBalance(Guid accountNumber, decimal newBalance)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "UPDATE BankAccounts SET Balance = @Balance WHERE AccountNumber = @AccountNumber",
                    connection);
                
                command.Parameters.AddWithValue("@Balance", newBalance);
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAccount(Guid accountNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(
                    "DELETE FROM BankAccounts WHERE AccountNumber = @AccountNumber",
                    connection);
                
                command.Parameters.AddWithValue("@AccountNumber", accountNumber);
                
                int rowsAffected = command.ExecuteNonQuery();
                
                if (rowsAffected == 0)
                {
                    throw new InvalidOperationException("Account not found or already deleted.");
                }
            }
        }
    }
}

