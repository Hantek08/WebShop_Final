using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Final.Models;


namespace WebShop_Final
{
    class AdminCRUD
    {
        #region Product 

        public static void AdminProdShowOne()
        {
            try
            {
                Console.Write("\nEnter Product Id: ");
                var id = Convert.ToInt32(Console.ReadLine());
                var product = DatabaseDapper.GetProductById(id);
                if (product != null)
                {


                    Console.WriteLine($"Product Id: {product.Id} \nProductName: {product.ProductName}\nSupplierId: {product.SupplierId}\nSubCategoryId: {product.SubCategoryId}\nDescription: {product.Description}\nUnitPrice: {product.UnitPrice}\nUnitInStock: {product.UnitInStock}\nSize: {product.Size}\nColor: {product.Color}", Console.WindowWidth,
                          Console.WindowHeight);

                }
                else
                    Console.WriteLine("Product Record Doesn't Exist");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }
        public static void AdminProdShowAll()
        {
            var table = new Table();

            table.SetHeaders("Product Id", "ProductName", "SupplierId", "SubCategoryId", "UnitPrice", "UnitInStock", "Size", "Color");

            var products = DatabaseDapper.GetAllProducts();

            foreach (var product in products)
            {
                table.AddRow(product.Id.ToString(), product.ProductName, product.SupplierId.ToString(), product.SubCategoryId.ToString(), product.UnitPrice.ToString(), product.UnitInStock.ToString(), product.Size, product.Color);

            }

            Console.WriteLine(table.ToString());
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();
        }
        public static void AdminProdInsert()
        {

            Product newProduct = new Product();
            Console.WriteLine("Please fill in the following information:");
            try
            {
                Console.Write("\nProduct Name: ");
                newProduct.ProductName = Console.ReadLine();
                Console.Write("\nSupplier ID: ");
                newProduct.SupplierId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSubCategory ID: ");
                newProduct.SubCategoryId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nDescription: ");
                newProduct.Description = Console.ReadLine();
                Console.Write("\nPrice: ");
                newProduct.UnitPrice = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nUnit In Stock: ");
                newProduct.UnitInStock = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSize: ");
                newProduct.Size = Console.ReadLine();
                Console.Write("\nColor: ");
                newProduct.Color = Console.ReadLine();

                Console.WriteLine($"\n{DatabaseDapper.InsertProduct(newProduct)} Rows Affected");

            }
            catch
            {
                Console.WriteLine("Invalid Input!");
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        public static void AdminProdRemove()
        {
            AdminProdShowAll();
            try
            {
                Console.Write("\nEnter The Product ID You Want To Delete: ");
                var id = Convert.ToInt32(Console.ReadLine());
                DatabaseDapper.RemoveProduct(id);

                var product = DatabaseDapper.GetProductById(id);
                if (product == null)
                {
                    Console.WriteLine("Product Record is deleted already");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        public static void AdminProdUpdate()
        {
            AdminProdShowAll();

            Product updateProduct = new Product();
            Console.WriteLine("Please fill in the following information:");

            try
            {
                Console.Write("\nProduct ID: ");
                updateProduct.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nUnit Price: ");
                updateProduct.UnitPrice = Convert.ToDouble(Console.ReadLine());


                Console.WriteLine(@$"{DatabaseDapper.UpdateProduct(updateProduct.Id, updateProduct.UnitPrice)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }
        #endregion

        #region Category
        public static void AdminSubCatShow()
        {
            var table = new Table();

            table.SetHeaders("SubCategory Id", "SubCategoryName", "CategoryId");

            var subCategories = DatabaseDapper.GetAllSubCategories();

            foreach (var subCategory in subCategories)
            {
                table.AddRow(subCategory.Id.ToString(), subCategory.SubCategoryName, subCategory.CategoryId.ToString());

            }

            Console.WriteLine(table.ToString());
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();
        }
        public static void AdminSubCatInsert()
        {
            SubCategory newSubCat = new SubCategory();
            Console.WriteLine("Please fill in the following information:");
            try
            {
                Console.Write("\nCategory ID: ");
                newSubCat.CategoryId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSubCategory Name: ");
                newSubCat.SubCategoryName = Console.ReadLine();

                Console.WriteLine($"\n{DatabaseDapper.InsertSubCategory(newSubCat)} Rows Affected");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        public static void AdminSubCatRemove()
        {
            AdminSubCatShow();
            try
            {
                Console.Write("\nEnter The Subcategory ID: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\n{DatabaseDapper.RemoveSubCategory(id)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();
        }

        public static void AdminSubCatUpdate()
        {
            AdminSubCatShow();
            SubCategory uppdateSubCat = new SubCategory();
            Console.WriteLine("Please fill in the following information:");

            try
            {
                Console.Write("\nSupplier ID: ");
                uppdateSubCat.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nCategory ID: ");
                uppdateSubCat.CategoryId = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nSubcategory: ");
                uppdateSubCat.SubCategoryName = Console.ReadLine();



                Console.WriteLine(@$"{DatabaseDapper.UpdateSubCategory(uppdateSubCat.Id, uppdateSubCat.CategoryId, uppdateSubCat.SubCategoryName)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }
        #endregion

        #region Supplier

        public static void AdminSuppShow()
        {
            var table = new Table();

            table.SetHeaders("Supplier Id", "Name", "Address", "Phone", "PostalCodeId");

            var suppliers = DatabaseDapper.GetAllSuppliers();

            foreach (var supplier in suppliers)
            {
                table.AddRow(supplier.Id.ToString(), supplier.Name, supplier.Address, supplier.Phone, supplier.PostalCodeId.ToString());

            }

            Console.WriteLine(table.ToString());
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }
        public static void AdminSuppInsert()
        {
            Supplier newSupp = new Supplier();

            Console.WriteLine("Please fill in the following information:");

            try
            {
                Console.Write("\nCampany Name: ");
                newSupp.Name = Console.ReadLine();
                Console.Write("\nAddress: ");
                newSupp.Address = Console.ReadLine();
                Console.Write("\nPhone: ");
                newSupp.Phone = Console.ReadLine();
                Console.Write("\nPostal Code ID: ");
                newSupp.PostalCodeId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\n{DatabaseDapper.InsertSupplier(newSupp)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        public static void AdminSuppRemove()
        {
            AdminSuppShow();
            try
            {
                Console.Write("\nEnter The Supplier ID: ");
                var id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\n{DatabaseDapper.RemoveSupplier(id)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        public static void AdminSuppUpdate()
        {
            AdminSuppShow();

            Supplier updateSupplier = new Supplier();
            Console.WriteLine("Please fill in the following information:");

            try
            {
                Console.Write("\nSupplier ID: ");
                updateSupplier.Id = Convert.ToInt32(Console.ReadLine());
                Console.Write("\nUnit Price: ");
                updateSupplier.Name = Console.ReadLine();


                Console.WriteLine(@$"{DatabaseDapper.UpdateSupplier(updateSupplier.Id, updateSupplier.Name)} Rows Affected");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        #endregion

        #region User

        public static void GetOrderHistory()
        {
            var table = new Table();

            table.SetHeaders("OrderDate", "OrderId", "ProductName", "Subcategory", "CustomerId", "CustomerName", "Quantity", "TotalAmount");

            var orderHistories = DatabaseDapper.OrderHistory();

            foreach (var orderHistory in orderHistories)
            {
                table.AddRow(orderHistory.OrderDate.ToString(), orderHistory.OrderId.ToString(), 
                    orderHistory.ProductName, orderHistory.Subcategory, orderHistory.CustomerId.ToString(), 
                    orderHistory.CustomerName, orderHistory.Quantity.ToString(), orderHistory.TotalAmount.ToString());

            }

            Console.WriteLine(table.ToString());
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();
        }

        public static void GetUserInfo()
        {
            var table = new Table();

            table.SetHeaders("FirstName", "LastName", "Address", "Phone", "Email", "UserName", "Password ", "PostalCode", "Country");

            var userInfo = DatabaseDapper.GetUserInfo();

            foreach (var u in userInfo)
            {
                table.AddRow(u.FirstName, u.LastName, u.Address, u.Phone, u.Email, u.UserName, u.Password, u.PostalCode, u.Country);

            }

            Console.WriteLine(table.ToString());
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();
        }


        public static void InsertNewUser()
        {

            User newUser = new User();
            Console.WriteLine("Please fill in the following information:");
            try
            {
                Console.Write("\n FirstName: ");
                newUser.FirstName = Console.ReadLine();
                Console.Write("\nLastName: ");
                newUser.LastName = Console.ReadLine();
                Console.Write("\nAddress : ");
                newUser.Address = Console.ReadLine();
                Console.Write("\nPhone: ");
                newUser.Phone = Console.ReadLine();
                Console.Write("\nEmail: ");
                newUser.Email = Console.ReadLine();
                Console.Write("\nAdmin : ");
                newUser.Admin = Convert.ToBoolean(Console.ReadLine());
                Console.Write("\nPostalCodeId : ");
                newUser.PostalCodeId= Convert.ToInt32(Console.ReadLine());
                Console.Write("\nPassword : ");
                newUser.Password = Console.ReadLine();

                Console.WriteLine($"\n{DatabaseDapper.InsertUser(newUser)} Rows Affected");

            }
            catch
            {
                Console.WriteLine("Invalid Input!");
            }
            Console.WriteLine();
            Console.WriteLine("Push Enter to continue.");
            Console.ReadLine();

        }

        #endregion

    }
}
