# Bank Account Withdrawal Service - Submission

# Objective
The goal of this project is to improve the given bank account withdrawal implementation
### **Improvements Implemented**
I have made the following adjustments or improvements

1. **Separation of Concerns**
   - Used the MVC pattern to separate business logic (Service Layer), database operations (Repository Layer), and API handling (Controller Layer).

2. **Database Management with Entity Framework Core**
   - Used **EF Core** to manage the bank accounts and withdrawal transactions in an SQL database.

3. **Transaction Management**
   - Ensured data integrity by handling transactions safely with `DbContext.SaveChangesAsync()`.

4. **AWS SNS Integration**
   - Integrated **Amazon Simple Notification Service (SNS)** to publish withdrawal events.

5. **Dependency Injection & Configuration Management**
   - Used **ASP.NET Core’s built-in DI** to inject database context and AWS SNS service.
   - AWS credentials and region are configurable via `appsettings.json`.

6. **Error Handling & Logging**
   - Introduced proper error messages and logging to improve observability.

## **2. Implementation Choices**

### **Technology Stack**
- **ASP.NET Core** (Web API framework)
- **Entity Framework Core** (Database interaction)
- **SQL Server** (Database)
- **AWS SNS** (Event notifications)
- **C#** (Programming language)
- **Swagger UI** (API documentation)

### **Key Design Decisions**
- **Repository Pattern**: Used for clean separation of database operations.
- **Dependency Injection**: Improved modularity by injecting dependencies via constructors.
- **Exception Handling**: Used `try-catch` blocks in the service layer to gracefully handle errors.

- ## **4. Unclear Library Usage**
- **AWS SNS (`Amazon.SimpleNotificationService`)**: Required `AWSSDK.Extensions.NETCore.Setup` for proper dependency injection.
- **Entity Framework (`Microsoft.EntityFrameworkCore.SqlServer`)**: Needed to handle database transactions in SQL Server.

---
