# Deploy BankAccountWebApp to Azure App Service

## Prerequisites
- Azure CLI installed and logged in: `az login`
- .NET SDK installed

## Quick Deployment Steps

### Option 1: Using Azure CLI (Recommended)

1. **Create a Resource Group** (if you don't have one):
   ```powershell
   az group create --name BankAccountApp-RG --location eastus
   ```

2. **Create App Service Plan**:
   ```powershell
   az appservice plan create --name bankaccountapp-plan --resource-group BankAccountApp-RG --sku FREE --is-linux
   ```

3. **Create Web App**:
   ```powershell
   az webapp create --name bankaccountapp-$(Get-Random -Minimum 1000 -Maximum 9999) --resource-group BankAccountApp-RG --plan bankaccountapp-plan --runtime "DOTNET|9.0"
   ```

4. **Set Connection String** (replace with your actual connection string):
   ```powershell
   az webapp config connection-string set --resource-group BankAccountApp-RG --name <your-app-name> --connection-string-type SQLAzure --settings DefaultConnection="Server=tcp:banking-system-nz-server.database.windows.net,1433;Initial Catalog=BankingSystemDb;Persist Security Info=False;User ID=bankingadmin;Password=Desurf1979$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
   ```

5. **Deploy the App**:
   ```powershell
   cd BankAccountWebApp
   dotnet publish -c Release
   cd bin/Release/net9.0/publish
   zip -r deploy.zip .
   az webapp deployment source config-zip --resource-group BankAccountApp-RG --name <your-app-name> --src deploy.zip
   ```

### Option 2: Using Azure Portal

1. Go to https://portal.azure.com
2. Click "Create a resource" → "Web App"
3. Fill in:
   - **Name**: Choose a unique name (e.g., `bankaccountapp-12345`)
   - **Resource Group**: Use existing or create new
   - **Publish**: Code
   - **Runtime stack**: .NET 9
   - **Operating System**: Linux (free tier)
   - **Region**: Choose closest to you
4. Click "Review + create" → "Create"
5. Once created, go to your Web App → "Configuration" → "Connection strings"
6. Add new connection string:
   - **Name**: `DefaultConnection`
   - **Value**: Your connection string
   - **Type**: SQLAzure
7. Click "Save"
8. Go to "Deployment Center" → Choose your deployment method (GitHub, Local Git, etc.)

### Option 3: Using Visual Studio (Easiest)

1. Right-click on `BankAccountWebApp` project
2. Select "Publish"
3. Choose "Azure" → "Azure App Service (Linux)"
4. Sign in and follow the wizard
5. Set connection string in Azure Portal after deployment

## After Deployment

1. Your app will be available at: `https://<your-app-name>.azurewebsites.net`
2. Make sure your SQL Server firewall allows Azure services
3. Test the application in your browser

## Important Notes

- **Connection String**: Store it securely in Azure App Service Configuration (not in code)
- **Firewall**: Ensure Azure SQL Server allows Azure services
- **Free Tier**: The free App Service plan has limitations (restarts after inactivity)

## Troubleshooting

- If you get connection errors, check:
  1. Connection string is correct in App Service Configuration
  2. SQL Server firewall allows Azure services
  3. Database exists and table is created

