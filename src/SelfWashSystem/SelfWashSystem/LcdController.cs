using SelfWashSystem.Abstractions.Interfaces;
using System;

namespace SelfWashSystem
{
    public class LcdController : ILcdController
    {
        private string _currentText;

        public void SetText(string text)
        {
            _currentText = text;
            Console.WriteLine($"\r\nLCD displays: {_currentText}"); // in reality, we would pass this through serial to the actual LCD
        }
    }
}
