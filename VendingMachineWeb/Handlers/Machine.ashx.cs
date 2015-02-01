using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineEngine.Enums;
using VendingMachineWeb.Managers;

namespace VendingMachineWeb.Handlers
{
    /// <summary>
    /// Summary description for Machine
    /// </summary>
    public class Machine : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            var productType = (ProductTypeEnum)Convert.ToInt32(context.Request.QueryString["productType"]);
            var machine= MachineMemoryManager.Instance();
            var result= machine.BuyProduct(productType);
            MachineMemoryManager.InsertMachine(machine);
            var port = machine.GetPortForProduct(productType);
            WriteResult(context.Response, new
            {
                Result = result.Result,
                Message = result.Message,
                UserSumRur = machine.UserSumRur,
                ProductCount=port.ProductCount
            });

        }
        
    }
}