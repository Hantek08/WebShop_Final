using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final
{
    class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public double Total { get; set; }
        public DateTime BillDate { get; set; }
        public int UserId { get; set; }
        public int PaymentId { get; set; }
        public int ShipmentId { get; set; }
        public double Tax { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
}
