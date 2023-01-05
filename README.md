# WebAPI
Engineering a Customer Reward Program WebAPI Backend from Scratch with RESTful API in C# ASP.NET Core MVC

---
### Setup
1. Install Visual Studio for Mac or Windows: https://www.visualstudio.com/downloads/
2. Clone the project `git clone https://github.com/bs3113/WebAPI`.
3. Run the project with Visual Studio and click run. Autogenerated Swagger UI is available at 'https://localhost:7009/swagger/index.html'.
---
### How to Use:
#### 1. GET/Transaction
Will retrieve all transactions (Since the applicaiton is not connected to DB three transactions are hardcoded in DAO layer for testing purpose)
#### 2. GET/Transaction/{customer ID} 
Will retrieve the reward points for customer with given customer ID in a three-month period from today.
#### 3. GET/Transaction/{customer ID}/{Months From Now}
Will retrieve the reward points for customer with given customer ID and given months from today.
