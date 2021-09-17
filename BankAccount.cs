using System;
using System.Collections.Generic;

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
      MakeDeposit(initialBalance, DateTime.Now, "Open an account");
    }

    public void MakeDeposit(decimal amount, DateTime dataTime, string note)
    {

      if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      var deposit = new Transaction(amount, dataTime, note);
      transactions.Add(deposit);

    }
    public void MakeWithdrawal(decimal amount, DateTime date, string note)
    {
      if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
      if (Balance - amount <= 0) throw new InvalidOperationException("Not sufficient funds for this withdrawal");
      var withdrawal = new Transaction(-amount, date, note);
      transactions.Add(withdrawal);
    }

  }
}