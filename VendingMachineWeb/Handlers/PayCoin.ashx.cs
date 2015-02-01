using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using VendingMachineEngine.Enums;
using VendingMachineEngine.Model;
using VendingMachineEngine.Model.ObjectExtentions;
using VendingMachineWeb.Managers;

namespace VendingMachineWeb.Handlers
{
    /// <summary>
    /// Summary description for PayCoin
    /// </summary>
    public class PayCoin : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            
            var coin = JsonConvert.DeserializeObject<CoinModel>(context.Request.QueryString["coin"]);
            var machine = MachineMemoryManager.Instance();
            var userBug = UserBugMemoryManager.Instance();
            bool result= userBug.InsertCoinToMachine(machine, coin);
            
            MachineMemoryManager.InsertMachine(machine);
            UserBugMemoryManager.InsertBug(userBug);
            WriteResult(context.Response, new
                {
                    Result = result,
                    UserSumRur=machine.UserSumRur
                });
            
        }
    }
}