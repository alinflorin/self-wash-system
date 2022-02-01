using System;
using System.Collections.Generic;
using System.Text;

namespace SelfWashSystem.Abstractions.Interfaces
{
    public interface IPaymentController
    {
        ushort ReadCoinsAdded();
        ushort GetCoins();
    }
}
