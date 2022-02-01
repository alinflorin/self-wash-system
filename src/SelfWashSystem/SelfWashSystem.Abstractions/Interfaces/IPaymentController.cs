using System;
using System.Collections.Generic;
using System.Text;

namespace SelfWashSystem.Abstractions.Interfaces
{
    public interface IPaymentController
    {
        bool ReadCoinAdded();
        float GetCoins();
        void Spend(float spentValue);
        void Reset();
    }
}
