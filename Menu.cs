using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace WebShop_Final
{
    internal class Menu
    {
        public static int exitVal = 0;
        public static int menuRange = 0;
        public static bool exit = false;
        public static int placeHolder = 0;
        public static int idBuffer = 0;

        public static void MainMenu()
        {
            
            var menuSel = 0;
            // This is the maintitle method
            MainPage.FronPage();


            do
            {

                //displaying the main menu , with SHOP, ADMIN och EXIT choises!
                MainPage.MainPageDisplay();
                menuSel = Menu_Selector(1, 3);
                MainPage.MainPageSwitch(menuSel);

            } while (!exit); exit = false;
            //(menuSel != exitVal);

            Console.WriteLine("Hejdå, välkommen tillbaka när du har mer pengar att slänga på oss!");

        }



        #region SHOP DEPARTMENT
        public static void UserMenu()
        {
            var table = new Table();
            var menuSel = 0;

            var ja_Nej = "";
            table.SetHeaders("Välj ett konto.");
            Console.Clear();
            Console.WriteLine(table.ToString());
            do
            {
                //Thread.Sleep(2000);
                UserPage.User_Page_Display(out int minVal, out int maxVal);

                menuSel = Menu_Selector(minVal, maxVal);
                UserPage.User_Page_Choise(menuSel, out ja_Nej);


            } while (!exit); exit = false;

        }

        public static void ShopMenu()
        {
            var menuSel = 0;
            do
            {

                Console.Clear();
                ShopPage.Shop_Page_Display();
                menuSel = Menu_Selector(1, 6);
                ShopPage.Shop_Page_Switch(menuSel);


            } while (!exit); exit = false;
            //(menuSel != exitVal);

        }

        public static void AllMenu()
        {
            var menuSel = 0;
            var minVal = 0;
            var maxVal = 0;
            do
            {
                Console.Clear();
                AllaPage.Get_All_Products(menuSel, out minVal, out maxVal);
                menuSel = Menu_Selector(minVal, maxVal);
                if (!exit)
                {
                    Single_Out_Product_From_All_Menu(menuSel);
                }


            } while (!exit); exit = false;
            //(menuSel != maxVal || menuSel == 0);
        }

        public static void Single_Out_Product_From_All_Menu(int menuSel)
        {
            var prodId = 0;
            var minVal = 0;
            var maxVal = 0;
            do
            {
                Console.Clear();
                prodId = DatabaseQuerys.Single_Out_From_All_Products(menuSel, out minVal, out maxVal);
                ProductInfo(prodId);
                menuSel = Menu_Selector(minVal, maxVal);
                if (menuSel == maxVal - 1)
                {
                    Buy_Selecte_Item(prodId);
                }


            } while (!exit); exit = false;
        }
        public static void DamMenu()
        {
            var minVal = 0;
            var maxVal = 0;
            var menuSel = 0;
            do
            {
                Console.Clear();

                DamPage.Dam_Page_Display(out minVal, out maxVal);
                menuSel = Menu_Selector(minVal, maxVal);
                if (!exit)
                {
                    Products_Select_Menu(1, menuSel);
                }


            } while (!exit); exit = false;



        }

        public static void HerrMenu()
        {
            var minVal = 0;
            var maxVal = 0;
            var menuSel = 0;
            do
            {
                Console.Clear();
                HerrPage.Herr_Page_Display(out minVal, out maxVal);
                menuSel = Menu_Selector(minVal, maxVal);
                if (!exit)
                {
                    Products_Select_Menu(2, menuSel);
                }


            } while (!exit); exit = false;
        }

        public static void Products_Select_Menu(int gender, int menuSelDisplay)
        {
            var minVal = 0;
            var maxVal = 0;
            do
            {
                Console.Clear();
                ProductsPage.Category_Product_Filter(gender, menuSelDisplay, out minVal, out maxVal);
                placeHolder = menuSelDisplay;
                var menuSel = Menu_Selector(minVal, maxVal);

                if (menuSel == maxVal - 1)
                {
                    //BuySelecteeItem();
                }
                if (!exit)
                {
                    Single_Out_A_Product_By_Gender_And_SubCategory(gender, menuSel, placeHolder);
                }



            } while (!exit); exit = false;

        }

        public static void Single_Out_A_Product_By_Gender_And_SubCategory(int gender, int menuSelDisplay, int placeHolder)
        {
            var minVal = 0;
            var maxVal = 0;
            do
            {
                Console.Clear();
                int prodId = DatabaseQuerys.Singleing_Out_A_Product_By_Gender_And_SubCategory(gender, menuSelDisplay, placeHolder, out minVal, out maxVal);

                ProductInfo(prodId);

                var menuSel = Menu_Selector(minVal, maxVal);

                if (menuSel == maxVal - 1)
                {
                    Buy_Selecte_Item(prodId);

                }
            } while (!exit); exit = false;
        }
        public static void Shoping_Cart_Menu()
        {
            var minVal = 0;
            var maxVal = 0;
            var menuSel = 0;
            do
            {
                Console.Clear();
                DatabaseQuerys.Shopping_Cart_Menu(out minVal, out maxVal);
                menuSel = Menu_Selector(minVal, maxVal);
                if (menuSel == maxVal-2)
                {
                    DeleteCartItem();
                }
                if (menuSel == maxVal-1)
                {
                    ShopingCart.Checkout_And_Clearing_the_Cart();
                }


            } while (!exit); exit = false;
        }

        public static void DeleteCartItem()
        {
            var menuSel = 0;
            var minVal = 0;
            var maxVal = 0;
            do
            {
                Console.Clear();
                ShopingCart.DeleteCartItemDisplay(menuSel, out minVal, out maxVal);
                menuSel = Menu_Selector(minVal, maxVal);
                if (!exit)
                {
                    ShopingCart.DeleteCartItem(menuSel);
                    exit = true;
                }


            } while (!exit); exit = false;

        }
        public static void Product_Info(int id)
        {
            var table = new Table();
            var table2 = new Table();

            try
            {
                

                    var product = DatabaseDapper.GetProductById(id);

                var text = product.Description;

                if (product != null)
                {
                    table.SetHeaders("Produkt Information");
                    table.AddRow();
                    table.AddRow($"Produkt Id", $"Leverantör", $"SubKategori", $"Pris", $"I Lager", $"Storlek", $"Färg");
                    table.AddRow($"{product.Id} ", $"{product.SupplierId}", $"{product.SubCategoryId}", $"{product.UnitPrice}", $"{product.UnitInStock}", $"{product.Size}", $"{product.Color}");
                    table2.AddRow("Beskrivning");

                }
                else
                    Console.WriteLine("Product Record Doesn't Exist");


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(table.ToString());

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(table2.ToString());
                Console.WriteLine(Tools.TextWraping.WrapIt(text));

                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        public static void ProductInfo(int id)
        {
            var table = new Table();
            var table2 = new Table();
            try
            {
                using (var db = new Models.WebshopContext())
                {
                    var prod = db.Products.Where(p => p.Id == id).ToList().GroupJoin(db.SubCategories.ToList()
                        , p => p.SubCategoryId, sub => sub.Id, (p, sub) => new { p, sub }).GroupJoin(db.Suppliers.ToList(), p => p.p.SupplierId, sup => sup.Id, (p, sup) => new { p, sup }).ToList();

                    var text = prod[0].p.p.Description;

                    if (prod != null)
                    {
                        table.SetHeaders("Produkt Information");
                        table.AddRow();
                        table.AddRow($"Produkt Id", $"Leverantör", $"SubKategori", $"Pris", $"I Lager", $"Storlek", $"Färg");
                        table.AddRow($"{prod[0].p.p.Id} ", $"{prod[0].p.p.Supplier.Name}", $"{prod[0].p.p.SubCategory.SubCategoryName}", $"{prod[0].p.p.UnitPrice}", $"{prod[0].p.p.UnitInStock}", $"{prod[0].p.p.Size}", $"{prod[0].p.p.Color}");
                        table2.AddRow("Beskrivning");

                    }
                    else
                        Console.WriteLine("Product Record Doesn't Exist");


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(table.ToString());

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(table2.ToString());
                    Console.WriteLine(Tools.TextWraping.WrapIt(text));

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Buy_Selecte_Item(int itemId)
        {
            var table = new Table();
            table.AddRow("Hur många vill du köpa?");
            Console.WriteLine(table.ToString());
            Köp.qwantity = Qwantity_Check(itemId);
            DatabaseQuerys.BuyItem(itemId);
            Köp.Puting_Item_Into_Cart();
            table.ClearRows();
            table.AddRow($"Varan är nu i kundvagnen");
            Console.WriteLine(table.ToString());
            Console.WriteLine(@$"   _
    \________
 ~   \######/       
  ~   |####/
 ~    |____.
______o____o__________");
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        public static void Shipment_Menu(out int shipId)
        {
            shipId=0;
            do
            {
                Console.Clear();
                DatabaseQuerys.Choosing_Shipment(out int minVal, out int maxVal);
                var menuSel = Menu_Selector(minVal, maxVal);
                if (menuSel != maxVal)
                {
                    DatabaseQuerys.Single_Out_Shipper(menuSel,out shipId);
                    exit=true;
                }


            } while (!exit); exit = false;
        }

        public static void Payment_Menu(out int payId)
        {
            payId = 0;
            do
            {
                Console.Clear();
                DatabaseQuerys.Choosing_Pay_Method(out int minVal, out int maxVal);
                var menuSel = Menu_Selector(minVal, maxVal);
                if (menuSel != maxVal)
                {
                    DatabaseQuerys.Single_Out_Pay_Method(menuSel,out payId);
                    exit = true;
                }


            } while (!exit); exit = false;
        }

        public static int Qwantity_Check(int prodId)
        {
            var validateVal = false;
            int qvantitet;
            do
            {

                var tryParce = (int.TryParse(Console.ReadLine(), out qvantitet));

                if (tryParce == true && (qvantitet > 0 && qvantitet <= DatabaseQuerys.Qwant_Check(prodId)))
                {
                    validateVal = true;
                }
                else
                {
                    var table = new Table();
                    table.SetHeaders(StringExtensions.CenterString($"Du kan max köpa {DatabaseQuerys.Qwant_Check(prodId)} st av denna vara.".ToUpper(), 40));

                    table.AddRow(StringExtensions.CenterString("Välj igen, tack".ToUpper(), 40));

                    Console.Clear();
                    Console.WriteLine(table.ToString());
                    //Thread.Sleep(2000);

                }


            } while (validateVal != true);
            return qvantitet;
        }

        #endregion

        #region ADMIN DEPARTMENT

        public static void AdminLogin()
        {
            var table = new Table();
            var menuSel = 0;
            var minVal = 0;
            var maxVal = 0;
            var ja_Nej = "";
            table.SetHeaders("Välj admin konto.");
            Console.Clear();
            Console.WriteLine(table.ToString());
            do
            {
                //Thread.Sleep(2000);
                AdminPage.Admin_Login_Display(out minVal, out maxVal);

                menuSel = Menu_Selector(minVal, maxVal);
                AdminPage.Admin_Login_Choise(menuSel, out ja_Nej);


            } while (!exit); exit = false;

        }

        public static void AdminMenu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Admin_Page_Display();
                menuSel = Menu_Selector(1, 6);
                AdminPage.Admin_Page_Switch(menuSel);


            } while (!exit);exit = false;

        }

        public static void Prod_Handling_Menu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Prod_Handling_Display();
                menuSel = Menu_Selector(1, 6);
                AdminPage.Prod_Handling_Switch(menuSel);


            } while (!exit); exit = false;
        }

        public static void Search_Prod_Menu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Search_Prod_Display();
                menuSel = Menu_Selector(1, 4);
                AdminPage.Search_Prod_Switch(menuSel);


            } while (!exit); exit = false;
        }

        public static void Cate_Handling_Menu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Categori_Handling_Display();
                menuSel = Menu_Selector(1, 5);
                AdminPage.Category_Handling_Switch(menuSel);


            } while (!exit); exit = false;
        }

        public static void Brand_Handling_Menu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Brand_Handling_Display();
                menuSel = Menu_Selector(1, 5);
                AdminPage.Brand_Handling_Switch(menuSel);


            } while (!exit); exit = false;
        }

        public static void User_HandlingMenu()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.User_Handling_Display();
                menuSel = Menu_Selector(1, 4);
                AdminPage.USer_Handling_Switch(menuSel);


            } while (menuSel != exitVal);
        }

        public static void Statistics()
        {
            var menuSel = 0;
            do
            {
                Console.Clear();
                AdminPage.Statistics_Display();
                menuSel = Menu_Selector(1, 12);
                AdminPage.Statistics_Switch(menuSel);


            } while (!exit); exit = false;
        }
        #endregion

        #region MENU TOOLS
        public static int Menu_Selector(int minVal, int maxVal)
        {
            exitVal = maxVal;
            int menuSel;
            bool validSelection = false;
            do
            {
                var tryParce = (int.TryParse(AwaitingInputDisplay.FlashyInput(), out menuSel) && menuSel >= minVal && menuSel <= maxVal);

                if (tryParce == true)
                {
                    validSelection = true;

                }
                else if (tryParce == false || menuSel == maxVal || menuSel == 0 || menuSel > maxVal)
                {
                    var table = new Table();
                    table.SetHeaders(StringExtensions.CenterString("Fel inmatning".ToUpper(), 40));
                    table.AddRow(StringExtensions.CenterString($"Välj mellan {minVal} och {maxVal - 1}, tryck på {maxVal} för att återvända.".ToUpper(), 40));
                    //Console.Clear();
                    Console.WriteLine(table.ToString());
                    //Thread.Sleep(2000);

                }

            } while (!validSelection);
            if (menuSel == maxVal || menuSel == 0 || menuSel > maxVal)
                exit = true;
            return menuSel;
        }

        public static string JA_Nej_Selector(string input, int menuSel)
        {
            var table = new Table();

            bool validSelection = false;
            do
            {
                if (input.ToUpper() == "JA")
                {
                    validSelection = true;
                    UserPage.User_Admin_Deligation(menuSel);
                    Menu.exit = true;
                }
                else if (input.ToUpper() == "NEJ")
                {
                    Console.Clear();
                    validSelection = true;
                    table.SetHeaders("Välj igen!");
                    Console.WriteLine(table.ToString());
                    Thread.Sleep(1000);
                    Console.Clear();

                }
                else
                {
                    table.SetHeaders(StringExtensions.CenterString("Fel inmatning".ToUpper(), 40));
                    table.AddRow(StringExtensions.CenterString("Välj igen, tack".ToUpper(), 40));

                    Console.WriteLine(table.ToString());
                    Thread.Sleep(2000);
                    break;
                }

            } while (!validSelection);
            return input;
        }
        #endregion
    }
}
