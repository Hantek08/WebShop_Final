using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop_Final.Models;
using System.Data.SqlClient;
using Dapper;

namespace WebShop_Final
{
    class DatabaseDapper
    {
        static string connString = @"Server=tcp:sqlschoolproject.database.windows.net,1433;Initial Catalog=Webshop;Persist Security Info=False;User ID=hantek13;Password=Admin1308;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        #region Product
        public static int InsertProduct(Product product)
        {
            int affectedRows = 0;
            var parameters = new { productName = product.ProductName, supplierId = product.SupplierId, subCategoryId = product.SubCategoryId, description = product.Description, unitPrice = product.UnitPrice, unitInStock = product.UnitInStock, size = product.Size.ToUpper(), color = product.Color };
            var sql = @$"INSERT INTO Products(productName, supplierId, subCategoryId, description, unitPrice, unitInStock, size, color) 
                         VALUES (@ProductName, @SupplierId,@SubCategoryId, @Description, @UnitPrice,@UnitInStock, @Size, @Color)";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;
        }
        public static Product GetProductById(int id)
        {
            var sql = "SELECT * FROM Products WHERE id = @id";
            var product = new Product();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                product = connection.Query<Product>(sql, new { id = id }).FirstOrDefault();
            }
            return product;
        }

        public static List<Product> GetAllProducts()
        {
            var sql = @$"SELECT * FROM Products";
            var products = new List<Product>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                products = connection.Query<Product>(sql).ToList();
            }
            return products;
        }

        public static int RemoveProduct(int id)
        {
            var sql = $"DELETE FROM Products WHERE id = @id";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, new { id = id });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return affectedRows;
        }

        public static int UpdateProduct(int? id, double? unitPrice)
        {
            int affectedRows = 0;
            var parameters = new { id = id, unitPrice = unitPrice };

            var sql = @$"UPDATE Products SET unitPrice = @UnitPrice WHERE id = @ID";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return affectedRows;
        }

        #endregion

        #region Category

        public static int InsertSubCategory(SubCategory subCategory)
        {
            int affectedRows = 0;
            var parameters = new { categoryId = subCategory.CategoryId, subCategoryName = subCategory.SubCategoryName };
            var sql = @$"INSERT INTO SubCategories(categoryId, subCategoryName)  
                         VALUES (@CategoryId,@SubCategoryName";
            using (var connection = new SqlConnection(connString))
            {

                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return affectedRows;
        }

        public static List<SubCategory> GetAllSubCategories()
        {
            var sql = @$"SELECT * FROM SubCategories";
            var subCategories = new List<SubCategory>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                subCategories = connection.Query<SubCategory>(sql).ToList();
            }
            return subCategories;
        }

        public static int RemoveSubCategory(int id)
        {
            var sql = @$"DELETE FROM SubCategories WHERE id = @id";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, new { id = id });
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return affectedRows;
        }

        public static int UpdateSubCategory(int id, int? categoryId, string subCategoryName)
        {
            int affectedRows = 0;
            var parameters = new { id = id, categoryId = categoryId, subCategoryName = subCategoryName };
            var sql = @$"UPDATE SubCategories SET categoryId = @categoryId, subCategoryName = @subCategoryName WHERE id = @id";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return affectedRows;
        }

        #endregion

        #region Supplier

        public static int InsertSupplier(Supplier supplier)
        {
            int affectedRows = 0;
            var parameters = new { Name = supplier.Name, Address = supplier.Address, Phone = supplier.Phone, PostalCodeId = supplier.PostalCodeId };
            var sql = @$"INSERT INTO Suppliers(name, address, phone, postalCodeId)  
                         VALUES (@Name,@Address, @Phone, @PostalCodeId)";
            using (var connection = new SqlConnection(connString))
            {

                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return affectedRows;
        }

        public static List<Supplier> GetAllSuppliers()
        {
            var sql = @$"SELECT * FROM Suppliers";
            var subCategories = new List<Supplier>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                subCategories = connection.Query<Supplier>(sql).ToList();
            }
            return subCategories;
        }

        public static int RemoveSupplier(int id)
        {
            var sql = @$"DELETE FROM Suppliers WHERE id = @Id";
            var affectedRows = 0;

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, new { id = id });
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return affectedRows;
        }

        public static int UpdateSupplier(int id, string name)
        {
            int affectedRows = 0;
            var parameters = new { ID = id, Name = name };

            var sql = @$"UPDATE Suppliers SET name= @Name WHERE id = @Id";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e) { Console.WriteLine(e.Message); }
            }
            return affectedRows;
        }
        #endregion

        #region UserInfo
        public static List<OrderHistory> OrderHistory()
        {
            var sql = @$"select o.orderDate [Order Date], o.id [Order ID], p.productName [Product Name], s.subCategoryName[Subcategory],u.id [Customer ID],
                    (u.firstName +  ' ' + u.lastName) [Customer Name], od.quantity[Quantity], o.total[Total Amount] From SubCategories s 
                     join Products p on p.subCategoryId = s.id join OrderDetails od on p.id = od.productId 
                       join Orders o on o.id = od.orderId join Users u on u.id = o.userId ";

            var orderHistory = new List<OrderHistory>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                orderHistory = connection.Query<OrderHistory>(sql).ToList();
            }
            return orderHistory;


        }

        public static List<UserInfo> GetUserInfo()
        {
            var sql = $@"select U.[id],[firstName],[lastName],[address],[phone],[email],
                       [username],[password], postalCode, country from Users as U 
                       join [dbo].[PostalCodes] AS P ON U.postalCodeId = p.id where admin = 0;";

            var userInfo = new List<UserInfo>();
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                userInfo = connection.Query<UserInfo>(sql).ToList();
            }
            return userInfo;
        }

        public static int InsertUser(User user)
        {
            int affectedRows = 0;
            var parameters = new
            {
                firtsName = user.FirstName,
                address = user.Address,
                phone = user.Phone,
                email = user.Email,
                admin = user.Admin,
                postalCodeId = user.PostalCodeId,
                username = user.Username,
                password = user.Password
            };
            var sql = @$"INSERT INTO Users(firstName, lastName, [address], phone, email, [admin], postalCodeId, username, [password]) 
                            VALUES (@FirstName, @LastName, @Address, @Phone, @Email, @Admin, @PostalCodeId, @Username, @Password])";
            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                try
                {
                    affectedRows = connection.Execute(sql, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            return affectedRows;
        }

        #endregion

        #region Aggregated data 
        //Topp 3 bästsäljande produkter
        public static void GetBestSellingProducts()
        {
            var sql = @$"SELECT TOP(3)od.productId, productName, unitPrice, SUM(quantity) as Quantity FROM OrderDetails od join Products p on p.id = od.productId
                        GROUP BY od.productId, ProductName, UnitPrice ORDER BY Quantity DESC";

            var table = new Table();

            table.SetHeaders("ProductName", "Price");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var bestSellingProducts = connection.Query<(int, string, float)>(sql);

                foreach (var bsp in bestSellingProducts)
                {
                    table.AddRow(bsp.Item2, bsp.Item3.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        // Topp 3 populära kategorier
        public static void GetBestSellingCategory()
        {
            var sql = @$"SELECT TOP(3)s.subCategoryName, SUM(quantity) as Quantity FROM OrderDetails od join Products p on p.id = od.productId 
                                    join SubCategories s on s.id = p.subCategoryId
                                    GROUP BY s.id, s.subCategoryName ";

            var table = new Table();

            table.SetHeaders("Category", "Quantity");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var bestSellingCategory = connection.Query<(string, int)>(sql);

                foreach (var bsp in bestSellingCategory)
                {
                    table.AddRow(bsp.Item1, bsp.Item2.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        /// <summary>
        /// Högsta inköpsbelopp som beställs av varje kund på ett visst datum
        /// </summary>
        public static void GetHighestOrderedAmountByCustomer()
        {
            var sql = @$"SELECT o.userId, (u.firstName + ' ' + u.LastName) as CustomerName, CAST(orderDate as [date]) as [OrderDate],
                                MAX(total) as [Max] FROM orders o 
                                Join Users u on o.userId = u.id
                                GROUP BY userId, (u.firstName + ' ' + u.LastName), CAST(orderDate as [date]) ";

            var table = new Table();

            table.SetHeaders("Customer ID", "Customer Name", "Date", "Total");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var highestOrderAmount = connection.Query<(int, string, DateTime, float)>(sql);

                foreach (var amount in highestOrderAmount)
                {
                    table.AddRow(amount.Item1.ToString(), amount.Item2, amount.Item3.ToString(), amount.Item4.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Produkter som upprepade gånger beställs av kunder i olika beställningar
        public static void ProductRepeatedlyOrdered()
        {
            var sql = @$"SELECT p.productName, pu.productId, pu.userId, u.firstName as [Name], pu.Order_ID
                                FROM (SELECT o.userId, od.productId, STRING_AGG(o.id, ',') Order_ID FROM OrderDetails od JOIN ORDERS O ON O.Id = od.orderId 
                                GROUP BY o.userId, od.productId
                                HAVING COUNT(*) > 1) pu
                                join Products p on p.id = pu.productId join Users u on pu.userId = u.id";

            var table = new Table();

            table.SetHeaders("ProductId", "ProductName", "UserId", "CustomerName", "OrderId");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var RepeatedlyOrdered = connection.Query<(string, int, int, string, string)>(sql);

                foreach (var order in RepeatedlyOrdered)
                {
                    table.AddRow(order.Item1, order.Item2.ToString(), order.Item3.ToString(), order.Item4, order.Item5);

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Kunder som inte har köpt någon produkt

        public static void CustomersNOtPurchased()
        {
            var sql = @$"SELECT (u.firstName +  ' ' + u.lastName) [customerName], u.id FROM Users u 
                                LEFT JOIN Orders o on o.userId = u.id WHERE o.userId IS NULL ";

            var table = new Table();

            table.SetHeaders("Customer Name", "ID");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var customersNOtPurchased = connection.Query<(string, int)>(sql);

                foreach (var customer in customersNOtPurchased)
                {
                    table.AddRow(customer.Item1, customer.Item2.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Städer som har flest kunder

        public static void TopCustomersCities()
        {
            var sql = @$"SELECT COUNT(u.id) AS CustomersQuantity, pc.city as City FROM PostalCodes pc join Users u on pc.id = u.postalCodeId 
                                GROUP BY pc.city ";

            var table = new Table();

            table.SetHeaders("CustomersQuantity", "City");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var topCustomersCities = connection.Query<(int, string)>(sql);

                foreach (var city in topCustomersCities)
                {
                    table.AddRow(city.Item1.ToString(), city.Item2);

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Antal order som beställts av varje kund
        public static void NumberOfOrders()
        {
            var sql = @$" SELECT userId AS CustomerID, COUNT(id) as NumberOfOrders FROM orders
                             GROUP BY userId";

            var table = new Table();

            table.SetHeaders("CustomerID", "NumberOfOrders");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var numberOfOrders = connection.Query<(int, int)>(sql);

                foreach (var order in numberOfOrders)
                {
                    table.AddRow(order.Item1.ToString(), order.Item2.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        // Genomsnittligt ordervärde per kund
        public static void AvgAmountPerCustomer()
        {
            var sql = @$"SELECT userId, ROUND(AVG(total), 2) AvgAmount FROM orders GROUP BY userId";

            var table = new Table();

            table.SetHeaders("CustomerID", "AvgOrderValue");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var avgOrderValue = connection.Query<(int, int)>(sql);

                foreach (var avg in avgOrderValue)
                {
                    table.AddRow(avg.Item1.ToString(), avg.Item2.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Antal produkter per leverantör


        public static void ProdPersupplier()
        {
            var sql = @$"SELECT supplierId AS SupplierID, [name] as Supplier, Count(p.id) AS NumberOfProducts FROM Products p JOIN Suppliers s on s.id = p.supplierId
                        GROUP BY supplierId, [name]";

            var table = new Table();

            table.SetHeaders("SupplierID", "Supplier", "NumberOfProducts");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var numberOfOrders = connection.Query<(int, string, int)>(sql);

                foreach (var prod in numberOfOrders)
                {
                    table.AddRow(prod.Item1.ToString(), prod.Item2, prod.Item3.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Antal sålda produkter och kvantitet per leverantör

        public static void SoldAmountProdPersupplier()
        {
            var sql = @$"SELECT supplierId AS SupplierID, [name] as Supplier, sum(p.unitPrice * od.quantity) AS TotalAmount FROM OrderDetails od join Products p on p.id = od.productId JOIN Suppliers s on s.id = p.supplierId
                                    GROUP BY supplierId, [name]";

            var table = new Table();

            table.SetHeaders("SupplierID", "Supplier", "TotalAmount");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var SoldAmountProdPersupplier = connection.Query<(int, string, int)>(sql);

                foreach (var amount in SoldAmountProdPersupplier)
                {
                    table.AddRow(amount.Item1.ToString(), amount.Item2, amount.Item3.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }

        //Min, AVG, Max produktpris
        public static void MinAVGMaxOfPrice()
        {
            var sql = @$"SELECT MIN(unitPrice) AS MinPrice, ROUND(AVG(unitPrice),2)  AS AvgPrice, MAX(unitPrice) AS MaxPrice
                            FROM Products";

            var table = new Table();

            table.SetHeaders("MinUnitPrice", "AVGUnitPrice", "MaxUnitPrice");

            using (var connection = new SqlConnection(connString))
            {
                connection.Open();
                var minAVGMaxOfPrice = connection.Query<(float, float, float)>(sql);

                foreach (var minAvgMax in minAVGMaxOfPrice)
                {
                    table.AddRow(minAvgMax.Item1.ToString(), minAvgMax.Item2.ToString(), minAvgMax.Item3.ToString());

                }
                Console.WriteLine(table.ToString());

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Tryck på Enter för att fortsätta.");
            Console.ReadLine();
        }



        #endregion

    }
}
