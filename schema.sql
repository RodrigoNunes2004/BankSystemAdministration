-- Simple BankAccount table schema
CREATE TABLE BankAccounts (
    AccountNumber UNIQUEIDENTIFIER PRIMARY KEY,
    Owner NVARCHAR(255) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL DEFAULT 0,
    CreatedDate DATETIME2 NOT NULL DEFAULT GETDATE()
);

-- Optional: Create an index on Owner for faster lookups
CREATE INDEX IX_BankAccounts_Owner ON BankAccounts(Owner);

