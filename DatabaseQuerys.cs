using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebShop_Final.Models;

namespace WebShop_Final
{
    class DatabaseQuerys
    {
        public static void BuyItem(int itemId)
        {
            using (var db = new Models.WebshopContext())
            {

                var table = new Table();

                var prod = db.Products.Where(p => p.Id == itemId).ToList();

                Köp.buffertProduct = prod[0];
            }

        }
        public static void Get_All_Products(int menuSel, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                var cntr = 0;
                var table = new Table();

                var products = db.Products.ToList().GroupJoin(db.Suppliers.ToList(),p=>p.SupplierId , sup=> sup.Id, (p,sup)=> new {p,sup }).ToList();
                table.AddRow("", "Produktnamn", "Färg", "Storlek", "Märke", "Pris");
                foreach (var prod in products)
                {
                    cntr++;
                    table.AddRow($"{cntr}", $"{prod.p.ProductName}", $"{prod.p.Color}", $"{prod.p.Size}", $"{prod.p.Supplier.Name}", $"{prod.p.UnitPrice}");
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }
        }

        public static int Single_Out_From_All_Products(int menuSel, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                var cntr = 0;
                var table = new Table();


                var prod = db.Products.ToList();

                table.SetHeaders("", StringExtensions.CenterString($"Du valde produkten", 15));
                
                table.AddRow($"", $"{prod.ElementAt(menuSel - 1).ProductName}");
                Menu.exitVal = cntr + 2;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("KÖP", 15));
                table.AddRow($"{cntr + 2}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 2;
                minVal = 1;
                return prod.ElementAt(menuSel - 1).Id;
            }
        }
        public static void Gender_Category_Menu(string gender, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {

                var cntr = 0;
                var table = new Table();
                var subCate = db.SubCategories;
                var cate = db.Categories;
                var products = db.Products;
                var allGenderProds = products.Where(p => p.SubCategory.CategoryId == 1);


                var damCateSet = from sub in subCate
                                 join c in cate on sub.CategoryId equals c.Id
                                 where c.CategoryName == $"{gender}"
                                 select new { sub.SubCategoryName };

                //Converting DbSet to List for eazyer handling in the menu
                var damCateList = damCateSet.ToList();

                //Menu Title Displayed on top
                table.SetHeaders("Val", StringExtensions.CenterString($"--- {gender.ToUpper()}AVDELNINGEN ---", 20));

                // A for loop to dynamicly go through all the sub categorys in any given gender
                for (int i = 0; i < damCateList.Count(); i++)
                {
                    cntr++;
                    table.AddRow($"{cntr}.", StringExtensions.CenterString($"{damCateList[i].SubCategoryName.ToUpper()}", 20));
                }
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                Console.WriteLine(table.ToString());
                //table.ClearRows();
                //foreach (var prod in allGenderProds)
                //{
                //    table.AddRow($"{prod.Id}", $"{prod.ProductName}", $"{prod.Size}");
                //}

                Menu.exitVal = cntr + 1;

                //Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }
        }

        public static void All_Product_Choise(int genderId, int menuSel, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                #region
                //var cntr = 0;
                //var table = new Table();
                //var subCateSet = db.SubCategories;
                //var products = db.Products;
                //var cate = db.Categories;
                //var subCateList = subCateSet.ToList();
                //var cateIdVal = subCateList[menuSel].Id;

                //var prodFilterSet = from p in products
                //                    join sub in subCateSet on p.SubCategoryId equals sub.Id
                //                    join c in cate on sub.CategoryId equals c.Id
                //                    where c.Id == genderId && sub.SubCategoryName == $"{subCateList[menuSel - 1].SubCategoryName}"
                //                    select new { p.ProductName, p.Color, p.Size, p.UnitPrice, p.Supplier, sub.SubCategoryName, c.CategoryName, c.Id, sub.CategoryId };

                ////var prodFilterList = prodFilterSet.ToList();
                //table.AddRow(StringExtensions.CenterString($"{subCateList[menuSel - 1].SubCategoryName}", 50));
                //Console.WriteLine(table.ToString());
                //table.ClearRows();
                //foreach (var prod in prodFilterSet)
                //{
                //    if (prod.Id == genderId && prod.SubCategoryName == $"{subCateList[menuSel - 1].SubCategoryName}")
                //    {
                //        cntr++;
                //        table.AddRow($"{cntr}", $"{prod.ProductName}", $"{prod.Color}", $"{prod.Size}", $"{prod.UnitPrice}", $"{prod.SubCategoryName}", $"{prod.CategoryName}");


                //    }


                //}
                //Menu.exitVal = cntr + 1;
                //table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                //Console.WriteLine(table.ToString());
                //maxVal = cntr + 1;
                //minVal = 1;
                #endregion
                var cntr = 0;
                var table = new Table();
                var product = db.Products.ToList();
                var subCate = db.SubCategories.ToList();
                var cate = db.Categories.ToList();
                var suply = db.Suppliers;
                var filterSubCate = subCate.Where(c => c.CategoryId == cate.ElementAt(genderId - 1).Id).ToList();
                var prodFilter = product.Where(p => p.SubCategoryId == filterSubCate[menuSel - 1].Id);
                var prodFilter2 = from pF in prodFilter
                                  join s in suply on pF.SupplierId equals s.Id
                                  select pF;
                foreach (var c in prodFilter2)
                {
                    table.SetHeaders("Val", StringExtensions.CenterString($"{c.SubCategory.SubCategoryName}", 15));

                }


                foreach (var c in prodFilter2)
                {
                    cntr++;
                    table.AddRow($"{cntr}", $"{c.ProductName}", $"{c.Color}", $"{c.Size}", $"{c.Supplier.Name}", $"{c.UnitPrice} kr");
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;

            }
        }
        public static void Gender_Category_Product_Select(int genderId, int menuSel, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                #region
                //var cntr = 0;
                //var table = new Table();
                //var subCateSet = db.SubCategories;
                //var products = db.Products;
                //var cate = db.Categories;
                //var subCateList = subCateSet.ToList();
                //var cateIdVal = subCateList[menuSel].Id;

                //var prodFilterSet = from p in products
                //                    join sub in subCateSet on p.SubCategoryId equals sub.Id
                //                    join c in cate on sub.CategoryId equals c.Id
                //                    where c.Id == genderId && sub.SubCategoryName == $"{subCateList[menuSel - 1].SubCategoryName}"
                //                    select new { p.ProductName, p.Color, p.Size, p.UnitPrice, p.Supplier, sub.SubCategoryName, c.CategoryName, c.Id, sub.CategoryId };

                ////var prodFilterList = prodFilterSet.ToList();
                //table.AddRow(StringExtensions.CenterString($"{subCateList[menuSel - 1].SubCategoryName}", 50));
                //Console.WriteLine(table.ToString());
                //table.ClearRows();
                //foreach (var prod in prodFilterSet)
                //{
                //    if (prod.Id == genderId && prod.SubCategoryName == $"{subCateList[menuSel - 1].SubCategoryName}")
                //    {
                //        cntr++;
                //        table.AddRow($"{cntr}", $"{prod.ProductName}", $"{prod.Color}", $"{prod.Size}", $"{prod.UnitPrice}", $"{prod.SubCategoryName}", $"{prod.CategoryName}");


                //    }


                //}
                //Menu.exitVal = cntr + 1;
                //table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                //Console.WriteLine(table.ToString());
                //maxVal = cntr + 1;
                //minVal = 1;
                #endregion
                var cntr = 0;
                var table = new Table();
                var product = db.Products.ToList();
                var subCate = db.SubCategories.ToList();
                var cate = db.Categories.ToList();
                var suply = db.Suppliers;
                var filterSubCate = subCate.Where(c => c.CategoryId == cate.ElementAt(genderId - 1).Id).ToList();
                var prodFilte = product.Where(p => p.SubCategoryId == filterSubCate[menuSel - 1].Id);
                var prodFilter2 = from pF in prodFilte
                                  join s in suply on pF.SupplierId equals s.Id
                                  select pF;
                foreach (var c in prodFilter2)
                {
                    table.SetHeaders("Val", StringExtensions.CenterString($"{c.SubCategory.SubCategoryName}", 15));

                }
                if (prodFilter2.Count() != 0)
                {
                    table.AddRow("", "Produktnamn", "Färg", "Storlek", "Märke", "Pris");
                }

                foreach (var c in prodFilter2)
                {
                    cntr++;
                    table.AddRow($"{cntr}", $"{c.ProductName}", $"{c.Color}", $"{c.Size}", $"{c.Supplier.Name}", $"{c.UnitPrice} kr");
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;

            }
        }

        public static int Singleing_Out_A_Product_By_Gender_And_SubCategory(int genderId, int menuSel, int placeHolder, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {

                var cntr = 0;
                var table = new Table();
                var product = db.Products.ToList();
                var subCate = db.SubCategories.ToList();
                var cate = db.Categories.ToList();
                var suply = db.Suppliers;
                var filterSubCate = subCate.Where(c => c.CategoryId == cate.ElementAt(genderId - 1).Id).ToList();
                var prodFilte = product.Where(p => p.SubCategoryId == filterSubCate[placeHolder - 1].Id);
                var prodFilter2 = from pF in prodFilte
                                  join s in suply on pF.SupplierId equals s.Id
                                  select pF;

                table.SetHeaders("", StringExtensions.CenterString($"Du valde produkten", 15));





                table.AddRow("", $"{prodFilter2.ElementAt(menuSel - 1).ProductName}");

                Menu.exitVal = cntr + 2;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("KÖP", 15));
                table.AddRow($"{cntr + 2}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 2;
                minVal = 1;
                return prodFilter2.ElementAt(menuSel - 1).Id;
            }
        }

        public static void Shopping_Cart_Menu(out int minVal,out int maxVal)
        {
            var cntr=0;
            var table = new Table();

            ShopingCart.CartDisplay();
            Menu.exitVal = cntr + 2;
            table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TA BORT PRODUKT", 15));
            table.AddRow($"{cntr + 2}.", StringExtensions.CenterString("CHECKOUT", 15));
            table.AddRow($"{cntr + 3}.", StringExtensions.CenterString("TILLBACK", 15));
            Console.WriteLine(table.ToString());
            maxVal = cntr + 3;
            minVal = 1;

        }
        public static void User_List_Menu(out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                var cntr = 0;
                var table = new Table();

                var user = db.Users.Where(u => u.Admin == false).ToList();

                
                table.SetHeaders("Val", StringExtensions.CenterString($"--- USERS ---", 20));

                for (int i = 0; i < user.Count(); i++)
                {
                    cntr++;
                    table.AddRow($"{cntr}.", StringExtensions.CenterString($"{user[i].Username}", 20));
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }


        }

        public static void Admin_List_Menu(out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                var cntr = 0;
                var table = new Table();
                var user = db.Users.Where(u => u.Admin == true).ToList();


                table.SetHeaders("Val", StringExtensions.CenterString($"--- ADMIN ---", 20));

                // A for loop to dynamicly go through all the sub categorys in any given gender
                for (int i = 0; i < user.Count(); i++)
                {
                    cntr++;
                    table.AddRow($"{cntr}.", StringExtensions.CenterString($"{user[i].Username}", 20));
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }


        }
        public static void User_List_Choise(int menuSel, out string ja_Nej)
        {
            ja_Nej = "";
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();

                //Kollar om admin kolumnen är true eler false
                var user = db.Users.Where(u => u.Admin == false).ToList();

                if (Menu.exitVal > menuSel && menuSel != 0)
                {

                    table.AddRow(StringExtensions.CenterString("Är du", 30));
                    table.AddRow(StringExtensions.CenterString($"{user[menuSel - 1].Username}", 30));
                    table.AddRow(StringExtensions.CenterString("Svara med Ja eller Nej!", 30));

                    Console.WriteLine(table.ToString());
                    Console.WriteLine();
                    ja_Nej = Menu.JA_Nej_Selector(Console.ReadLine(), menuSel);

                }
                else if (Menu.exitVal == menuSel)
                {
                    Menu.exit = true;
                }

            }
        }

        public static void Admin_List_Choise(int menuSel, out string ja_Nej)
        {
            ja_Nej = "";
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();
                var adminSet = db.Users;

                var adminFilter = adminSet.Where(c => c.Admin == true).ToList();

                if (Menu.exitVal > menuSel && menuSel != 0)
                {

                    table.AddRow(StringExtensions.CenterString("Är du", 30));
                    table.AddRow(StringExtensions.CenterString($"{adminFilter[menuSel - 1].Username}", 30));
                    table.AddRow(StringExtensions.CenterString("Svara med Ja eller Nej!", 30));

                    Console.WriteLine(table.ToString());
                    Console.WriteLine();
                    ja_Nej = Menu.JA_Nej_Selector(Console.ReadLine(), menuSel);

                }
                else if (Menu.exitVal == menuSel)
                {
                    Menu.exit = true;
                }

            }
        }
        public static void User_Admin_Deligation(int menuSel)
        {
            using (var db = new Models.WebshopContext())
            {
                var user = db.Users.ToList().ElementAt(menuSel - 1);
                try
                {
                    UserPage.mainUser = user;
                }
                catch (Exception)
                {
                    Console.WriteLine("ok den va ny!");
                }
            }
        }
        public static void Admin_Deligation(int menuSel)
        {
            using (var db = new Models.WebshopContext())
            {
                var adminSet = db.Users;
                var adminList = adminSet.ToList();
                try
                {
                    UserPage.mainUser = adminList[menuSel - 1];
                }
                catch (Exception)
                {
                    Console.WriteLine("ok den va ny!");
                }
            }
        }

        #region Shipment
        public static void Choosing_Shipment(out int minVal, out int maxVal)
        {
            
            var table = new Table();
            var cntr = 0;

            using (var db = new Models.WebshopContext())
            {
                table.AddRow("Välj frakt metod");
                var shipmentChoise = db.Shipments.ToList();
                table.AddRow("Val", "Fraktmetod", "Pris");
                foreach (var shipers in shipmentChoise)
                {
                    cntr++;
                    table.AddRow($"{cntr}", $"{shipers.CompanyName}", $"{shipers.Freight}");
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }

        }

        public static void Single_Out_Shipper(int menuSel, out int shipId)
        {
            
            using (var db = new Models.WebshopContext())
            {
                var shipperChoise = db.Shipments.ToList().ElementAt(menuSel-1);
                shipId = shipperChoise.Id;
                Menu.exit = true;
            }

        }
        #endregion

        #region Payment
        public static void Choosing_Pay_Method(out int minVal, out int maxVal)
        {
            var table = new Table();
            var cntr = 0;

            using (var db = new Models.WebshopContext())
            {
                table.AddRow("Välj betal metod.");
                var PaymentChoise = db.Payments.ToList();
                table.AddRow("Val", "Betalmetod");
                foreach (var payments in PaymentChoise)
                {
                    cntr++;
                    table.AddRow($"{cntr}", $"{payments.PaymentType}");
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 20));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 1;
                minVal = 1;
            }
        }

        public static void Single_Out_Pay_Method(int menuSel, out int payId)
        {
            using (var db = new Models.WebshopContext())
            {
                var paymentChoise = db.Payments.ToList().ElementAt(menuSel - 1);
                payId = paymentChoise.Id;
                Menu.exit = true;
            }

        }
        #endregion
        
        public static int? Qwant_Check(int prodId)
        {
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();

                var prod = db.Products.Where(p => p.Id == prodId).ToList();

                return prod[0].UnitInStock;
            }
        }
    }
}
