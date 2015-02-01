using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Enums;

namespace VendingMachineEngine.Model.VendingMachines
{
    public class ProductModel
    {
        public ProductTypeEnum ProductType { get; set; }
        public decimal Cost { get; set; }
    }
}
