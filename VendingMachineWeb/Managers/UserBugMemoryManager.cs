using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VendingMachineEngine.Model;
using VendingMachineEngine.Model.ObjectExtentions;

namespace VendingMachineWeb.Managers
{
    public class UserBugMemoryManager
    {
        const string MemoryKey = "ubug";

        public static BugModel Instance()
        {
            var bug = HttpContext.Current.Cache[MemoryKey] as BugModel;
            if (bug == null)
            {
                bug = new BugModel();
                InsertBug(bug);
            }

            return bug;
        }


        public static void InsertBug(BugModel bug)
        {
            HttpContext.Current.Cache.Insert(MemoryKey, bug);
        }
    }
}