using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using VendingMachineEngine.Model;
using VendingMachineEngine.Model.ObjectExtentions;
using VendingMachineEngine.Model.VendingMachines;
using VendingMachineWeb.Managers;

namespace VendingMachineWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitUserBug();
                InitMachine();
            }
        }

        

        private void InitUserBug()
        {
            var bug = new BugModel();
            bug.InitUserBug();
            UserBugMemoryManager.InsertBug(bug);
        }

        private void InitMachine()
        {
            var machine = new VendingMachine();
            machine.InitMachine();
            MachineMemoryManager.InsertMachine(machine);
        }

        protected string WriteMachineToJs()
        {
            return JsonConvert.SerializeObject(MachineMemoryManager.Instance(), Formatting.Indented);
        }

        protected string WriteUserBugToJs()
        {
            return JsonConvert.SerializeObject(UserBugMemoryManager.Instance(), Formatting.Indented);
        }
    }
}