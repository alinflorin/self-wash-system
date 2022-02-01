using System.IO;
using Xunit;

namespace SelfWashSystem.Tests.UnitTests
{
    public class LcdControllerTests
    {
        private readonly TextWriter _mockConsoleOut;
        private readonly LcdController _testClass;

        public LcdControllerTests()
        {
            _testClass = new LcdController();
            _mockConsoleOut = new StringWriter();
            System.Console.SetOut(_mockConsoleOut);
        }

        [Fact]
        public void When_a_value_is_passed_to_class_Then_it_is_displayed_at_console()
        {
            _testClass.SetText("test");
            Assert.Equal($"{System.Environment.NewLine}LCD displays: test{System.Environment.NewLine}",
                _mockConsoleOut.ToString());
        }

    }
}