using System.Collections.Generic;


namespace WebShop.Models
{
    //TODO maybe have a constructor that takes in the user id, so that you can avoid creating a shopping cart without a user
    public class ShoppingCart
    {
        private static int ID = 0;
        private int cartId = 0;

        public int CartId
        {
            get { return cartId; }
        }

        public  int UserId { get; set; }
        public List<CartItem> CartItems { get; set; }

        public ShoppingCart()
        {
            ID++;
            this.cartId = ID;
            this.CartItems = new List<CartItem>();
        }

        public void AddToCart(CartItem cartItem)
        {
            CartItems.Add(cartItem);

        }

        public void RemoveItem(CartItem cartItem)
        {
            CartItems.Remove(cartItem);
        }
        public void EmptyCart()
        {
            CartItems = new List<CartItem>();
        }

        public double CalculateTotalPrice(double shippingPrice)
        {
            
            var totalPrice = shippingPrice;
            foreach (var item in CartItems)
            {
                totalPrice += item.UnitPrice * item.Quantity;
            }

            return totalPrice;
        }

    }
    public class CartItem
    {
        public int cartId { get; set; }
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

    }

}
