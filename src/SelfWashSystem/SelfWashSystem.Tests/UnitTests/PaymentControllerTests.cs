using Xunit;

namespace SelfWashSystem.Tests.UnitTests
{
    public class PaymentControllerTests
    {
        private readonly PaymentController _testClass;

        public PaymentControllerTests()
        {
            _testClass = new PaymentController();
        }

        [Fact]
        public void When_pressing_C_Then_the_number_of_coins_is_incremented_by_one()
        {
            Program.LastKey = new System.ConsoleKeyInfo('c', System.ConsoleKey.C, false, false, false);
            var result = _testClass.ReadCoinAdded();
            Assert.True(result);
            Assert.Equal(1, _testClass.GetCoins());
        }

        [Fact]
        public void When_spending_coins_Then_the_number_of_coins_is_changed_accordingly()
        {
            Program.LastKey = new System.ConsoleKeyInfo('c', System.ConsoleKey.C, false, false, false);
            _testClass.ReadCoinAdded();
            Program.LastKey = new System.ConsoleKeyInfo('c', System.ConsoleKey.C, false, false, false);
            _testClass.ReadCoinAdded();
            _testClass.Spend(0.1f);
            Assert.Equal(1.9f, _testClass.GetCoins());
        }

        [Fact]
        public void When_reset_Then_the_number_of_coins_is_changed_to_zero()
        {
            Program.LastKey = new System.ConsoleKeyInfo('c', System.ConsoleKey.C, false, false, false);
            _testClass.ReadCoinAdded();
            Program.LastKey = new System.ConsoleKeyInfo('c', System.ConsoleKey.C, false, false, false);
            _testClass.ReadCoinAdded();
            _testClass.Reset();
            Assert.Equal(0, _testClass.GetCoins());
        }
    }
}