using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Program
{
    static List<User> users = new List<User>();
    static User? currentUser = null;

    static void Main()
    {

        bool exit = false;

        while (!exit)
        {

            if (currentUser != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n\n================= WELCOME, {currentUser.Username}!===============");
                Console.ResetColor();
            }
            else
            {
                // Default message when no user is logged in
                Console.WriteLine("\n==================== Banking Application ====================");
            }

            if (currentUser == null)
            {
                // Show options for users who are not logged in
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Select an option: ");
                Console.ResetColor();

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1: RegisterUser(); break;
                        case 2:
                            if (LoginUser())
                            {
                                continue;
                            }
                            break;
                        case 3: exit = true; break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid option.");
                }
            }
            else
            {
                if (currentUser.Accounts.Count == 0)
                {
                    Console.WriteLine("1. Open Account");
                    Console.WriteLine("2. Logout");
                    Console.WriteLine("3. Exit");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Select an option: ");
                    Console.ResetColor();

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1: OpenAccount(); break;
                            case 2: LogoutUser(); break;
                            case 3: exit = true; break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option. Please try again.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }
                }
                else
                {
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withdraw");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. View Transaction History");
                    Console.WriteLine("5. Apply Monthly Interest");
                    Console.WriteLine("6. Display Account Info");
                    Console.WriteLine("7. Logout");
                    Console.WriteLine("8. Exit");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Select an option: ");
                    Console.ResetColor();

                    int choice;
                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1: Deposit(); break;
                            case 2: Withdraw(); break;
                            case 3: CheckBalance(); break;
                            case 4: ViewTransactionHistory(); break;
                            case 5: ApplyInterest(); break;
                            case 6: DisplayInfo(); break;
                            case 7: LogoutUser(); break;
                            case 8: exit = true; break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid option. Please try again.");
                                Console.ResetColor();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid option.");
                    }
                }
            }

            static void RegisterUser()
            {
                string username;
                while (true)
                {
                    Console.Write("Enter username: ");
                    username = Console.ReadLine() ?? String.Empty;

                    // Check if the username contains at least one alpahabetic character
                    if (IsValidUsername(username))
                    {
                        break; // Exit loop if valid username
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid username. Please enter a username with letters.\n");
                        Console.ResetColor();
                    }
                }

                Console.Write("Enter password: ");
                string password = Console.ReadLine() ?? String.Empty;

                users.Add(new User(username, password));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Congrats! Registration is successful!");
                Console.ResetColor();
            }

            // Helper method to check if username contains at least one alphabetic character
            static bool IsValidUsername(string input)
            {
                // Regex checks for at least one alphabetic character and disallows purely symbols
                string pattern = @"^(?=.*[a-zA-Z])[a-zA-Z0-9]*$";
                return Regex.IsMatch(input, pattern);
            }


            static bool LoginUser()
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine() ?? String.Empty;
                Console.Write("Enter password: ");
                string password = Console.ReadLine() ?? String.Empty;

                // Find the user that matches with the provided username and password
                currentUser = users.Find(user => user.Username == username && user.Password == password);

                if (currentUser != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successful!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login failed. Incorrect username or password.");
                    Console.ResetColor();
                    return false;
                }
            }

            static void OpenAccount()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter account type (Saving/Current): ");
                Console.ResetColor();
                string accountType = Console.ReadLine() ?? String.Empty;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter initial deposit amount: ");
                decimal initialDeposit;
                Console.ResetColor();

                while (!decimal.TryParse(Console.ReadLine(), out initialDeposit) || initialDeposit < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid initial deposit amount.");
                    Console.ResetColor();
                }

                currentUser!.OpenAccount(accountType, initialDeposit);
            }

            static void Deposit()
            {
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter account number: ");
                Console.ResetColor();
                string accountNumber = Console.ReadLine() ?? String.Empty;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter deposit amount: ");
                Console.ResetColor();
                decimal amount = decimal.Parse(Console.ReadLine() ?? String.Empty);

                var account = currentUser!.Accounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                {
                    account.Deposit(amount);
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Deposit successful.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Account not found.");
                    Console.ResetColor();
                }
            }

            static void Withdraw()
            {

                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? String.Empty;
                Console.Write("Enter withdrawal amount: ");
                string input = Console.ReadLine() ?? string.Empty;

                // Validate and parse the withdrawal amount
                if (!decimal.TryParse(input, out decimal amount))
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Invalid amount. Please enter a numeric value.");
                    Console.ResetColor();
                    return;
                }

                // Define a maximum threshold for withdrawal amount
                decimal maxWithdrawalAmount = 1000000; 

                try
                {
                    if (amount <= 0)
                    {
                        throw new ArgumentException("Withdrawal amount must be positive.");
                    }

                    if (amount > maxWithdrawalAmount)
                    {
                        throw new OverflowException($"Amount exceeds the maximum allowed limit of {maxWithdrawalAmount:C}.");
                    }

                    // Find the account and check if there are sufficient funds
                    Account? account = currentUser?.Accounts.Find(a => a.AccountNumber == accountNumber);
                    if (account == null)
                    {
                        Console.WriteLine("Account not found.");
                        return;
                    }

                    if (amount > account.Balance)
                    {
                        Console.ForegroundColor=ConsoleColor.Red;
                        Console.WriteLine("Insufficient balance or account not found!.");
                        Console.ResetColor();
                        return;
                    }

                    // Process the withdrawal
                    account.Withdraw(amount);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Withdrawal successful! New balance: {account.Balance:C}");
                    Console.ResetColor();
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
            }

            static void CheckBalance()
            {
                if (currentUser == null)
                {
                    Console.WriteLine("Not a Valid User.");
                    return;
                }

                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? String.Empty;

                var account = currentUser.Accounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"Current Balance: ${account.Balance}");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Account not found.");
                    Console.ResetColor();

                }
            }

            static void ViewTransactionHistory()
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? String.Empty;

                var account = currentUser!.Accounts.Find(acc => acc.AccountNumber == accountNumber);
                if (account != null)
                {
                    account.ShowTransactionHistory();
                }
                else
                {
                    Console.WriteLine("Account not found.");
                }
            }

            static void ApplyInterest()
            {
                foreach (var account in currentUser!.Accounts)
                {
                    account.ApplyMonthlyInterest();
                }
            }

            static void DisplayInfo()
            {
                foreach (var dis in currentUser!.Accounts)
                {
                    dis.DisplayAccountInfo();

                }

            }

            static void LogoutUser()
            {
                Console.Write("Are you sure you want to logout? (Yes/No): ");
                string? confirm = Console.ReadLine()?.ToLower();

                if (confirm == "Yes" || confirm == "yes")
                {
                    currentUser = null;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Processing");
                    Console.ResetColor();
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(1500); // Delay for 1.5 seconds
                        Console.Write(".");
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You have been logged out successfully.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Logout cancelled.");
                }
            }
        }
    }
}
