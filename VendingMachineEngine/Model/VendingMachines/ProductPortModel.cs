using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;

namespace VendingMachineEngine.Model.VendingMachines
{
    public class ProductPortModel
    {
        public ProductTypeEnum ProductType { get; set; }
        public int ProductCount { get; set; }
        public int ItemPrice { get; set; }


        public bool ProductAvaliable()
        {
            return ProductCount != 0;
        }
    }
}
