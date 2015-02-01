using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model.VendingMachines;

namespace VendingMachineEngine.Model.ObjectExtentions
{
    public static class MachineExtention
    {
        public static void InitMachine(this VendingMachine machine)
        {

            const int oneRurCount = 100;
            const int twoRurCount = 100;
            const int fiveRurCount = 100;
            const int tenRurCount = 100;

            var bug = new BugModel();
            bug.InitCoinsWithValues(oneRurCount, CoinValueEnum.One);
            bug.InitCoinsWithValues(twoRurCount, CoinValueEnum.Two);
            bug.InitCoinsWithValues(fiveRurCount, CoinValueEnum.Five);
            bug.InitCoinsWithValues(tenRurCount, CoinValueEnum.Ten);

            machine.InitMachineBug(bug);

            const int teaCupPrice = 13;
            const int teaCupCount = 10;
            machine.InitProductPort(ProductTypeEnum.Tea, teaCupCount, teaCupPrice);

            const int coffeePrice = 18;
            const int coffeeCount = 20;
            machine.InitProductPort(ProductTypeEnum.Coffee, coffeeCount, coffeePrice);

            const int coffeeAndMilkPrice = 21;
            const int coffeeAndMilkCount = 20;
            machine.InitProductPort(ProductTypeEnum.CoffeeAndMilk, coffeeAndMilkCount, coffeeAndMilkPrice);

            const int juicePrice = 35;
            const int juiceCount = 15;
            machine.InitProductPort(ProductTypeEnum.Juice, juiceCount, juicePrice);

        }



       
    }
}
