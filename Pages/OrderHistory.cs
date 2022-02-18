using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Final.Models
{
    class OrderHistory
    {
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string Subcategory{ get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }



    }
}
