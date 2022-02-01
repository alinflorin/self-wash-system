using SelfWashSystem.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SelfWashSystem.Abstractions.Interfaces
{
    public abstract class AbstractWashSystem
    {
        private readonly IEnumerable<IPumpController> _pumpControllers;
        private readonly Configuration _configuration;
        private readonly IPaymentController _paymentController;
        private readonly ILcdController _lcdController;
        private readonly IKeysController _keysController;

        private uint _availableSeconds;
        private Service _selectedService;

        public AbstractWashSystem(IEnumerable<IPumpController> pumpControllers, Configuration configuration,
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
            _lcdController.SetText("Welcome to " + _configuration.CompanyName);
            while (true)
            {
                var coinAddResult = _paymentController.ReadCoinAdded();
                if (coinAddResult)
                {
                    _lcdController.SetText("Coins: " + _paymentController.GetCoins());
                    continue;
                }
                var serviceKeysResult = _keysController.GetPressedKey();
                if (serviceKeysResult > 0)
                {
                    // stop pumps
                    foreach (var pumpController in _pumpControllers)
                    {
                        pumpController.TurnOff();
                    }

                    var foundService = _configuration.Services.FirstOrDefault(x => x.KeyNumber == serviceKeysResult);
                    if (foundService == null)
                    {
                        _selectedService = null;
                        _availableSeconds = 0;
                    }
                    else
                    {
                        // service selected
                        if (_paymentController.GetCoins() == 0)
                        {
                            _lcdController.SetText("Insufficient coins");
                            continue;
                        }
                        _selectedService = foundService;
                        _lcdController.SetText("Selected Service: " + _selectedService.Name);
                        _availableSeconds = (uint)Math.Ceiling(_paymentController.GetCoins() * _selectedService.SecondsPerToken);
                        var foundPump = _pumpControllers.ElementAt(_selectedService.PumpIndex);
                        foundPump.TurnOn(_selectedService.LiquidContainerIndex);
                    }
                }
                if (_selectedService != null)
                {
                    if (_availableSeconds > 0)
                    {
                        _availableSeconds--;
                        _lcdController.SetText("Time left: " + TimeSpan.FromSeconds(_availableSeconds).ToString());
                        _paymentController.Spend(
                            1.0f / _selectedService.SecondsPerToken
                            );
                    }
                    else
                    {
                        // stop, time expired
                        foreach (var pumpController in _pumpControllers)
                        {
                            pumpController.TurnOff();
                        }
                        _selectedService = null;
                        _paymentController.Reset();
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
