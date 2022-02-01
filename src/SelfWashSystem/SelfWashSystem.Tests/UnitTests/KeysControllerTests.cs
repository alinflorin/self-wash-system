using Xunit;

namespace SelfWashSystem.Tests.UnitTests
{
    public class KeysControllerTests
    {
        private readonly KeysController _testClass;

        public KeysControllerTests()
        {
            _testClass = new KeysController();
        }

        [Fact]
        public void When_user_presses_a_valid_service_key_Then_key_is_saved_as_non_zero()
        {
            Program.LastKey = new System.ConsoleKeyInfo('1', System.ConsoleKey.D1, false, false, false);
            var result = _testClass.GetPressedKey();
            Assert.Equal(1, result);
        }

        [Fact]
        public void When_user_presses_an_invalid_service_key_Then_key_is_saved_as_zero()
        {
            Program.LastKey = new System.ConsoleKeyInfo('x', System.ConsoleKey.X, false, false, false);
            var result = _testClass.GetPressedKey();
            Assert.Equal(0, result);
        }
    }
}