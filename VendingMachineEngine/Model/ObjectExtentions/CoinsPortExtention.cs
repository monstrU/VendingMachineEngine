using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Model.Bugs;

namespace VendingMachineEngine.Model.ObjectExtentions
{
    public static class CoinsPortExtention
    {
        public static bool PayOut(this CoinsPort port, CoinModel coin)
        {
            bool resultOk = (port.Count > 0 && (port.CoinType == coin.CoinType && port.CoinValue==coin.Value));
            if (resultOk)
            {
                port.Count--;
            }
            return resultOk;
        }
    }
}
