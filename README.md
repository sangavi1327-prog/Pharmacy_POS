# SmartMed Pharmacy POS

SmartMed Pharmacy POS is a Windows Forms desktop application for managing a small pharmacy. It supports admin and customer login, medicine inventory management, customer records, medicine search, cart checkout, order tracking/updates, prescriptions, and basic reporting against a SQL Server LocalDB database.

The application is written in C# for .NET Framework 4.8 and uses a layered structure:

- `Forms`: Windows Forms screens and UI event handling.
- `Services`: business logic for authentication, medicines, orders, and reports.
- `DataAccess`: shared SQL helper methods.
- `Database`: database creation and schema scripts.
- `Models`: data objects used across the app.
- `Utilities`: validation, searching, and export helpers.

## Requirements

- Windows
- Visual Studio with .NET Framework 4.8 targeting pack
- SQL Server LocalDB, usually installed with Visual Studio

## How to Run

1. Open `SmartMedPharmacy.sln` in Visual Studio.
2. Restore/build the solution.
3. Run the project.
4. The app starts with `SplashScreen`, initializes the database, and then opens `LoginForm`.

Default admin account created during database initialization:

```text
Username: admin
Password: admin123
```

## Database

The database connection strings are stored in `App.config`.

- `SmartMedDb`: connects to the application database named `SmartMedPharmacyDB`.
- `MasterDb`: connects to the LocalDB `master` database so the app can create `SmartMedPharmacyDB` if it does not exist.

`DatabaseInitializer` checks whether the database exists, creates it if needed, runs the schema, and seeds the default admin account. The schema file `Database/DbSchema.sql` is copied to the build output folder.

## Main Features

- Admin login and customer login
- Customer registration
- Medicine CRUD operations
- Medicine search by name, category, supplier, and filters
- Customer management
- Cart and order placement
- Stock reduction during checkout
- Order status updates
### below still under development
- Prescription file path recording
- Dashboard statistics
- Sales, stock, and customer reports
- Export helpers for PDF and Excel-style HTML files

## Project Files

### Root Files

| File | Purpose |
| --- | --- |
| `SmartMedPharmacy.sln` | Visual Studio solution file that groups the project. |
| `SmartMedPharmacy.csproj` | C# project file. Defines .NET Framework 4.8, WinExe output, references, compiled source files, resources, and copied database schema. |
| `App.config` | Application configuration, including SQL Server LocalDB connection strings. |
| `README.md` | Project documentation. |

### DataAccess

| File | Purpose |
| --- | --- |
| `DataAccess/DatabaseHelper.cs` | Central helper for opening SQL connections and running queries, non-query commands, and scalar commands. Uses the `SmartMedDb` connection string. |

### Database

| File | Purpose |
| --- | --- |
| `Database/DatabaseInitializer.cs` | Creates `SmartMedPharmacyDB` if missing, runs database schema commands, and inserts the default admin account. |
| `Database/DbSchema.sql` | SQL schema for `Admin`, `Customer`, `Medicine`, `Orders`, `OrderItems`, and `Prescription` tables. |

### Interfaces

| File | Purpose |
| --- | --- |
| `Interfaces/IReport.cs` | Defines the reporting contract for sales, stock, and customer reports. |

### Models

| File | Purpose |
| --- | --- |
| `Models/User.cs` | Abstract base class for users with shared `Id`, `Username`, `Password`, `Login`, and `Logout` members. |
| `Models/Admin.cs` | Admin user model that inherits from `User`. |
| `Models/Customer.cs` | Customer user model with profile fields such as full name, email, phone, and address. |
| `Models/Medicine.cs` | Medicine inventory model with price, stock, supplier, expiry date, discount, and helper methods for final price, expiry, and low-stock checks. |
| `Models/Order.cs` | Order summary model with customer, date, total amount, and status fields. |
| `Models/OrderItem.cs` | Individual order line item model containing medicine, quantity, and price values. |
| `Models/Prescription.cs` | Prescription upload record containing customer ID, file path, and upload date. |

### Services

| File | Purpose |
| --- | --- |
| `Services/Program.cs` | Application entry point. Enables WinForms visual styles and launches `SplashScreen`. |
| `Services/AuthenticationService.cs` | Handles customer registration, admin/customer login, current user session, customer profile updates, and logout. |
| `Services/MedicineService.cs` | Handles medicine CRUD operations, low-stock checks, expiring-soon checks, and database row mapping. |
| `Services/OrderService.cs` | Handles order placement with SQL transactions, stock validation, stock updates, order details, order status updates, and prescription records. Also defines `CartItem`. |
| `Services/ReportService.cs` | Generates sales, stock, customer, and dashboard summary reports using database queries. |

### Utilities

| File | Purpose |
| --- | --- |
| `Utilities/Validator.cs` | Reusable validation methods for required text, email, phone, password, price, stock, and numeric input. |
| `Utilities/LinearSearchHelper.cs` | Search and filtering helper for medicine lists, including linear search and LINQ filtering. |
| `Utilities/PdfExporter.cs` | Exports a `DataTable` report to a simple PDF file without an external PDF package. |
| `Utilities/ExcelExporter.cs` | Exports a `DataTable` report to an Excel-compatible HTML file. |

### Forms

Each form has a main `.cs` file for behavior and a `.Designer.cs` file generated by the WinForms designer for controls and layout. Designer files are normally edited through Visual Studio Designer.

| File | Purpose |
| --- | --- |
| `Forms/SplashScreen.cs` | Startup screen that initializes the database asynchronously before showing the login screen. |
| `Forms/SplashScreen.Designer.cs` | Designer-generated layout for the splash screen. |
| `Forms/LoginForm.cs` | Login screen logic for admin/customer login and navigation to registration. |
| `Forms/LoginForm.Designer.cs` | Designer-generated login screen layout. |
| `Forms/LoginForm.resx` | Resource file for the login form. |
| `Forms/RegisterForm.cs` | Customer registration logic and validation. |
| `Forms/RegisterForm.Designer.cs` | Designer-generated registration screen layout. |
| `Forms/AdminDashboard.cs` | Admin dashboard logic, dashboard statistics, navigation to management screens, logout, and exit handling. |
| `Forms/AdminDashboard.Designer.cs` | Designer-generated admin dashboard layout, including chart/dashboard controls. |
| `Forms/CustomerDashboard.cs` | Customer dashboard logic, navigation to medicine search and cart, logout, and exit handling. |
| `Forms/CustomerDashboard.Designer.cs` | Designer-generated customer dashboard layout. |
| `Forms/MedicineManagementForm.cs` | Admin medicine management logic for adding, updating, deleting, searching, and filtering medicines. |
| `Forms/MedicineManagementForm.Designer.cs` | Designer-generated medicine management layout. |
| `Forms/CustomerManagementForm.cs` | Admin customer management logic for listing, searching, selecting, validating, and updating customer records. |
| `Forms/CustomerManagementForm.Designer.cs` | Designer-generated customer management layout. |
| `Forms/OrderManagementForm.cs` | Admin order management logic for viewing orders, viewing order details, and updating order status. |
| `Forms/OrderManagementForm.Designer.cs` | Designer-generated order management layout. |
| `Forms/SearchMedicineForm.cs` | Customer medicine browsing/search screen. Loads available medicines and supports adding selected medicines to the cart. |
| `Forms/SearchMedicineForm.Designer.cs` | Designer-generated medicine search layout. |
| `Forms/CartForm.cs` | Customer cart logic, quantity handling, total calculation, and checkout through `OrderService`. |
| `Forms/CartForm.Designer.cs` | Designer-generated cart layout. |

### Properties

| File | Purpose |
| --- | --- |
| `Properties/AssemblyInfo.cs` | Assembly metadata such as title, company, product, version, and COM visibility. |

### Generated Folders

| Folder | Purpose |
| --- | --- |
| `bin/` | Build output folder containing compiled `.exe`, `.config`, `.pdb`, and copied database schema. |
| `obj/` | Intermediate build files generated by MSBuild and Visual Studio. |

## Notes for Development

- Keep form layout changes in the Visual Studio WinForms Designer when possible.
- Keep database queries parameterized, following the existing service/helper style.
- Update `Database/DbSchema.sql` and `DatabaseInitializer.GetFallbackSchema()` together if the database schema changes.
- `bin/` and `obj/` are generated build folders and usually should not be edited manually.
