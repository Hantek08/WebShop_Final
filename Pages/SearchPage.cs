using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebShop_Final
{
    class SearchPage
    {
        public static void Search()
        {
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();
                var product = db.Products;
                var subCat = db.SubCategories;
                table.AddRow($"Fritextsökning");
                
                Console.WriteLine(table.ToString());
                table.ClearRows();
                var search = Console.ReadLine();
                table.AddRow($"Sökresultat på \"{search}\"");
                Console.WriteLine(table.ToString());
                table.ClearRows();
                var searchProOrCat = from p in product
                                     join s in subCat on p.SubCategoryId equals s.Id
                                     join cat in db.Categories on s.CategoryId equals cat.Id
                                     where p.ProductName.Contains(search) || s.SubCategoryName == search
                                     select new { ProductName = p.ProductName, SubCategoryName = s.SubCategoryName, CategoryName = cat.CategoryName };
                table.SetHeaders("Product Name","SubCategory Name" ,"Category");
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (var item in searchProOrCat)
                {
                    table.AddRow($"{item.ProductName}",$"{item.SubCategoryName}",$" {item.CategoryName}");
                }

                Console.WriteLine(table.ToString());
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine();
                Console.WriteLine("Tryck på Enter för att fortsätta.");
                Console.ReadLine();
            }
        
        }
    }
}
