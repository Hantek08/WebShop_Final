using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebShop_Final
{
    class ShopPage
    {
        public static Models.OrderDetail shopingCart = new Models.OrderDetail();
        public static void Shop_Page_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- BUTIK ---", 20));
            table.AddRow("1.", StringExtensions.CenterString("DAM", 20));
            table.AddRow("2.", StringExtensions.CenterString("HERR", 20));
            table.AddRow("3.", StringExtensions.CenterString("ALLA", 20));
            table.AddRow("4.", StringExtensions.CenterString("VARUKORG", 20));
            table.AddRow("5.", StringExtensions.CenterString("SÖK", 20));
            table.AddRow("6.", StringExtensions.CenterString("TILLBAKA", 20));
            Console.WriteLine(table.ToString());

        }

        public static void Shop_Page_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    Menu.DamMenu();
                    break;
                case 2:
                    Menu.HerrMenu();
                    break;
                case 3:
                    Menu.AllMenu();
                    
                    break;
                case 4:
                    Menu.Shoping_Cart_Menu();
                    
                    break;
                case 5:
                    SearchPage.Search();
                    
                    break;
                case 6:
                    break;

            }
        }
    }
}
