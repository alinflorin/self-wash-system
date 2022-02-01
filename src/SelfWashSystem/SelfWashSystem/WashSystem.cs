using SelfWashSystem.Abstractions.Interfaces;
using SelfWashSystem.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfWashSystem
{
    public class WashSystem : AbstractWashSystem
    {
        public WashSystem(IEnumerable<IPumpController> pumpControllers, Configuration configuration,
            IPaymentController paymentController, ILcdController lcdController, IKeysController keysController) :
            base(pumpControllers, configuration, paymentController, lcdController, keysController)
        {
        }

        public override string GetAdditionalText()
        {
            return "C - add coin";
        }
    }
}
