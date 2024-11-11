using System.Collections.Generic;

public class User
{
    public string Username { get; private set; }
    public string Password { get; private set; }
    public List<Account> Accounts { get; private set; } = new List<Account>();

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public void OpenAccount(string accountType, decimal initialDeposit)
    {
        
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Enter account holder name: ");
        Console.ResetColor();
        string holderName = Console.ReadLine() ?? String.Empty;
        var account = new Account(holderName, accountType, initialDeposit);
        Accounts.Add(account);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Account created successfully.");
        Console.WriteLine($"Your Account Number is: {account.AccountNumber}");
        Console.ResetColor();

        
    }
}
