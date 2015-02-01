using System;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model.VendingMachines;

namespace VendingMachineEngine.Model.ObjectExtentions
{
    public static class BugExtention
    {
        public static void InitUserBug(this BugModel bug)
        {
            if (bug == null)
            {
                throw new Exception("Необходимо инициализировать кошелек пользователя.");
            }
            const int oneRurCount = 10;
            const int twoRurCount = 30;
            const int fiveRurCount = 20;
            const int tenRurCount = 15;

            bug.InitCoinsWithValues(oneRurCount, CoinValueEnum.One);
            bug.InitCoinsWithValues(twoRurCount, CoinValueEnum.Two);
            bug.InitCoinsWithValues(fiveRurCount, CoinValueEnum.Five);
            bug.InitCoinsWithValues(tenRurCount, CoinValueEnum.Ten);

        }

        public static void InitCoinsWithValues(this BugModel bug, int oneRurCount, CoinValueEnum coinValue)
        {
            for (var c = 0; c < oneRurCount; c++)
            {
                bug.AddCoin(new CoinModel { CoinType = CoinTypeEnum.Ruble, Value = coinValue });
            }
        }

        public static bool InsertCoinToMachine(this BugModel bug, VendingMachine machine, CoinModel coin)
        {
            bool result = false;
            var coinPort = bug.GetPortCoin(coin.Value);
            if (coinPort.PayOut(coin))
            {
                machine.AddCoinToMachine(coin);
                result = true;
            }
            return result;
        }

        /*public static int Rubles(this BugModel bug)
        {
            return bug.ShowOneRublesCount() + bug.ShowTwoRublesCount() + bug.ShowFiveRublesCount() + bug.ShowTwoRublesCount();
        }*/
    }
}
