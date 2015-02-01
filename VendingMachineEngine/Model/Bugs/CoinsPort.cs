using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;

namespace VendingMachineEngine.Model.Bugs
{
    public class CoinsPort
    {
        public CoinTypeEnum CoinType  { get; set; }
        public CoinValueEnum CoinValue { get; set; }
        public int Count { get; set; }
    }
}
