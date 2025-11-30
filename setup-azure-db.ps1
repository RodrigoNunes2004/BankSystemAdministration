# Simple Azure SQL Database Setup Script
# Make sure you're logged in: az login

# Configuration - Update these values
$resourceGroupName = "BankAccountApp-RG"
$location = "eastus"
$sqlServerName = "bankaccountapp-sql-$(Get-Random -Minimum 1000 -Maximum 9999)"
$sqlDatabaseName = "BankAccountDB"
$adminUsername = "sqladmin"
$adminPassword = "ChangeThisPassword123!"  # Change this!

Write-Host "Creating resource group..." -ForegroundColor Green
az group create --name $resourceGroupName --location $location

Write-Host "Creating SQL server..." -ForegroundColor Green
az sql server create `
    --name $sqlServerName `
    --resource-group $resourceGroupName `
    --location $location `
    --admin-user $adminUsername `
    --admin-password $adminPassword

Write-Host "Configuring firewall to allow Azure services..." -ForegroundColor Green
az sql server firewall-rule create `
    --resource-group $resourceGroupName `
    --server $sqlServerName `
    --name AllowAzureServices `
    --start-ip-address 0.0.0.0 `
    --end-ip-address 0.0.0.0

Write-Host "Creating SQL database..." -ForegroundColor Green
az sql db create `
    --resource-group $resourceGroupName `
    --server $sqlServerName `
    --name $sqlDatabaseName `
    --service-objective Basic `
    --backup-storage-redundancy Local

Write-Host "`n=== Setup Complete ===" -ForegroundColor Green
Write-Host "Server Name: $sqlServerName" -ForegroundColor Yellow
Write-Host "Database Name: $sqlDatabaseName" -ForegroundColor Yellow
Write-Host "`nConnection String:" -ForegroundColor Yellow
Write-Host "Server=$sqlServerName.database.windows.net;Database=$sqlDatabaseName;User Id=$adminUsername;Password=$adminPassword;Encrypt=True;" -ForegroundColor Cyan

Write-Host "`nNext steps:" -ForegroundColor Green
Write-Host "1. Update the connection string in your app"
Write-Host "2. Run schema.sql to create the table"
Write-Host "3. Don't forget to change the admin password!"

