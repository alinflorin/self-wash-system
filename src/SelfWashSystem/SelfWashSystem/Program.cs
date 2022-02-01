using SelfWashSystem.Abstractions.Interfaces;
using SelfWashSystem.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SelfWashSystem
{
    public class Program
    {
        public static ConsoleKeyInfo? LastKey;

        private static void ReadConsoleKey(object obj)
        {
            while (true)
            {
                LastKey = Console.ReadKey();
            }
        }

        public static async Task Main(string[] args)
        {
            // ReadKey separate thread
            new Thread(new ParameterizedThreadStart(ReadConsoleKey)).Start();



            IEnumerable<IPumpController> pumpControllers = new[] { 
                new PumpController(0),
                new PumpController(1)
            };
            var configuration = new Configuration { 
                CompanyName = "SC Car Wash SRL",
                Services = new[] { 
                    new Service(1, "SuperFoam", "", 30, 0, 0),
                    new Service(2, "Water", "", 60, 0, 1)
                }
            };
            IKeysController keysController = new KeysController();
            IPaymentController paymentController = new PaymentController();
            ILcdController lcdController = new LcdController();

            var system = new WashSystem(pumpControllers, configuration, paymentController, lcdController, keysController);
            system.Start();
            await Task.CompletedTask;
        }
    }
}