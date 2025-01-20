using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Betrag muss größer als 0 sein.");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Betrag muss größer als 0 sein.");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException("Nicht genug Geld.");
            }

            Balance -= amount;
        }
    }
}
