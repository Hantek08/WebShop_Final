using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class ProductsPage
    {
        public static void Category_Product_Filter(int gender,int menuSel, out int minVal, out int maxVal)
        {
            DatabaseQuerys.Gender_Category_Product_Select(gender,menuSel,out minVal, out maxVal);

        }
    }
}
