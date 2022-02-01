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
        private float _totalCoins;

        public float GetCoins()
        {
            return _totalCoins;
        }

        public void Spend(float spentValue)
        {
            _totalCoins -= spentValue;
        }

        public bool ReadCoinAdded()
        {
            var key = Program.LastKey;
            if (key?.Key == ConsoleKey.C)
            {
                _totalCoins++;
                Program.LastKey = null;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _totalCoins = 0;
        }
    }
}
