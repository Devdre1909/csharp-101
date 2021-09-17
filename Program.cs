using System;
using System.Collections.Generic;

namespace practice
{
  class Program
  {
    static void Main(string[] args)
    {

      var account = new BankAccount("Scott McCall", 1000);
      account.MakeDeposit(3500, DateTime.Now, "Some savings");
      account.MakeWithdrawal(5600, DateTime.Now, "Shopping!!!");
      Console.WriteLine($"Account {account.Number} was created from {account.Owner} with {account.Balance}");

    }
  }
}
