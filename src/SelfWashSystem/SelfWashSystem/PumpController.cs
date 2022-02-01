using SelfWashSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWashSystem
{
    public class PumpController : IPumpController
    {
        private readonly ushort _index;

        public PumpController(ushort index)
        {
            _index = index;
        }

        public void TurnOff()
        {
            Console.WriteLine($"Pump {_index} turned off");
        }

        public void TurnOn(ushort liquidContainerIndex)
        {
            Console.WriteLine($"Pump {_index} turned on. Liquid from container {liquidContainerIndex}");
        }
    }
}
