using System.IO;
using Xunit;

namespace SelfWashSystem.Tests.UnitTests
{
    public class PumpControllerTests
    {
        private readonly PumpController _testClass;
        private readonly TextWriter _mockConsoleOut;

        public PumpControllerTests()
        {
            _testClass = new PumpController(0);
            _mockConsoleOut = new StringWriter();
            System.Console.SetOut(_mockConsoleOut);
        }

        [Fact]
        public void When_pump_is_started_Then_a_correct_message_is_displayed_at_console()
        {
            _testClass.TurnOn(5);
            Assert.Equal($"Pump 0 turned on. Liquid from container 5{System.Environment.NewLine}",
                _mockConsoleOut.ToString());
        }

        [Fact]
        public void When_pump_is_stopped_Then_a_correct_message_is_displayed_at_console()
        {
            _testClass.TurnOff();
            Assert.Equal($"Pump 0 turned off{System.Environment.NewLine}",
                _mockConsoleOut.ToString());
        }
    }
}