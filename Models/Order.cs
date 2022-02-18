
using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public DateTime BillDate { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public int ShipmentId { get; set; }
        public double Tax { get; set; }
        public DateTime? ShippedDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
