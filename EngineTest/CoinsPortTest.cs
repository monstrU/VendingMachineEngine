using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model;
using VendingMachineEngine.Model.Bugs;
using VendingMachineEngine.Model.ObjectExtentions;

namespace EngineTest
{
    [TestFixture]
    public class CoinsPortTest
    {
        [Test]
        public static void PayoutCoinsOkTest()
        {
            const int coinsCount = 3;
            var port = new CoinsPort()
            {
                CoinType = CoinTypeEnum.Ruble,
                CoinValue = CoinValueEnum.One,
                Count = coinsCount
            };
            var oneRuble = new CoinModel
            {
                CoinType = CoinTypeEnum.Ruble,
                Value = CoinValueEnum.One
            };
            bool isSuccress = port.PayOut(oneRuble);
            Assert.IsTrue(isSuccress);
            Assert.AreEqual(port.Count, coinsCount - 1);

        }

        [Test]
        public static void PayoutCoinsFailed1Test()
        {
            const int coinsCount = 0;
            var port = new CoinsPort()
            {
                CoinType = CoinTypeEnum.Ruble,
                CoinValue = CoinValueEnum.One,
                Count = coinsCount
            };
            var oneRuble = new CoinModel
            {
                CoinType = CoinTypeEnum.Ruble,
                Value = CoinValueEnum.One
            };
            bool isSuccress = port.PayOut(oneRuble);
            Assert.IsFalse(isSuccress);
            Assert.AreEqual(port.Count, coinsCount);

        }

        [Test]
        public static void PayoutCoinsFailed2Test()
        {
            const int coinsCount = 2;
            var port = new CoinsPort()
            {
                CoinType = CoinTypeEnum.Ruble,
                CoinValue = CoinValueEnum.Two,
                Count = coinsCount
            };
            var oneRuble = new CoinModel
            {
                CoinType = CoinTypeEnum.Ruble,
                Value = CoinValueEnum.One
            };
            bool isSuccress = port.PayOut(oneRuble);
            Assert.IsFalse(isSuccress);
            Assert.AreEqual(port.Count, coinsCount);

        }
    }
}
