# Console Banking Application

A simple console-based Banking Application developed in C#. This application allows users to register, log in, create bank accounts, perform transactions, check balances, view transaction history, and apply monthly interest to savings accounts.

## Table of Contents

- [Features](#features)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Project Structure](#project-structure)

## Features

1. **User Registration & Login**
   - Register a new user with a username and password.
   - Secure login functionality to access the application.

2. **Account Management**
   - Open new bank accounts with unique account numbers, either Savings or Current.
   - Store account holder's details and initial deposit.

3. **Transaction Processing**
   - Deposit and withdraw money with validation for overdraft prevention.
   - Track each transaction with an ID, timestamp, type, and amount.

4. **Account Statement**
   - View the complete transaction history of an account, including details like date, type, and amount.

5. **Interest Calculation**
   - Monthly interest calculation for savings accounts.
   - Uses a fixed interest rate and applies interest only once per month.

6. **Balance Check**
   - Check the current balance for any account.

## Requirements

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- Basic knowledge of C# and .NET console applications

## Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/imvidur/ConsoleBankingApp.git
   cd ConsoleBankingApp

2. **Build the Project**
   ```bash
   dotnet build

3. **Run the Application**
   ```bash
   dotnet run

## Usage


Upon running the application, you will see a menu with various options:

- **Register a New User**: Register with a username and password.
- **Login**: Access your account using registered credentials.
- **Open Account**: Create a new bank account (Savings or Current) after logging in.
- **Deposit & Withdraw**: Make transactions in your account.
- **Check Balance**: View the current balance of your account.
- **Transaction History**: View a statement of your account’s transactions.
- **Apply Monthly Interest**: Calculate and add interest to savings accounts.
- **Logout / Exit**: Securely log out or exit the application.

### Example Usage

```plaintext
==================== Banking Application ====================
1. Register
2. Login
3. Exit
Select an option: 1

Enter username: johndoe
Enter password: ********
Congrats! Registration is successful!

==================== Banking Application ====================
1. Register
2. Login
3. Exit
Select an option: 2
Enter username: johndoe
Enter password: ********
Login Successful!

====================Welcome, johndoe!====================
1. Open Account
2. Logout
3. Exit
Select an option: 1

Enter account type (Saving/Current): Saving
Enter initial deposit amount: 5000
Enter account holder name: John Doe
Account created successfully.
Your Account Number is: 44f2a050-d9f3-4b1e-8272-bf5222e6e5bc
```

## Project Structure

```plaintext
ConsoleBankingApp/
├── Program.cs          # Main program logic and user interface
├── User.cs             # User class to manage user registration, login, etc.
├── Account.cs          # Account class for account management
├── Transaction.cs      # Transaction class to handle deposits and withdrawals
├── README.md           # Project documentation
└── .gitignore          # Files and directories to ignore in Git

