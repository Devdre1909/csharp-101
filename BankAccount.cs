using System;
using System.Collections.Generic;
using System.Text;

namespace practice

{
  class BankAccount
  {
    public string Number { get; }
    public string Owner { get; set; }
    public decimal Balance
    {
      get
      {
        decimal balance = 0;
        foreach (var item in transactions)
        {
          balance += item.Amount;
        }
        return balance;
      }
    }

    private static int accountNumberSeed = 12345678;

    private List<Transaction> transactions = new List<Transaction>();

    public BankAccount(string name, decimal initialBalance)
    {
      this.Number = accountNumberSeed.ToString();
      accountNumberSeed++;

      this.Owner = name;
      MakeDeposit(initialBalance, "Open an account");
    }

    public void MakeDeposit(decimal amount, string note)
    {

      if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      var deposit = new Transaction(amount, note);
      transactions.Add(deposit);

    }
    public void MakeWithdrawal(decimal amount, string note)
    {
      if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      if (Balance - amount <= 0) throw new InvalidOperationException("Not sufficient funds for this withdrawal");
      var withdrawal = new Transaction(-amount, note);
      transactions.Add(withdrawal);
    }

    public string GetAccountHistory()
    {
      var report = new StringBuilder();
      report.AppendLine("Type\t\tDate\t\t\tAmount\t\tNote");
      foreach (Transaction item in transactions)
      {
        if (item.Amount < 0) report.AppendLine($"Withdra\t\t{item.Date.ToShortDateString()}\t\t${-item.Amount}\t\t{item.Note}");
        else report.AppendLine($"Deposit\t\t{item.Date.ToShortDateString()}\t\t${item.Amount}\t\t{item.Note}");
      }
      return report.ToString();
    }
  }
}