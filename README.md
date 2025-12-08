# CookManagement API

> A modern RESTful API for restaurant inventory management built with .NET 8 and Vertical Slice Architecture

## 📋 Overview

CookManagement API is a small yet powerful API project designed to help restaurant owners manage their inventory efficiently. Built with C# 12 and ASP.NET Core using Minimal APIs, this project follows the **Vertical Slice Architecture** pattern for better code organization and maintainability.

This project was developed for learning purposes and to reinforce backend development and RESTful API building knowledge.

## 🚀 Technologies Used

- **.NET 8** - Latest .NET framework
- **C# 12** - Modern C# features
- **ASP.NET Core** - High-performance web framework
- **PostgreSQL** - Robust relational database
- **Entity Framework Core** - ORM for data access
- **Swagger/OpenAPI** - API documentation
- **JSON Web Tokens (JWT)** - Secure authentication

## ✨ Features

The API enables restaurant owners to track their inventory by monitoring personnel activity throughout the workday. Here's what it offers:

### Inventory Management
- **Create Initial Inventory**: Personnel can record the initial count of products at the start of the workday
- **Register Daily Movements**: Track all product-related activities during the day, including:
  - Product entries
  - Courtesy items given to customers
  - Damaged or lost products
- **Create Final Inventory**: Record the final count of all products at the end of the day

### Administration & Reporting
- **Visualize User Records**: Owners can view comprehensive personnel records including:
  - Initial counts
  - Movement registers
  - Final counts
  - Sortable by date for easy tracking
- **Update Product Stock**: Owners can modify current product stock levels

### Security
- **User Authentication**: Role-based access with JWT authentication
  - Separate credentials for Owners and Personnel
  - Secure login system

## 🏗️ Building Process

The development of this API was straightforward and efficient. The requirements from stakeholders were clear from the beginning, which facilitated smooth development. Each feature was implemented without major complications.

During development, I researched best practices for date management and database storage, documenting the findings for future reference and consistency.

## 🔧 Areas for Improvement

While functional, there are several areas identified for future enhancement:

- **Unit Tests**: Due to time constraints, unit tests were not implemented. Adding comprehensive test coverage is a priority to ensure the API works as intended
- **Better RESTful Routes**: The current routing could be improved to follow REST conventions more closely
- **Result Pattern Implementation**: Currently using exceptions for validation and business logic errors. Implementing the Result Pattern would be more efficient and performant
- **Database Design Optimization**: The current schema has some redundancies that could be normalized for better efficiency
- **Better DTO Mapping**: Currently Using Static Classes for each DTO to be mapped for response. Extension Methods would be a better approach

## 🚀 How to Run the Project

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed on your machine
- PostgreSQL database server
- An IDE of your choice:
  - Visual Studio
  - JetBrains Rider
  - Visual Studio Code

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/CookManagement-API.git
   cd CookManagement-API
   ```

2. **Open the project**
   - Open the `.sln` file with your preferred IDE

3. **Configure the database**
   - Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=cookmanagement;Username=your_user;Password=your_password"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the project**
   ```bash
   dotnet run
   ```

6. **Access the API**
   - Navigate to `https://localhost:[port]/swagger` to view the API documentation
   - The API is now up and running! 🎉
