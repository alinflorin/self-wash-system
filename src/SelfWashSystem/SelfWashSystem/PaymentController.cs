using SelfWashSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWashSystem
{
    public class PaymentController : IPaymentController
    {
        private ushort _totalCoins;

        public ushort GetCoins()
        {
            return _totalCoins;
        }

        public ushort ReadCoinsAdded()
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.C)
            {
                _totalCoins++;
                return 1;
            }
            return 0;
        }
    }
}
