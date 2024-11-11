using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Transaction
{
    public string TransactionID { get; private set; }
    public DateTime Date { get; private set; }
    public string Type { get; private set; } // "Deposit" or "Withdrawal"
    public decimal Amount { get; private set; }

    public Transaction(string type, decimal amount)
    {
        TransactionID = Guid.NewGuid().ToString();
        Date = DateTime.Now;
        Type = type;
        Amount = amount;
    }
}