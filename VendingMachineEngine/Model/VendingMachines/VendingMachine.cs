using System;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model.Messages;

namespace VendingMachineEngine.Model.VendingMachines
{
    public class VendingMachine
    {
        protected BugModel MachineBug { get; set; }
        public int UserSumRur { get; protected set; }

        public ProductPortModel TeaPort { get; protected set; }
        public ProductPortModel CoffeePort { get; protected set; }
        public ProductPortModel CoffeeAndMilkPort { get; protected set; }
        public ProductPortModel JuicePort { get; protected set; }



        public VendingMachine()
        {
            MachineBug = new BugModel();

            TeaPort = new ProductPortModel() { ProductType = ProductTypeEnum.Tea };
            CoffeePort = new ProductPortModel() { ProductType = ProductTypeEnum.Coffee };
            CoffeeAndMilkPort = new ProductPortModel() { ProductType = ProductTypeEnum.CoffeeAndMilk };
            JuicePort = new ProductPortModel() { ProductType = ProductTypeEnum.Juice };
        }

        protected internal void InitMachineBug(BugModel bug)
        {
            MachineBug = bug;
        }

        public void InitProductPort(ProductTypeEnum productType, int productCount, int price)
        {
            var port = GetPortForProduct(productType);
            if (port.ProductType != productType)
            {
                throw new Exception("Машина не поддерживает данный тип товара");
            }
            port.ProductCount = productCount;
            port.ItemPrice = price;
        }

        public ProductPortModel GetPortForProduct(ProductTypeEnum productType)
        {
            var result = new ProductPortModel();
            switch (productType)
            {
                case ProductTypeEnum.Tea:
                    result = TeaPort;
                    break;
                case ProductTypeEnum.Coffee:
                    result = CoffeePort;
                    break;
                case ProductTypeEnum.CoffeeAndMilk:
                    result = CoffeeAndMilkPort;
                    break;
                case ProductTypeEnum.Juice:
                    result = JuicePort;
                    break;
            }
            return result;
        }

        public void AddCoinToMachine(CoinModel coin)
        {
            MachineBug.AddCoin(coin);
            UserSumRur += (int)coin.Value;
        }

        public void RemoveCoinFromMachine(CoinModel coin, int count)
        {
            MachineBug.RemoveCoin(coin, count);
            UserSumRur -= (int)coin.Value * count;
        }

        public int ShowOneRublesCount()
        {
            return MachineBug.OneRurPort.Count;
        }

        public int ShowTwoRublesCount()
        {
            return MachineBug.TwoRurPort.Count;
        }

        public int ShowFiveRublesCount()
        {
            return MachineBug.FiveRurPort.Count;
        }

        public int ShowTenRublesCount()
        {
            return MachineBug.TenRurPort.Count;
        }

        public int MachineBagSum()
        {
            return MachineBug.RublesSum();
        }

        public OperationMessage BuyProduct(ProductTypeEnum itemType)
        {
            var port = GetPortForProduct(itemType);
            if (port.ProductCount == 0)
            {
                throw new Exception("В кофе-машину не загружен запрошенный продукт.");
            }
            
            var message = new OperationMessage();
            if (port.ItemPrice <= UserSumRur)
            {
                port.ProductCount--;
                UserSumRur -= port.ItemPrice;
                message.Result = true;
            }
            else
            {
                message.Result = false;
                message.Message = string.Format("Внесенной суммы в {0} рублей недостаточно для покупки товара стоимостью {1} рублей."
                    , UserSumRur
                    , port.ItemPrice);
            }
            return message;
        }

        private int PayOutCoin(BugModel userBug, CoinModel coin, int payOutSum)
        {
            var coinValue = (int)coin.Value;
            int calcOutSum = 0;
            if (payOutSum >= coinValue)
            {
                var countCoins = payOutSum / coinValue;
                if (coinValue * countCoins <= payOutSum)
                {
                    this.RemoveCoinFromMachine(coin, countCoins);
                    userBug.AddCoin(coin, countCoins);
                    calcOutSum = coinValue * countCoins;
                }
            }
            return calcOutSum;
        }

        public void PayOut(BugModel userBug)
        {
            int payOutSum = this.UserSumRur;
            var coin = new CoinModel() { Value = CoinValueEnum.Ten, CoinType = CoinTypeEnum.Ruble };
            payOutSum -= this.PayOutCoin(userBug, coin, payOutSum);
            if (payOutSum > 0)
            {
                coin = new CoinModel() { Value = CoinValueEnum.Five, CoinType = CoinTypeEnum.Ruble };
                payOutSum -= this.PayOutCoin(userBug, coin, payOutSum);
            }
            if (payOutSum > 0)
            {
                coin = new CoinModel() { Value = CoinValueEnum.Two, CoinType = CoinTypeEnum.Ruble };
                payOutSum -= this.PayOutCoin(userBug, coin, payOutSum);
            }
            if (payOutSum > 0)
            {
                coin = new CoinModel() { Value = CoinValueEnum.One, CoinType = CoinTypeEnum.Ruble };
                payOutSum -= this.PayOutCoin(userBug, coin, payOutSum);
            }
            if (payOutSum != 0)
            {
                throw new Exception("Не удалось выдать запрошенную сумму.");
            }
        }
    }
}
