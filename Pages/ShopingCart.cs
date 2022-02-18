using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class ShopingCart
    {

        public static List<CartItem> mainShoppingCart = new List<CartItem>();

        public static float cartItemTotal = 0;

        public static float cartItemTotalTax = Cart_Total() * 0.25F;

        public static void Add_Product_To_Cart(Models.Product product, int quntity)
        {
            var newCartProduct = new CartItem();
            newCartProduct.ProductId = product.Id;
            newCartProduct.Quantity = quntity;
            newCartProduct.UserId = UserPage.mainUser.Id;
            mainShoppingCart.Add(newCartProduct);

        }

        public static void Clear_cart()
        {
            mainShoppingCart.Clear();
        }
        public static void DeleteCartItemDisplay(int menuSel, out int minVal, out int maxVal)
        {
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();
                var prod = db.Products;
                int cntr = 0;

                for (int i = 0; i < mainShoppingCart.Count(); i++)
                {
                    var cartItem = prod.ToList().Where(p => p.Id == mainShoppingCart[i].ProductId);
                    foreach (var item in cartItem)
                    {
                        cntr++;
                        table.AddRow($"{cntr}", $"{item.ProductName}", $"{mainShoppingCart[i].Quantity}");
                    }
                }
                Menu.exitVal = cntr + 1;
                table.AddRow($"", StringExtensions.CenterString("VÄLJ PRODUKEN DU VILL TA BORT", 15));

                table.AddRow($"{cntr + 1}.", StringExtensions.CenterString("TILLBACK", 15));
                Console.WriteLine(table.ToString());
                maxVal = cntr + 2;
                minVal = 1;
            }
        }
        public static void DeleteCartItem(int menuSel)
        {
            using (var db = new Models.WebshopContext())
            {
                var table = new Table();
                var prod = db.Products.ToList();
                int cntr = 0;

                for (int i = 0; i < mainShoppingCart.Count(); i++)
                {
                    var cartItem = prod.ToList().Where(p => p.Id == mainShoppingCart[menuSel - 1].ProductId);
                    foreach (var item in cartItem)
                    {
                        cntr++;
                        table.AddRow($"{cntr}", $"{item.ProductName}", $"{mainShoppingCart[menuSel - 1].Quantity}");

                    }
                }


                Menu.exitVal = cntr + 2;
                table.AddRow(StringExtensions.CenterString("Är nu borttaget!", 15));


                Console.WriteLine(table.ToString());

                Console.WriteLine("Tryck på Enter för att forsätta.");

                if (mainShoppingCart.Count() != 0)
                {
                    mainShoppingCart.RemoveAt(menuSel - 1); 
                }
                
            }
        }
        public static void CartDisplay()
        {
            Console.Clear();
            var table = new Table();
            table.AddRow("DIN KUNDVAGN");

            Console.WriteLine(table.ToString());
            Console.ForegroundColor = ConsoleColor.Red;
            Shoping_Cart_Content_Display();
            table.ClearRows();
            if (mainShoppingCart.Count() == 0)
            {
                table.AddRow("Är tom!");
            }
            Console.WriteLine(table.ToString());

            Console.ForegroundColor = ConsoleColor.DarkYellow;

        }

        public static float Cart_Total()
        {
            var tot = 0F;
            using (var db = new Models.WebshopContext())
            {
                var prod = db.Products.ToList();

                for (int i = 0; i < mainShoppingCart.Count(); i++)
                {
                    var cartItem = prod.ToList().Where(p => p.Id == mainShoppingCart[i].ProductId);
                    foreach (var item in cartItem)
                    {
                        tot += ((float)item.UnitPrice * mainShoppingCart[i].Quantity);

                    }
                }

            }
            return tot;
        }

        public static float Total_Tax()
        {
            var totTax = 0F;

            return totTax = Cart_Total() * 0.25F;
        }
        //
        public static void Shoping_Cart_Content_Display()
        {
            //
            if (mainShoppingCart.Count() != 0)
            {
                var table = new Table();
                var total = 0.00F;

                using (var db = new Models.WebshopContext())
                {
                    //
                    var subCategorys = ((from subCate in db.SubCategories
                                         select subCate).ToList()).GroupJoin((from category in db.Categories select category).ToList(), sub => sub.CategoryId, cat => cat.Id, (sub, cat) => new { sub, cat });

                    //
                    var products = ((from product in db.Products select product).ToList()).GroupJoin((from Sub in subCategorys select Sub), prod => prod.SubCategoryId, sub => sub.sub.Id, (prod, sub) => new { prod, sub });

                    var supAddProd = products.ToList().GroupJoin(db.Suppliers.ToList(), p => p.prod.SupplierId, sup => sup.Id, (p, sup) => new { p, sup }).ToList();

                    table.AddRow("", "Produktnamn", "Färg", "Storlek", "Märke", "Kvantitet", "Pris");

                    //
                    for (int i = 0; i < mainShoppingCart.Count(); i++)
                    {
                        var cartItem = products.ToList().Where(p => p.prod.Id == mainShoppingCart[i].ProductId);
                        foreach (var item in cartItem)
                        {
                            table.AddRow("", $"{item.prod.ProductName}", $"{item.prod.Color}", $"{item.prod.Size}", $"{item.prod.Supplier.Name}", $"{mainShoppingCart[i].Quantity}", $"{(item.prod.UnitPrice) * (int)mainShoppingCart[i].Quantity}");



                        }
                    }
                    Cart_Total();

                    table.AddRow("", "", "", "", "", "", "");
                    table.AddRow("", "", "", "", "", "Totalt:", $"{ShopingCart.Cart_Total()}");
                    table.AddRow("", "", "", "", "", "Moms:", $"{ShopingCart.Total_Tax()}");

                    Console.WriteLine(table.ToString());

                    cartItemTotal = Cart_Total();
                    cartItemTotalTax = Total_Tax();

                }
            }
        }

        public static void Checkout_And_Clearing_the_Cart()
        {

            if (mainShoppingCart.Count() != 0)
            {
                var table = new Table();
                using (var db = new Models.WebshopContext())
                {
                    var currentOrder = Create_An_Order(out int shipId, out int payId);

                    if(currentOrder != null)
                    {
                        foreach (var item in mainShoppingCart)
                        {
                            var forwardOrderDetails = new Models.OrderDetail { ProductId = item.ProductId, OrderId = currentOrder.Id, Quantity = item.Quantity };
                            currentOrder.OrderDetails.Add(forwardOrderDetails);
                            Models.Product prod = db.Products.Where(o => o.Id == item.ProductId).FirstOrDefault();
                            prod.UnitInStock = prod.UnitInStock - item.Quantity;
                            db.Products.Update(prod);

                        }
                    }

                    db.Orders.Add(currentOrder);
                    ShopingCart.Receipt_Splash(shipId, payId);

                    db.SaveChanges();
                    
                    Clear_cart();
                }



            }
            else
            {
                Console.WriteLine("Kundvagnen är tom.");
                Console.ReadLine();
            }
        }
        public static Models.Order Create_An_Order(out int shipId, out int payId)
        {
            var order = new Models.Order();
            order.UserId = UserPage.mainUser.Id;
            Menu.Shipment_Menu(out shipId);
            order.ShipmentId = shipId;
            Menu.Payment_Menu(out payId);
            order.PaymentId = payId;
            order.Tax = cartItemTotalTax;
            order.Total = cartItemTotal;


            return order;
        }

        public static void Receipt_Splash(int shipId, int payId)
        {
            //if (mainShoppingCart.Count() != 0)
            //{
            var table = new Table();
            var userinfoTable = new Table();
            var total = 0.00F;

            Console.Clear();

            using (var db = new Models.WebshopContext())
            {
                //
                var subCategorys = ((from subCate in db.SubCategories
                                     select subCate).ToList()).GroupJoin((from category in db.Categories select category).ToList(), sub => sub.CategoryId, cat => cat.Id, (sub, cat) => new { sub, cat });

                //
                var products = ((from product in db.Products select product).ToList()).GroupJoin((from Sub in subCategorys select Sub), prod => prod.SubCategoryId, sub => sub.sub.Id, (prod, sub) => new { prod, sub });

                var supAddProd = products.ToList().GroupJoin(db.Suppliers.ToList(), p => p.prod.SupplierId, sup => sup.Id, (p, sup) => new { p, sup }).ToList();

                var shipment = db.Shipments.Where(s => s.Id == shipId).ToList();
                var paymethod = db.Payments.Where(p => p.Id == payId).ToList();

                table.AddRow("", "Produktnamn", "Färg", "Storlek", "Märke", "Kvantitet", "Pris");

                //
                for (int i = 0; i < mainShoppingCart.Count(); i++)
                {
                    var cartItem = products.ToList().Where(p => p.prod.Id == mainShoppingCart[i].ProductId);
                    foreach (var item in cartItem)
                    {
                        table.AddRow("", $"{item.prod.ProductName}", $"{item.prod.Color}", $"{item.prod.Size}", $"{item.prod.Supplier.Name}", $"{mainShoppingCart[i].Quantity}", $"{(item.prod.UnitPrice) * (int)mainShoppingCart[i].Quantity}");



                    }
                }
                Cart_Total();

                table.AddRow("");
                table.AddRow("", "", "", "", "Frakt:", $"{shipment.FirstOrDefault().CompanyName}", $"{shipment.FirstOrDefault().Freight}");
                table.AddRow("", "", "", "", "", "Moms:", $"{ShopingCart.Total_Tax()}");
                table.AddRow("", "", "", "", "", "Totalt:", $"{(ShopingCart.Cart_Total() + shipment.FirstOrDefault().Freight)}");
                userinfoTable.AddRow($"Tack för att du har handlat hos oss, dina varor skickas med {shipment.FirstOrDefault().CompanyName} och kommer i framtiden!");
                Console.WriteLine(table.ToString());
                Console.WriteLine(userinfoTable.ToString());
                cartItemTotal = Cart_Total() + shipment.FirstOrDefault().Freight;
                cartItemTotalTax = Total_Tax();

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Tryck på Enter för att fortsätta.");
                Console.ReadLine();


            }

            //}
        }
    }

    class CartItem
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }


    }


}
