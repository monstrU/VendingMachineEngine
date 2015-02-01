using System.Web;
using VendingMachineEngine.Model.ObjectExtentions;
using VendingMachineEngine.Model.VendingMachines;

namespace VendingMachineWeb.Managers
{
    public class MachineMemoryManager
    {
        const string MemoryKey = "vmachine";

        public static VendingMachine Instance()
        {
            
            var machine=HttpContext.Current.Cache[MemoryKey] as VendingMachine;
            if (machine == null)
            {
                machine = new VendingMachine();
                HttpContext.Current.Cache.Insert(MemoryKey, machine); 
            }
            return machine;
        }


        public static void InsertMachine(VendingMachine machine)
        {
            HttpContext.Current.Cache.Insert(MemoryKey, machine);
        }
    }
}