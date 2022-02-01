using System;
using System.Collections.Generic;
using System.Text;

namespace SelfWashSystem.Abstractions.Interfaces
{
    public interface IPumpController
    {
        void TurnOn(ushort liquidContainerIndex);
        void TurnOff();
    }
}
