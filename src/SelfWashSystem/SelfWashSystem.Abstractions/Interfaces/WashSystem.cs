using SelfWashSystem.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SelfWashSystem.Abstractions.Interfaces
{
    public class WashSystem
    {
        private readonly IEnumerable<IPumpController> _pumpControllers;
        private readonly Configuration _configuration;
        private readonly IPaymentController _paymentController;
        private readonly ILcdController _lcdController;
        private readonly IKeysController _keysController;

        public WashSystem(IEnumerable<IPumpController> pumpControllers, Configuration configuration,
            IPaymentController paymentController, ILcdController lcdController, IKeysController keysController)
        {
            _pumpControllers = pumpControllers;
            _configuration = configuration;
            _paymentController = paymentController;
            _lcdController = lcdController;
            _keysController = keysController;
        }

        public void Run()
        {
            while (true)
            {
                var coinAddResult = _paymentController.ReadCoinsAdded();
                var serviceKeysResult = _keysController.GetPressedKey();
                Thread.Sleep(300);
            }
        }
    }
}
