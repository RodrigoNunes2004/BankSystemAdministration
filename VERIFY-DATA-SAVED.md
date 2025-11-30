# Verify Data is Saved to Database

## Quick Test Steps:

### Step 1: Check Current Data in Database

1. **Go to Azure Portal** → Your database `BankingSystemDb`
2. **Open Query Editor**
3. **Run this query:**

```sql
SELECT 
    AccountNumber,
    Owner,
    Balance,
    CreatedDate
FROM 
    BankAccounts
ORDER BY 
    CreatedDate DESC;
```

**Note the current data** - how many accounts, what are the names, balances, etc.

### Step 2: Add New Data via Web App

1. **Go to your live app:**
   `https://bankaccountapp-12345-dsgpg8hhdfbsa4aq.eastasia-01.azurewebsites.net/`

2. **Create a new account:**
   - Enter a unique name (e.g., "Test User 123")
   - Click "Create Account"
   - You should see a success message

3. **Make a transaction:**
   - Click "Select" on the account you just created
   - Enter an amount (e.g., 100)
   - Click "Deposit" or "Withdraw"
   - You should see a success message

### Step 3: Verify in Database

1. **Go back to Query Editor** in Azure Portal
2. **Run the same query again:**

```sql
SELECT 
    AccountNumber,
    Owner,
    Balance,
    CreatedDate
FROM 
    BankAccounts
ORDER BY 
    CreatedDate DESC;
```

3. **Check:**
   - ✅ Your new account should appear at the top (newest first)
   - ✅ The balance should match what you deposited/withdrew
   - ✅ The CreatedDate should be recent (just now)

## Real-Time Verification:

### Option 1: Keep Query Editor Open

1. Open Query Editor in one browser tab
2. Keep your web app open in another tab
3. After each action (create account, deposit, withdraw):
   - Go to Query Editor tab
   - Click "Run" on the query
   - See the data update in real-time!

### Option 2: Check Specific Account

If you want to check a specific account:

```sql
SELECT 
    AccountNumber,
    Owner,
    Balance,
    CreatedDate
FROM 
    BankAccounts
WHERE 
    Owner = 'Test User 123'  -- Replace with the name you used
ORDER BY 
    CreatedDate DESC;
```

## What to Look For:

✅ **Data is saving if:**
- New accounts appear in the database
- Balances update after deposits/withdrawals
- CreatedDate timestamps are recent

❌ **Data is NOT saving if:**
- No new accounts appear
- Balances don't change
- You see errors in the web app

## Troubleshooting:

If data isn't saving:
1. Check the web app for error messages
2. Check "Log stream" in Azure Portal for errors
3. Verify connection string is set correctly
4. Check SQL Server firewall allows Azure services


