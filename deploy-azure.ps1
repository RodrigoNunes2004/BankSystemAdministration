# Simple Azure App Service Deployment Script
# Make sure you're logged in: az login

$resourceGroupName = "BankAccountApp-RG"
$location = "eastus"
$appServicePlanName = "bankaccountapp-plan"
$webAppName = "bankaccountapp-$(Get-Random -Minimum 1000 -Maximum 9999)"
$connectionString = "Server=tcp:banking-system-nz-server.database.windows.net,1433;Initial Catalog=BankingSystemDb;Persist Security Info=False;User ID=bankingadmin;Password=Desurf1979$$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"

Write-Host "Creating resource group..." -ForegroundColor Green
az group create --name $resourceGroupName --location $location

Write-Host "Creating App Service Plan..." -ForegroundColor Green
az appservice plan create --name $appServicePlanName --resource-group $resourceGroupName --sku FREE --is-linux

Write-Host "Creating Web App..." -ForegroundColor Green
az webapp create --name $webAppName --resource-group $resourceGroupName --plan $appServicePlanName --runtime "DOTNET|9.0"

Write-Host "Setting connection string..." -ForegroundColor Green
az webapp config connection-string set `
    --resource-group $resourceGroupName `
    --name $webAppName `
    --connection-string-type SQLAzure `
    --settings DefaultConnection="$connectionString"

Write-Host "Building and publishing..." -ForegroundColor Green
cd BankAccountWebApp
dotnet publish -c Release

Write-Host "Deploying..." -ForegroundColor Green
cd bin/Release/net9.0/publish

# Create zip file
Compress-Archive -Path * -DestinationPath deploy.zip -Force

# Deploy
az webapp deployment source config-zip `
    --resource-group $resourceGroupName `
    --name $webAppName `
    --src deploy.zip

cd ../../../../..

Write-Host "`n=== Deployment Complete ===" -ForegroundColor Green
Write-Host "Your app is available at: https://$webAppName.azurewebsites.net" -ForegroundColor Yellow
Write-Host "`nNext steps:" -ForegroundColor Green
Write-Host "1. Wait 2-3 minutes for the app to start"
Write-Host "2. Visit the URL above"
Write-Host "3. Make sure your SQL Server firewall allows Azure services"

