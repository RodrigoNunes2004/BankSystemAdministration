# Azure SQL Database Setup

## Prerequisites
- Azure CLI installed: https://aka.ms/installazurecliwindows
- Azure account with subscription

## Quick Setup

1. **Login to Azure:**
   ```powershell
   az login
   ```

2. **Run the setup script:**
   ```powershell
   .\setup-azure-db.ps1
   ```

3. **Create the database table:**
   - Use Azure Portal: Go to your SQL database > Query editor
   - Or use Azure CLI:
     ```powershell
     az sql db execute `
       --resource-group BankAccountApp-RG `
       --server <your-server-name> `
       --database BankAccountDB `
       --file-path schema.sql
     ```

## Connection String
The script will output your connection string. Save it for use in your application.

## Important Notes
- **Change the admin password** in the script before running!
- The firewall is configured to allow Azure services only
- For local development, you may need to add your IP address:
  ```powershell
  az sql server firewall-rule create `
    --resource-group BankAccountApp-RG `
    --server <your-server-name> `
    --name AllowMyIP `
    --start-ip-address <your-ip> `
    --end-ip-address <your-ip>
  ```

## Cleanup
To delete everything when done:
```powershell
az group delete --name BankAccountApp-RG --yes
```

