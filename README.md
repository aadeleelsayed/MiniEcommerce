# 🛒 Mini E-Commerce Backend (ABP Framework)

This is a robust, purely backend e-commerce application built using the [ABP Framework](https://abp.io/) (v10.0) following strict Domain-Driven Design (DDD) principles. 

## 🚀 Features
* **Layered Architecture:** Built using ABP's standard layered monolith template (Backend-only / No UI).
* **Domain-Driven Design:** Rich domain models with encapsulated business rules (e.g., stock validation, price validation).
* **Modern Mapping:** Utilizes **Mapperly** (C# Source Generators) for high-performance Outbound DTO mapping.
* **Role-Based Authorization:** Strict API endpoint protection using OpenIddict and JWT bearer tokens.
* **Soft Delete & Auditing:** Fully automated via ABP's `FullAuditedAggregateRoot`.

---

## 🛠️ How to Run the Project

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) (Version compatible with ABP 10)
* SQL Server (LocalDB or a full instance)
* ABP CLI installed (`dotnet tool install -g Volo.Abp.Cli`)

### Step-by-Step Setup
1. **Configure the Database Connection:**
   Open `appsettings.json` in **both** the `MiniECommerce.DbMigrator` and `MiniECommerce.HttpApi.Host` projects. Ensure the `Default` connection string points to your local SQL Server instance.
2. **Seed the Database:**
   Set `MiniECommerce.DbMigrator` as your startup project and run it. This will automatically create the database schema, apply all EF Core migrations, and seed the default roles and users.
3. **Install Frontend Dependencies (For Swagger UI):**
   Open a terminal in the `src/MiniECommerce.HttpApi.Host` folder and run:
   ```bash
   abp install-libs
4. Run the API:
Set MiniECommerce.HttpApi.Host as your startup project and run the application. The browser will automatically open the Swagger UI at https://localhost:443XX/swagger.

## 🗄️ How to Apply Migrations
If you make changes to the Domain Entities (e.g., adding a new property to Product), you need to generate a new database migration.

Using Package Manager Console (Visual Studio):

1. **Set MiniECommerce.EntityFrameworkCore as the Default Project in the console.**

2. **Set MiniECommerce.HttpApi.Host as the Startup Project in the Solution Explorer.**

3. **Run the command:**
Add-Migration "Your_Migration_Name"

4. **To apply the migration to your database, simply run the MiniECommerce.DbMigrator project again.**
