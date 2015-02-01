using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineWeb.Managers;

namespace VendingMachineWeb.Handlers
{
    /// <summary>
    /// Summary description for MachinePayout
    /// </summary>
    public class MachinePayout : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            var machine = MachineMemoryManager.Instance();
            var userBug = UserBugMemoryManager.Instance();

            machine.PayOut(userBug);
            MachineMemoryManager.InsertMachine(machine);
            UserBugMemoryManager.InsertBug(userBug);
            WriteResult(context.Response,  new
            {
                Result = true,
                UserBug = userBug
            });
        }
    }
}