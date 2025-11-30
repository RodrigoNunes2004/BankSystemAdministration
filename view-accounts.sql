-- View all bank accounts with Account Number, Owner, and Balance
SELECT 
    AccountNumber,
    Owner,
    Balance,
    CreatedDate
FROM 
    BankAccounts
ORDER BY 
    CreatedDate DESC;

-- View accounts with formatted balance
SELECT 
    AccountNumber AS [Account Number],
    Owner,
    FORMAT(Balance, 'C', 'en-US') AS Balance,
    CreatedDate AS [Created Date]
FROM 
    BankAccounts
ORDER BY 
    CreatedDate DESC;

-- Count total accounts and total balance
SELECT 
    COUNT(*) AS [Total Accounts],
    FORMAT(SUM(Balance), 'C', 'en-US') AS [Total Balance]
FROM 
    BankAccounts;


