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
using VendingMachineEngine.Model.VendingMachines;

namespace EngineTest
{
    [TestFixture]
    public class VendingMachineTest
    {
        [Test]
        public static void ShowCoinsInMachineBugTest()
        {
            const int oneRurCount = 100;
            const int twoRurCount = 100;
            const int fiveRurCount = 100;
            const int tenRurCount = 100;
            var machine = new VendingMachine();

            machine.InitMachine();

            var oneRurs = machine.ShowOneRublesCount();
            Assert.AreEqual(oneRurs, oneRurCount);

            var twoRurs = machine.ShowTwoRublesCount();
            Assert.AreEqual(twoRurs, twoRurCount);

            var fiveRurs = machine.ShowFiveRublesCount();
            Assert.AreEqual(fiveRurs, fiveRurCount);

            var tenRurs = machine.ShowTenRublesCount();
            Assert.AreEqual(tenRurs, tenRurCount);

        }

        [Test]
        public static void ShowTeaProductsCountTest()
        {
            const decimal teaCupPrice = 13;
            const int teaCupCount = 10;

            const decimal coffeePrice = 18;
            const int coffeeCount = 20;

            const decimal coffeeAndMilkPrice = 21;
            const int coffeeAndMilkCount = 20;

            const decimal juicePrice = 35;
            const int juiceCount = 15;

            var machine = new VendingMachine();

            machine.InitMachine();
            var teaCups = machine.TeaPort;

            Assert.AreEqual(teaCups.ProductType, ProductTypeEnum.Tea);
            Assert.AreEqual(teaCups.ProductCount, teaCupCount);
            Assert.AreEqual(teaCups.ItemPrice, teaCupPrice);

            var coffee = machine.CoffeePort;
            Assert.AreEqual(coffee.ProductType, ProductTypeEnum.Coffee);
            Assert.AreEqual(coffee.ProductCount, coffeeCount);
            Assert.AreEqual(coffee.ItemPrice, coffeePrice);

            var coffeeAndMilk = machine.CoffeeAndMilkPort;
            Assert.AreEqual(coffeeAndMilk.ProductType, ProductTypeEnum.CoffeeAndMilk);
            Assert.AreEqual(coffeeAndMilk.ProductCount, coffeeAndMilkCount);
            Assert.AreEqual(coffeeAndMilk.ItemPrice, coffeeAndMilkPrice);

            var juice = machine.JuicePort;
            Assert.AreEqual(juice.ProductType, ProductTypeEnum.Juice);
            Assert.AreEqual(juice.ProductCount, juiceCount);
            Assert.AreEqual(juice.ItemPrice, juicePrice);
        }

        [Test]
        public static void AddCounsToMachineBugTest()
        {
            var machine = new VendingMachine();

            var oneRur = new CoinModel { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            machine.AddCoinToMachine(oneRur);
            var oneCount = machine.ShowOneRublesCount();
            Assert.AreEqual(oneCount, 1);

            var twoRur = new CoinModel { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            machine.AddCoinToMachine(twoRur);
            var twoCount = machine.ShowTwoRublesCount();
            Assert.AreEqual(twoCount, 1);

            var fiveRur = new CoinModel { Value = CoinValueEnum.Five, CoinType = CoinTypeEnum.Ruble };
            machine.AddCoinToMachine(fiveRur);
            var fiveCount = machine.ShowFiveRublesCount();
            Assert.AreEqual(fiveCount, 1);

            var tenRur = new CoinModel { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };
            machine.AddCoinToMachine(tenRur);
            var tenCount = machine.ShowTenRublesCount();
            Assert.AreEqual(tenCount, 1);
        }

        [Test]
        public static void AddOneRublesFromUserToMachineTest()
        {
            var userBug = new BugModel();
            userBug.InitUserBug();
            var oneRubleCounts = userBug.OneRurPort.Count;
            var machine = new VendingMachine();
            var oneRublesMachine = machine.ShowOneRublesCount();

            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            userBug.InsertCoinToMachine(machine, oneRuble);
            Assert.AreEqual(userBug.ShowOneRublesCount(), oneRubleCounts - 1);
            Assert.AreEqual(machine.ShowOneRublesCount(), oneRublesMachine + 1);
        }

        [Test]
        public static void AddOneRublesFromUserToMachineFailedTest()
        {
            var userBug = new BugModel();
            
            var oneRubleCountsBefore = userBug.OneRurPort.Count;
            var machine = new VendingMachine();
            
            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            var result= userBug.InsertCoinToMachine(machine, oneRuble);
            
            Assert.AreEqual(oneRubleCountsBefore, 0);
            Assert.IsFalse(result);
        }


        [Test]
        public static void AddtwoRublesFromUserToMachineTest()
        {
            var userBug = new BugModel();
            userBug.InitUserBug();
            var twoRubleCounts = userBug.TwoRurPort.Count;

            var machine = new VendingMachine();
            var twoRublesMachine = machine.ShowTwoRublesCount();

            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            userBug.InsertCoinToMachine(machine, twoRuble);

            Assert.AreEqual(userBug.ShowTwoRublesCount(), twoRubleCounts - 1);
            Assert.AreEqual(machine.ShowTwoRublesCount(), twoRublesMachine + 1);
        }

        [Test]
        public static void AddtwoRublesFromUserToMachineFailedTest()
        {
            var userBug = new BugModel();

            var machine = new VendingMachine();

            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            bool result = userBug.InsertCoinToMachine(machine, twoRuble);
            Assert.IsFalse(result);

        }

        [Test]
        public static void AddWrongRublesFromUserToMachineFailedTest()
        {
            var userBug = new BugModel();
            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            userBug.AddCoin(oneRuble);

            var machine = new VendingMachine();

            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            bool result = userBug.InsertCoinToMachine(machine, twoRuble);
            Assert.IsFalse(result);

        }


        [Test]
        public static void AddMoneyFromUserToMachineAndChangeSummaryTest()
        {
            var userBug = new BugModel();
            userBug.InitUserBug();
            var twoRubleCounts = userBug.TwoRurPort.Count;

            var machine = new VendingMachine();
            var twoRublesMachine = machine.ShowTwoRublesCount();
            var userMoneyBefore = machine.UserSumRur;

            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            userBug.InsertCoinToMachine(machine, twoRuble);

            Assert.AreEqual(userBug.ShowTwoRublesCount(), twoRubleCounts - 1);
            Assert.AreEqual(machine.ShowTwoRublesCount(), twoRublesMachine + 1);

            var userMoneyAfter = machine.UserSumRur;
            Assert.AreEqual(userMoneyBefore, 0);
            Assert.AreEqual(userMoneyAfter, (int)twoRuble.Value);

        }

        [Test]
        public static void AddMoneyFromUserToMachineTest()
        {
            var userBug = new BugModel();
            userBug.InitUserBug();
            var userBugSumBefore = userBug.RublesSum();
            var machine = new VendingMachine();
            machine.InitMachine();

            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            var machineSumBefore = machine.MachineBagSum();
            var machineUserBugBefore = machine.UserSumRur;


            bool o1 = userBug.InsertCoinToMachine(machine, oneRuble);
            bool o2 = userBug.InsertCoinToMachine(machine, oneRuble);
            bool o3 = userBug.InsertCoinToMachine(machine, oneRuble);

            bool two1 = userBug.InsertCoinToMachine(machine, twoRuble);
            bool two2 = userBug.InsertCoinToMachine(machine, twoRuble);


            bool ten1 = userBug.InsertCoinToMachine(machine, tenRuble);
            bool ten2 = userBug.InsertCoinToMachine(machine, tenRuble);

            Assert.IsTrue(o1);
            Assert.IsTrue(o2);
            Assert.IsTrue(o3);

            Assert.IsTrue(two1);
            Assert.IsTrue(two2);


            Assert.IsTrue(ten1);
            Assert.IsTrue(ten2);

            const int paySumInBug = 27;
            var userSumAfter = machine.UserSumRur;
            Assert.AreEqual(userSumAfter, paySumInBug);
            Assert.AreEqual(machineUserBugBefore, 0);
            Assert.AreEqual(machine.MachineBagSum(), machineSumBefore + paySumInBug);

            Assert.AreEqual(userBug.RublesSum(), userBugSumBefore - paySumInBug);
        }

        [Test]
        public static void PayoutMoneyFromMachineTest()
        {
            var userBug = new BugModel();
            userBug.InitUserBug();

            var machine = new VendingMachine();
            machine.InitMachine();

            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            userBug.InsertCoinToMachine(machine, oneRuble);
            userBug.InsertCoinToMachine(machine, oneRuble);
            userBug.InsertCoinToMachine(machine, oneRuble);

            userBug.InsertCoinToMachine(machine, twoRuble);
            userBug.InsertCoinToMachine(machine, twoRuble);

            userBug.InsertCoinToMachine(machine, tenRuble);
            userBug.InsertCoinToMachine(machine, tenRuble);

            var userBugSumBefore = userBug.RublesSum();


            int tenRublesCountBefore = userBug.ShowTenRublesCount();
            int fiveRublesCountBefore = userBug.ShowFiveRublesCount();
            int twoRublesCountBefore = userBug.ShowTwoRublesCount();

            var machineSumBefore = machine.MachineBagSum();
            var machineUserBugBefore = machine.UserSumRur;

            machine.PayOut(userBug);

            const int paySumInBug = 27;
            var userSumAfter = machine.UserSumRur;

            Assert.AreEqual(userSumAfter, 0);
            Assert.AreEqual(machineUserBugBefore, paySumInBug);

            Assert.AreEqual(userBug.RublesSum(), userBugSumBefore + paySumInBug);
            Assert.AreEqual(machine.MachineBagSum(), machineSumBefore - paySumInBug);

            Assert.AreEqual(userBug.ShowTenRublesCount(), tenRublesCountBefore + 2);
            Assert.AreEqual(userBug.ShowFiveRublesCount(), fiveRublesCountBefore + 1);
            Assert.AreEqual(userBug.ShowTwoRublesCount(), twoRublesCountBefore + 1);
        }

        [Test]
        public static void BuyOneCoffeOkTest()
        {
            var machine = new VendingMachine();
            machine.InitMachine();


            var coffeCupsCountBefore = machine.CoffeePort.ProductCount;

            var userBug = new BugModel();
            userBug.InitUserBug();


            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            userBug.InsertCoinToMachine(machine, twoRuble);
            userBug.InsertCoinToMachine(machine, twoRuble);

            userBug.InsertCoinToMachine(machine, tenRuble);
            userBug.InsertCoinToMachine(machine, tenRuble);

            var machineUserBugSumBefore = machine.UserSumRur;

            const ProductTypeEnum itemType = ProductTypeEnum.Coffee;
            var success = machine.BuyProduct(itemType);

            Assert.IsTrue(success.Result);

            var coffeCupsCountAfter = machine.CoffeePort.ProductCount;
            Assert.AreEqual(coffeCupsCountAfter, coffeCupsCountBefore - 1);

            var userBugSumAfter = machine.UserSumRur;
            Assert.AreEqual(userBugSumAfter, machineUserBugSumBefore - machine.CoffeePort.ItemPrice);

        }

        [Test]
        public static void BuyOneCoffeFailedTest()
        {
            var machine = new VendingMachine();
            machine.InitMachine();


            var coffeCupsCountBefore = machine.CoffeePort.ProductCount;

            var userBug = new BugModel();
            userBug.InitUserBug();


            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            userBug.InsertCoinToMachine(machine, twoRuble);
            userBug.InsertCoinToMachine(machine, twoRuble);

            userBug.InsertCoinToMachine(machine, tenRuble);



            const ProductTypeEnum itemType = ProductTypeEnum.Coffee;
            var success = machine.BuyProduct(itemType);

            Assert.IsFalse(success.Result);
            Assert.AreEqual(machine.CoffeePort.ProductCount, coffeCupsCountBefore);

        }

        [Test]
        public static void BuyOneCoffeOkAndPayOutTest()
        {
            var machine = new VendingMachine();
            machine.InitMachine();


            var coffeCupsCountBefore = machine.CoffeePort.ProductCount;

            var userBug = new BugModel();
            userBug.InitUserBug();

            var oneRuble = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            userBug.InsertCoinToMachine(machine, oneRuble);

            userBug.InsertCoinToMachine(machine, twoRuble);
            userBug.InsertCoinToMachine(machine, twoRuble);

            userBug.InsertCoinToMachine(machine, tenRuble);
            userBug.InsertCoinToMachine(machine, tenRuble);

            var userBugSumBefore = userBug.RublesSum();

            const ProductTypeEnum itemType = ProductTypeEnum.Coffee;
            var success = machine.BuyProduct(itemType);
            machine.PayOut(userBug);

            Assert.IsTrue(success.Result);

            var coffeCupsCountAfter = machine.CoffeePort.ProductCount;
            Assert.AreEqual(coffeCupsCountAfter, coffeCupsCountBefore - 1);

            var userSubAfter = userBug.RublesSum();
            Assert.AreEqual(userSubAfter, userBugSumBefore + 7);
            Assert.AreEqual(machine.UserSumRur, 0);
        }

        [Test]
        [ExpectedException]
        public static void BuyOneCoffeFailedCountTest()
        {
            var machine = new VendingMachine();

            var userBug = new BugModel();
            userBug.InitUserBug();


            var twoRuble = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
            var tenRuble = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };

            userBug.InsertCoinToMachine(machine, twoRuble);
            userBug.InsertCoinToMachine(machine, twoRuble);

            userBug.InsertCoinToMachine(machine, tenRuble);
            userBug.InsertCoinToMachine(machine, tenRuble);


            const ProductTypeEnum itemType = ProductTypeEnum.Coffee;
            machine.BuyProduct(itemType);
        }

        [Test]
        public static void TryBuyOneCoffeOkTest()
        {
            var machine = new VendingMachine();
            machine.InitMachine();
            bool avaliable = machine.CoffeePort.ProductAvaliable();
            Assert.IsTrue(avaliable);

        }

        [Test]
        public static void TryBuyOneCoffeFailedTest()
        {
            var machine = new VendingMachine();
            bool avaliable = machine.CoffeePort.ProductAvaliable();
            Assert.IsFalse(avaliable);

        }
    }
}
