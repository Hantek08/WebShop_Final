using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class AllaPage
    {
        public static void Get_All_Products(int menuSel, out int minVal, out int maxVal)
        {
            DatabaseQuerys.Get_All_Products(menuSel, out minVal, out maxVal);
        }

    }
}
