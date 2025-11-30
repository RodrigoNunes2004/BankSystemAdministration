# Azure SQL Database Setup via Portal

Since you're already logged into the Azure Portal, here's a simple step-by-step guide:

## Step 1: Create SQL Database

1. In the Azure Portal, click **"+ Create"** (top left) or **"Create a resource"**
2. Search for **"SQL Database"** and select it
3. Click **"Create"**

## Step 2: Fix Subscription Issue (IMPORTANT!)

**⚠️ If your subscription shows "(Disabled)":**
1. Click on the **Subscription** dropdown
2. If you have another active subscription, select it
3. If not, you need to activate your subscription:
   - Go to https://portal.azure.com/#view/Microsoft_Azure_Billing/SubscriptionsBlade
   - Find your subscription and reactivate it
   - Or contact Azure support to enable it

## Step 3: Fill in Basic Details

**Basics Tab:**
- **Subscription**: Select an **active** subscription (not disabled)
- **Resource group**: 
  - You can use an existing one (like "BankingSystem-RG") OR
  - Click "Create new" → Name: `BankAccountApp-RG` → Click OK
- **Database name**: Enter `BankAccountDB`
- **Server**: 
  - If you see an existing server (like "banking-custom-nz-server"), you can use it ✅
  - OR click "Create new" to create a fresh server:
    - Server name: `bankaccountapp-sql-[your-unique-number]` (must be globally unique)
    - Location: Choose closest to you
    - Authentication method: **SQL authentication**
    - Server admin login: `sqladmin` (or your choice)
    - Password: Choose a strong password (save this!)
    - Confirm password: Re-enter password
    - Click OK

## Step 4: Configure Database

**Compute + storage** (click "Configure database"):
- **Service tier**: Select **Basic** ($5/month - cheapest option)
- Click **Apply**

## Step 5: Networking (Optional but Recommended)

**Networking tab:**
- **Network connectivity**: 
  - Select **Public endpoint**
- **Firewall rules**:
  - ✅ Check **"Allow Azure services and resources to access this server"**
  - Click **"Add current client IP address"** (to allow your computer)
  - Or add `0.0.0.0 - 255.255.255.255` temporarily for testing (not recommended for production)

## Step 6: Create

- Click **"Review + create"** at the bottom
- Review your settings
- Click **"Create"**

Wait 2-3 minutes for deployment to complete.

## Step 7: Create the Table

Once the database is created:

1. Go to your database resource
2. In the left menu, find **"Query editor"** (under "Development")
3. Login with:
   - Username: `sqladmin` (or what you set)
   - Password: (the one you created)
4. Copy and paste the contents of `schema.sql` into the query editor
5. Click **"Run"**

## Step 8: Get Your Connection String

1. In your database, go to **"Connection strings"** (under "Settings")
2. Copy the **ADO.NET** connection string
3. Replace `{your_password}` with your actual password
4. Save this connection string - you'll need it for your C# app!

Example format:
```
Server=tcp:your-server.database.windows.net,1433;Initial Catalog=BankAccountDB;Persist Security Info=False;User ID=sqladmin;Password=YourPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

## Done! 🎉

Your database is ready. You can now use this connection string in your C# application.

