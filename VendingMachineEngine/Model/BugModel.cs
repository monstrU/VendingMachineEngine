using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model.Bugs;

namespace VendingMachineEngine.Model
{
    public class BugModel
    {
        public CoinsPort OneRurPort { get; private set; }
        public CoinsPort TwoRurPort { get; private set; }
        public CoinsPort FiveRurPort { get; private set; }
        public CoinsPort TenRurPort { get; private set; }

        public BugModel()
        {
            OneRurPort = new CoinsPort() { CoinValue = CoinValueEnum.One };
            TwoRurPort = new CoinsPort() { CoinValue = CoinValueEnum.Two };
            FiveRurPort = new CoinsPort() { CoinValue = CoinValueEnum.Five };
            TenRurPort = new CoinsPort() { CoinValue = CoinValueEnum.Ten };


        }

        public void AddCoin(CoinModel coin)
        {
            var coinPort = GetPortCoin(coin.Value);
            coinPort.Count++;
        }

        public int ShowOneRublesCount()
        {
            return OneRurPort.Count;
        }

        public int ShowTwoRublesCount()
        {
            return TwoRurPort.Count;
        }

        public int ShowFiveRublesCount()
        {
            return FiveRurPort.Count;
        }

        public int ShowTenRublesCount()
        {
            return TenRurPort.Count;
        }

        public CoinsPort GetPortCoin(CoinValueEnum coinValue)
        {
            var result = new CoinsPort();
            switch (coinValue)
            {
                case CoinValueEnum.One:
                    result = OneRurPort;
                    break;
                case CoinValueEnum.Two:
                    result = TwoRurPort;
                    break;
                case CoinValueEnum.Five:
                    result = FiveRurPort;
                    break;
                case CoinValueEnum.Ten:
                    result = TenRurPort;
                    break;
            }
            if (result.CoinValue != coinValue)
            {
                throw new Exception("Данный тип монет не поддерживается.");
            }
            return result;
        }

        public int RublesSum()
        {
            return (int)OneRurPort.CoinValue * OneRurPort.Count 
                + (int)TwoRurPort.CoinValue * TwoRurPort.Count
                + (int)FiveRurPort.CoinValue * FiveRurPort.Count
                + (int)TenRurPort.CoinValue * TenRurPort.Count;
        }

        public void RemoveCoin(CoinModel coin, int countC)
        {
            var port = GetPortCoin(coin.Value);
            port.Count -= countC;
        }

        public void AddCoin(CoinModel coin, int countC)
        {
            var port = GetPortCoin(coin.Value);
            port.Count += countC;
        }
    }
}
