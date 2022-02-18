using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebShop_Final
{
    class MainPage
    {

        public static void FronPage()
        {
            var table = new Table();

            table.SetHeaders("Välkommen till vår butik.");
            Console.WriteLine(table.ToString());
            Thread.Sleep(3000);
            
        }
        /// <summary>
        /// This wrights out the main menu page
        /// </summary>
        public static void MainPageDisplay()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- HUVUDMENY ---", 20));
            table.AddRow("1.", StringExtensions.CenterString("BUTIK", 20));
            table.AddRow("2.", StringExtensions.CenterString("ADMIN", 20));
            table.AddRow("3.", StringExtensions.CenterString("LÄMNA", 20));
            Console.WriteLine(table.ToString());
        }

        /// <summary>
        /// Takes the tryParce input and runs it trough the switch
        /// </summary>
        /// <param name="menuSel"></param>
        public static void MainPageSwitch(int menuSel)
        {
            var table = new Table();
            switch (menuSel)
            {
                case 1:
                    {
                        if (UserPage.mainUser.Username == null)
                        {
                            Menu.UserMenu();
                        }

                        if (UserPage.mainUser.Username != null)
                        {
                            Console.Clear();
                            table.SetHeaders($"Välkommen {UserPage.mainUser.FirstName} {UserPage.mainUser.LastName}");
                            Console.WriteLine(table.ToString());
                            Thread.Sleep(2000);

                            Menu.ShopMenu();
                        }

                    }

                    break;
                case 2:
                    {
                        if (AdminPage.mainAdmin.Username == null)
                        {
                            Menu.AdminLogin();
                        }

                        if (UserPage.mainUser.Username != null)
                        {
                            Console.Clear();
                            table.SetHeaders($"Välkommen {UserPage.mainUser.FirstName} {UserPage.mainUser.LastName}");
                            Console.WriteLine(table.ToString());
                            Thread.Sleep(2000);

                            Menu.AdminMenu();
                        }
                    }
                    break;

                case 3:
                    break;
            }
        }

    }
}
