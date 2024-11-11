using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Account
{
    public string AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    public string AccountType { get; private set; } // "Savings" or "Checking"
    public decimal Balance { get; set; }
    public DateTime LastInterestDate { get; private set; }

    private static decimal InterestRate = 0.0025m;
    public List<Transaction> Transactions { get; private set; } = new List<Transaction>();

    public Account(string accountHolder, string accountType, decimal initialDeposit)
    {
        AccountNumber = Guid.NewGuid().ToString();
        AccountHolder = accountHolder;
        AccountType = accountType;
        Balance = initialDeposit;
        LastInterestDate = DateTime.MinValue;
        // Starting with an empty date because interest hasn't been applied yet.
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Transactions.Add(new Transaction("Deposit", amount));
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > Balance) 
            return false;

        Balance -= amount;
        Transactions.Add(new Transaction("Withdrawal", amount));
        return true;
    }

    public void ShowTransactionHistory()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\nTransaction History:");
        Console.WriteLine("ID                                                        Date                   Type     Amount");
        Console.WriteLine("---------------------------------------------------------------------------------------------------------");
        foreach (var trans in Transactions)
        {
            Console.WriteLine($"{trans.TransactionID,-55} {trans.Date,-12} {trans.Type,-10} {trans.Amount,-8:C}");
        }
        Console.ResetColor();

    }

    public void ApplyMonthlyInterest()
    {
        // Apply interest only if it's a savings account and it's a new month since last interest applied
        if (AccountType.ToLower() == "savings" || AccountType.ToLower() == "saving")
        {
            if (LastInterestDate.Month != DateTime.Now.Month || LastInterestDate.Year != DateTime.Now.Year)
            {
                decimal interestAmount = Balance * InterestRate;
                Balance += interestAmount;  // Add interest to balance
                LastInterestDate = DateTime.Now;  // Update the last interest application date

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Hurrah!You earned an Interest");
                Console.WriteLine($"Interest of {interestAmount:C} has applied to your savings account");
                Console.WriteLine($"Your New balance:{ Balance:C}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Interest has already been applied for this month.");
                Console.ResetColor();
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry! Interest is not applicable to checking accounts.");
            Console.ResetColor();
        }
    }


    public void DisplayAccountInfo()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Account Type: {AccountType}");
        Console.WriteLine($"Balance: {Balance:C2}");
        Console.ResetColor();
    }
}
