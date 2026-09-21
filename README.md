# 🩸 Blood Bank Management System

A web-based **Blood Bank Management System** developed using **ASP.NET Core MVC, C#, Entity Framework Core, and SQL Server**.

The application helps manage blood donors, blood stock, blood requests, and user authentication through a structured MVC architecture with a responsive user interface.

---

## 📌 Project Overview

The Blood Bank Management System is designed to digitize and simplify common blood bank operations.

The system provides functionality for:

* 👤 User registration and login
* 🔐 Authentication and authorization
* 👨‍⚕️ Donor management
* 🩸 Blood stock management
* 📋 Blood request management
* 👨‍💼 Admin user management
* 🔎 Blood group-based search
* ✅ Form validation
* 🗄️ Database management using Entity Framework Core

---

## ✨ Features

### 🔐 User Authentication

* User Registration
* User Login
* Logout
* Cookie-based authentication
* Role-based authorization
* Access denied page

### 👨‍⚕️ Donor Management

* Add new donor
* View donor list
* Edit donor information
* Delete donor records
* Donor validation

### 🩸 Blood Stock Management

* Add blood stock
* View available blood stock
* Update blood stock
* Delete blood stock
* Search blood availability by blood group

### 📋 Blood Request Management

* Create blood requests
* View blood requests
* Update request information
* Delete requests
* Manage requested blood groups and units

### 👨‍💼 Admin Management

* Admin authorization
* Manage registered users
* Role-based access to administrative features

---

## 🛠️ Technologies Used

| Technology                | Purpose                   |
| ------------------------- | ------------------------- |
| **C#**                    | Backend Programming       |
| **ASP.NET Core MVC**      | Web Application Framework |
| **Entity Framework Core** | ORM & Database Operations |
| **SQL Server**            | Database                  |
| **Razor Views**           | User Interface            |
| **HTML5**                 | Web Structure             |
| **CSS3**                  | Styling                   |
| **Bootstrap**             | Responsive UI             |
| **JavaScript**            | Client-side functionality |
| **Dependency Injection**  | Service Management        |
| **Git & GitHub**          | Version Control           |
| **Visual Studio**         | Development Environment   |

---

## 🏗️ Architecture

The project follows the **MVC architecture** and uses a service layer for business logic.

```text
                    User
                      │
                      ▼
              Razor Views
                      │
                      ▼
                Controllers
                      │
                      ▼
                  Services
                      │
                      ▼
            Entity Framework Core
                      │
                      ▼
                SQL Server
```

---

## 🗃️ Database

The application uses **SQL Server** with **Entity Framework Core Code First**.

Main entities include:

* `User`
* `Donor`
* `BloodStock`
* `BloodRequest`

Database migrations are included in the project.

---

## 📂 Project Structure

```text
BloodBankManagementSystem
│
├── Controllers
│   ├── AccountController.cs
│   ├── AdminController.cs
│   ├── BloodRequestController.cs
│   ├── BloodStockController.cs
│   ├── DonorController.cs
│   └── HomeController.cs
│
├── Data
│   └── BloodBankDbContext.cs
│
├── Models
│   ├── User.cs
│   ├── Donor.cs
│   ├── BloodStock.cs
│   ├── BloodRequest.cs
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
│
├── Services
│   ├── DonorService.cs
│   ├── BloodStockService.cs
│   ├── BloodRequestService.cs
│   └── UserService.cs
│
├── Migrations
│
├── Views
│
├── wwwroot
│
├── Program.cs
├── appsettings.json
├── BloodBankManagementSystem.csproj
└── README.md
```

---

## ⚙️ Prerequisites

Before running the project, install:

* Visual Studio 2022
* .NET 10 SDK
* SQL Server
* SQL Server Management Studio (SSMS)

---

## 🚀 How to Run the Project

### 1. Clone the Repository

```bash
git clone https://github.com/Ambati01/BloodBankManagementSystem.git
```

### 2. Open the Project

Open:

```text
BloodBankManagementSystem.slnx
```

using Visual Studio.

### 3. Configure SQL Server

Open:

```text
appsettings.json
```

Update the `DefaultConnection` connection string according to your SQL Server configuration.

> **Important:** Do not upload real database passwords or other sensitive credentials to GitHub.

### 4. Apply Entity Framework Migrations

Open **Package Manager Console** in Visual Studio and run:

```powershell
Update-Database
```

Alternatively, using the .NET CLI:

```bash
dotnet ef database update
```

### 5. Run the Application

Run the project from Visual Studio:

```text
Ctrl + F5
```

or:

```bash
dotnet run
```

The application will open in your browser.

---

## 🔐 Authentication Flow

```text
Register
   ↓
Create User Account
   ↓
Login
   ↓
Authentication
   ↓
Authorization
   ↓
Access Application Features
```

Administrative features are protected using role-based authorization.

---

## 📷 Project Screenshots

### 📊 Dashboard

![Dashboard](./Screenshots/Dashboard.png)

### 👨‍⚕️ Donor List

![Donor List](./Screenshots/DonorList.png)

### ➕ Add Donor

![Add Donor](./Screenshots/AddDonor.png)

### ✏️ Edit Donor

![Edit Donor](./Screenshots/EditDonor.png)

### 🩸 Blood Stock

![Blood Stock](./Screenshots/BloodStock.png)

### ➕ Add Blood Stock

![Add Blood Stock](./Screenshots/AddBloodStock.png)

### 📋 Blood Request

![Blood Request](./Screenshots/BloodRequest.png)

### ➕ Add Blood Request

![Add Blood Request](./Screenshots/AddBloodRequest.png)

### 🗑️ Delete Confirmation

![Delete Confirmation](./Screenshots/DeleteConfirmation.png)

---

## 📚 Key Concepts Implemented

This project demonstrates practical implementation of:

* ASP.NET Core MVC
* C# and OOP concepts
* MVC Architecture
* Entity Framework Core
* Code First Migrations
* SQL Server
* CRUD Operations
* Dependency Injection
* Service Layer
* Authentication
* Authorization
* Role-based access control
* Model Validation
* Razor Views
* Bootstrap
* Exception Handling
* Git & GitHub

---

## 🎯 Future Enhancements

Possible future improvements include:

* 📧 Email notifications
* 📱 SMS notifications
* 🏥 Hospital integration
* 📊 Advanced report generation
* ☁️ Cloud deployment
* 🩸 Blood donation camp management
* 📈 Advanced analytics dashboard

---

## 🎓 Learning Outcomes

Through this project, I gained practical experience in developing a complete web application using **ASP.NET Core MVC**.

I gained hands-on experience with:

* Designing MVC-based applications
* Building CRUD functionality
* Working with SQL Server
* Using Entity Framework Core
* Implementing Dependency Injection
* Creating authentication and authorization
* Designing responsive Razor Views
* Managing database migrations
* Using Git and GitHub for version control

---

## 👨‍💻 Author

**Lokesh Ambati**

Aspiring Software Engineer | .NET Full Stack Developer

### GitHub

https://github.com/Ambati01

### LinkedIn

https://www.linkedin.com/in/lokesh-ambati-b771b4267/

---

## ⭐ If you found this project useful

Feel free to explore the repository and provide feedback.

**Thank you for visiting my project!** 🩸
