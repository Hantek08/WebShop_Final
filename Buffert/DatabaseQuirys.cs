//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Threading;
//using WebShop_Final.Models;

//namespace WebShop_Final

//{
//    class DatabaseQuirys2
//    {
//        public static void CheckOut(ShoppingCart shoppingCart)
//        {
//            using (var db = new Models.WebshopContext())
//            {

//                var shippingPrice = 20.0; //TODO this can come from your db
//                var totalPrice = shoppingCart.CalculateTotalPrice(shippingPrice);

//                //Here you can show what the items in the shoping cart are


//                //Ask the customer which payment they want to
//                //Follow the GetDamProduct to see how you can list the payment methods from db
//                Console.WriteLine("Velg betalingsmetode");
//                var selectedPaymentMethod = Convert.ToInt32(Console.ReadLine());//Valider dette

//                //Now they have paid and we can reduce the stock

//                //Based on the cartItems in the shoppingCart, make Order
//                Order order = new Order();
//                List<OrderDetail> orderDetails = new List<OrderDetail>();
//                foreach (var cartItem in shoppingCart.CartItems)
//                {
//                    var newOrderDetail = new OrderDetail { ProductId = cartItem.ProductId, OrderId = order.Id, Quantity = cartItem.Quantity };
//                    orderDetails.Add(newOrderDetail);
//                    db.OrderDetails.Add(newOrderDetail);
//                    Product product = db.Find<Product>(cartItem.ProductId);
//                    product.UnitInStock = product.UnitInStock - cartItem.Quantity;
//                    db.Products.Update(product);
//                }
//                order.OrderDetails = orderDetails;
//                order.Total = totalPrice;
//                order.PaymentId = selectedPaymentMethod;
//                order.ShipmentId = 1; //Get this from the user?
//                order.UserId = shoppingCart.UserId;
//                order.Tax = 0.25;
//                Console.WriteLine($"totalPrice is: {totalPrice}. Saving order to DB.");
//                db.Orders.Add(order);
//                db.SaveChanges();
//                shoppingCart.EmptyCart();
//            }



//        }
//    }
//}
