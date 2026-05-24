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

## 🔐 Default User Credentials

The database is automatically seeded with an Admin user upon running the DbMigrator. To test Customer permissions, you can create a user via the Identity API while logged in as Admin.

| Role | Username | Password | Notes |
| :--- | :--- | :--- | :--- |
| **Admin** | `userAdmin` | `1q2w3E*` | Has full access to Category and Product mutation endpoints. |
| **Customer** | *(Create via API)* | *(User defined)* | Can view products and create orders. Cannot manage categories/products. |

*Note: To authenticate in Swagger, click the **Authorize** button, check the `MiniECommerce` scope, and log in.*

---

## 📡 API Overview

The APIs enforce strict role-based access control. 

### Categories (`/api/app/category`)
* `GET` - List/Search categories (Requires Authentication)
* `POST` - Create a category (**Admin Only**)
* `PUT` - Update a category (**Admin Only**)
* `DELETE` - Delete a category (**Admin Only**)

### Products (`/api/app/product`)
* `GET` - List/Search products (Requires Authentication - Admin & Customer)
* `POST` - Create a product (**Admin Only**)
* `PUT` - Update a product (**Admin Only**)
* `DELETE` - Delete a product (**Admin Only**)

### Orders (`/api/app/order`)
* `POST` - Submit a new order (**Customer Only**). *Automatically calculates totals and deducts product stock.*

---

## 🤔 Assumptions Made

During development, the following architectural and business assumptions were made to align with strict Domain-Driven Design (DDD):

1. **Entity Encapsulation:** Entities like `Category` and `Product` use private setters or specific methods (e.g., `SetStock()`, `SetPrice()`) to prevent bypassing business rules. 
2. **Inbound Mapping:** Automatic mappers (Mapperly) are **only** used for Outbound data (Entity to DTO). Inbound data (Input DTO to Entity) is handled manually in the AppServices to ensure Domain Service validation logic is explicitly executed before saving to the database.
3. **Order Immutability:** Once a Customer creates an Order, it is considered final. Therefore, no `Update` or `Delete` endpoints were exposed for Orders.
4. **Casing of the Admin Role:** The system respects ABP's built-in Identity Data Seeder, utilizing the lowercase `"admin"` string for role validation to prevent token mismatch errors during OpenIddict authentication.
