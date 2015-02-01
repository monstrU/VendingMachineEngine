using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachineEngine.Model.VendingMachines;

namespace VendingMachineEngine.Model.ObjectExtentions
{
    public static class ListExtention
    {
        public static void AddRangeItems<T>(this IList<T> items,IList<T> ranges) where T: class
        {
            foreach (var item in ranges)
            {
                items.Add(item);
            }
        }
    }
}
