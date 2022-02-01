using Moq;
using SelfWashSystem.Abstractions.Interfaces;
using SelfWashSystem.Abstractions.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SelfWashSystem.Tests.UnitTests
{
    public class WashSystemTests
    {
        private readonly Mock<IPumpController> _pump0Mock;
        private readonly Mock<IPumpController> _pump1Mock;
        private readonly Mock<IPaymentController> _paymentMock;
        private readonly Mock<ILcdController> _lcdMock;
        private readonly Mock<IKeysController> _keysMock;
        private readonly Configuration _configurationMock;
        private readonly WashSystem _testClass;

        public WashSystemTests()
        {
            _pump0Mock = new Mock<IPumpController>();
            _pump1Mock = new Mock<IPumpController>();

            _configurationMock = new Configuration { 
                CompanyName = "TestCompany",
                Services = new []
                {
                    new Service
                    {
                        Description = "Foam",
                        Name = "Foam",
                        KeyNumber = 1,
                        LiquidContainerIndex = 0,
                        PumpIndex = 0,
                        SecondsPerToken = 10
                    },
                    new Service
                    {
                        Description = "Water",
                        Name = "Water",
                        KeyNumber = 2,
                        LiquidContainerIndex = 0,
                        PumpIndex = 1,
                        SecondsPerToken = 5
                    }
                }
            };

            _lcdMock = new Mock<ILcdController>();
            _paymentMock = new Mock<IPaymentController>();
            _keysMock = new Mock<IKeysController>();

            _testClass = new WashSystem(
                new[] {
                _pump0Mock.Object,
                _pump1Mock.Object
                },
                _configurationMock,
                _paymentMock.Object,
                _lcdMock.Object,
                _keysMock.Object
                );
        }

        [Fact]
        public void When_a_coin_is_added_then_system_only_displays_info_and_resets()
        {
            _paymentMock.Setup(x => x.ReadCoinAdded()).Returns(true);
            _paymentMock.Setup(x => x.GetCoins()).Returns(1);
            _testClass.ExecuteStep();
            _lcdMock.Verify(x => 
                x.SetText($"Coins: 1"), Times.Once);
            _keysMock.Verify(x => x.GetPressedKey(), Times.Never);
        }

        [Fact]
        public void When_has_sufficient_coins_and_service_key_is_pressed_Then_service_will_start()
        {
            _paymentMock.Setup(x => x.ReadCoinAdded()).Returns(false);
            _paymentMock.Setup(x => x.GetCoins()).Returns(10);
            _testClass.ExecuteStep();
            _keysMock.Verify(x => x.GetPressedKey(), Times.Once);
        }
    }
}