using SelfWashSystem.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWashSystem
{
    public class KeysController : IKeysController
    {
        public ushort GetPressedKey()
        {
            var key = Console.ReadKey();
            if (ushort.TryParse(key.KeyChar.ToString(), out ushort result))
            {
                return result;
            }
            return 0;
        }
    }
}
