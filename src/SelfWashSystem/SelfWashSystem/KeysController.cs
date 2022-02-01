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
            var key = Program.LastKey;
            if (ushort.TryParse(key?.KeyChar.ToString(), out ushort result))
            {
                Program.LastKey = null;
                return result;
            }
            return 0;
        }
    }
}
