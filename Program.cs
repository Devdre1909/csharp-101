using System;
using System.Collections.Generic;

namespace practice
{
  class Program
  {
    static void Main(string[] args)
    {

      var account = new BankAccount("Scott McCall", 1000);
      account.MakeDeposit(3500, "Some savings");
      account.MakeWithdrawal(500, "Shopping!!!");
      Console.WriteLine($"Account {account.Number} was created from {account.Owner} with {account.Balance}");
      account.MakeDeposit(1000, "Savings");
      account.MakeWithdrawal(3000, "XBox");
      Console.WriteLine(account.GetAccountHistory());
    }
  }
}
