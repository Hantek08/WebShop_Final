using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class DamPage
    {
        public static void Dam_Page_Display(out int minVal, out int maxVal)
        {
            DatabaseQuerys.Gender_Category_Menu("Dam", out minVal, out maxVal);
        }

    }
}
