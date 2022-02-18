using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class AdminPage
    {
        public static Models.User mainAdmin = new Models.User();
        public static void Main_Admin(Models.User admin)
        {
            mainAdmin = admin;
        }

        public static void Admin_Login_Display(out int minVal, out int maxVal)
        {
            DatabaseQuerys.Admin_List_Menu(out minVal, out maxVal);
        }

        public static void Admin_Login_Choise(int menuSel, out string ja_Nej)
        {
            DatabaseQuerys.Admin_List_Choise(menuSel, out ja_Nej);
        }

        public static void Admin_Page_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- ADMIN ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("PRODUKTHANTERING", 30));
            table.AddRow("2.", StringExtensions.CenterString("KATEGORIHANTERING", 30));
            table.AddRow("3.", StringExtensions.CenterString("LEVERANTÖRSHANTERING", 30));
            table.AddRow("4.", StringExtensions.CenterString("KUNDÖVERSIKT", 30));
            table.AddRow("5.", StringExtensions.CenterString("STATISTIK", 30));
            table.AddRow("6.", StringExtensions.CenterString("TILLBAKA", 30));
            Console.WriteLine(table.ToString());

        }

        public static void Admin_Page_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    Menu.Prod_Handling_Menu();
                    break;
                case 2:
                    Menu.Cate_Handling_Menu();
                    break;
                case 3:
                    Menu.Brand_Handling_Menu();
                    break;
                case 4:
                    Menu.User_HandlingMenu();
                    break;
                case 5:
                    Menu.Statistics();
                    break;
                case 6:
                    break;

            }
        }

        #region Search
        public static void Search_Prod_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- PRODUKTSÖKNING ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("SÖK PÅ ALLA PRODUKTER", 30));
            table.AddRow("2.", StringExtensions.CenterString("SÖK PÅ PRODUKTER ID", 30));
            table.AddRow("3.", StringExtensions.CenterString("SÖK PÅ PRODUKT NAMN", 30));
            table.AddRow("4.", StringExtensions.CenterString("TILLBAKA", 30));
            //table.AddRow("4.", StringExtensions.CenterString("", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("6.", StringExtensions.CenterString("", 30));
            Console.WriteLine(table.ToString());

        }

        public static void Search_Prod_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    AdminCRUD.AdminProdShowAll();
                    break;
                case 2:
                    AdminCRUD.AdminProdShowOne();
                    break;
                case 3:
                    SearchPage.Search();
                    break;
                case 4:
                    break;
            }
        }
        #endregion

        #region Product Handling
        public static void Prod_Handling_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- PRODUKTHANTERING ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("SÖK PRODUKTER", 30));
            table.AddRow("2.", StringExtensions.CenterString("PRODUKT INKÖP", 30));
            table.AddRow("3.", StringExtensions.CenterString("RADERA PRODUKT", 30));
            table.AddRow("4.", StringExtensions.CenterString("PRODUKT UPPDATERING", 30));
            table.AddRow("5.", StringExtensions.CenterString("SÖK PÅ ALLA PRODUKTER", 30));
            table.AddRow("6.", StringExtensions.CenterString("TILLBAKA", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("6.", StringExtensions.CenterString("", 30));
            Console.WriteLine(table.ToString());

        }

        public static void Prod_Handling_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    Menu.Search_Prod_Menu();
                    break;
                case 2:
                    AdminCRUD.AdminProdInsert();
                    break;
                case 3:
                    AdminCRUD.AdminProdRemove();
                    break;
                case 4:
                    AdminCRUD.AdminProdUpdate();
                    break;
                case 5:
                    AdminCRUD.AdminProdShowAll();
                    break;
                case 6:
                    break;
            }
        }
        #endregion

        #region Category Handling
        public static void Categori_Handling_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- KATEGORIHANTERING ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("VISA KATEGORIER", 30));
            table.AddRow("2.", StringExtensions.CenterString("INFÖRA KATEGORI", 30));
            table.AddRow("3.", StringExtensions.CenterString("RADERA KATEGORI", 30));
            table.AddRow("4.", StringExtensions.CenterString("UPPDATERA KATEGORI", 30));
            table.AddRow("5.", StringExtensions.CenterString("TILLBAKA", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("6.", StringExtensions.CenterString("", 30));
            Console.WriteLine(table.ToString());

        }

        public static void Category_Handling_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    AdminCRUD.AdminSubCatShow();
                    break;
                case 2:
                    AdminCRUD.AdminSubCatInsert();
                    break;
                case 3:
                    AdminCRUD.AdminSubCatRemove();
                    break;
                case 4:
                    AdminCRUD.AdminProdUpdate();
                    break;
                case 5:
                    break;

               
            }
        }
        #endregion

        #region Brand Handling
        public static void Brand_Handling_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- LEVERANTÖRSHANTERING ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("VISA LEVERANTÖR", 30));
            table.AddRow("2.", StringExtensions.CenterString("INFÖRA LEVERANTÖR", 30));
            table.AddRow("3.", StringExtensions.CenterString("RADERA LEVERANTÖR", 30));
            table.AddRow("4.", StringExtensions.CenterString("UPPDATERA LEVERANTÖR", 30));
            table.AddRow("5.", StringExtensions.CenterString("TILLBAKA", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("6.", StringExtensions.CenterString("", 30));
            Console.WriteLine(table.ToString());

        }

        public static void Brand_Handling_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    AdminCRUD.AdminSuppShow();
                    break;
                case 2:
                    AdminCRUD.AdminSuppInsert();
                    break;
                case 3:
                    AdminCRUD.AdminSuppRemove();
                    break;
                case 4:
                    AdminCRUD.AdminSuppUpdate();
                    break;
                case 5:
                    break;

            }
        }
        #endregion

        public static void User_Handling_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- KUNDÖVERSIKT ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("VISA KUNDLISTA", 30));
            table.AddRow("2.", StringExtensions.CenterString("ORDERHISTORIK", 30));
            table.AddRow("3.", StringExtensions.CenterString("NY ANVÄNDARE", 30));
            table.AddRow("4.", StringExtensions.CenterString("TILLBAKA", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("5.", StringExtensions.CenterString("", 30));
            //table.AddRow("6.", StringExtensions.CenterString("", 30));
            Console.WriteLine(table.ToString());

        }

        public static void USer_Handling_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    AdminCRUD.GetOrderHistory();
                    break;
                case 2:
                    AdminCRUD.AdminProdInsert();
                    break;
                case 3:
                    AdminCRUD.InsertNewUser();
                    break;
                case 4:

                    break;


            }
        }

        public static void Statistics_Display()
        {
            var table = new Table();
            table.SetHeaders("Val", StringExtensions.CenterString("--- STATISTIK ---", 30));
            table.AddRow("1.", StringExtensions.CenterString("BÄSTA SÄLJANDE PRODUKT", 30));
            table.AddRow("2.", StringExtensions.CenterString("BÄST SÄLJANDE KATEGORI", 30));
            table.AddRow("3.", StringExtensions.CenterString("MEST BÄSTELDA VARA AV KUND", 30));
            table.AddRow("4.", StringExtensions.CenterString("MEST BÄSTÄLDA VARA", 30));
            table.AddRow("5.", StringExtensions.CenterString("KUNDER SOM INTE HAR HANDLAT", 30));
            table.AddRow("6.", StringExtensions.CenterString("TOP KUNDER PER STAD", 30));
            table.AddRow("7.", StringExtensions.CenterString("ANTAL BESTÄLNINGAR", 30));
            table.AddRow("8.", StringExtensions.CenterString("MEDEL VÄRDE PER KUND", 30));
            table.AddRow("9.", StringExtensions.CenterString("VARUMÄRKEN MED MEST PRODUKTER", 30));
            table.AddRow("10.", StringExtensions.CenterString("BÄST SÄLJANDE VARUMÄRKE", 30));
            table.AddRow("11.", StringExtensions.CenterString("MEDELVÄREN AV PRISER", 30));
            table.AddRow("12.", StringExtensions.CenterString("TILLBAKA", 30));
            Console.WriteLine(table.ToString());
        }

        public static void Statistics_Switch(int menuSel)
        {
            switch (menuSel)
            {
                case 1:
                    DatabaseDapper.GetBestSellingProducts();
                    break;
                case 2:
                    DatabaseDapper.GetBestSellingCategory();
                    break;
                case 3:
                    DatabaseDapper.GetHighestOrderedAmountByCustomer();
                    break;
                case 4:
                    DatabaseDapper.ProductRepeatedlyOrdered();
                    break;
                case 5:
                    DatabaseDapper.CustomersNOtPurchased();
                    break;
                case 6:
                    DatabaseDapper.TopCustomersCities();
                    break;
                case 7:
                    DatabaseDapper.NumberOfOrders();
                    break;
                case 8:
                    DatabaseDapper.AvgAmountPerCustomer();
                    break;
                case 9:
                    DatabaseDapper.ProdPersupplier();
                    break;
                case 10:
                    DatabaseDapper.SoldAmountProdPersupplier();
                    break;
                case 11:
                    DatabaseDapper.MinAVGMaxOfPrice();
                    break;
                case 12:

                    break;


            }
        }


        public static void User_Deligation(int menuSel)
        {
            DatabaseQuerys.User_Admin_Deligation(menuSel);
        }
    }
}
