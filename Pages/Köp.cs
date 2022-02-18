using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class Köp
    {
        public static Models.Product buffertProduct = new Models.Product();
        public static int qwantity=0;

        public static void Puting_Item_Into_Cart()
        {
            ShopingCart.Add_Product_To_Cart(buffertProduct, qwantity);
            

        }
    }
}
