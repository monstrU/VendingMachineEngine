using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;

namespace VendingMachineEngine.Model
{
    public class CoinModel
    {
        public CoinValueEnum Value { get; set; }
        public CoinTypeEnum CoinType { get; set; }
    }
}
