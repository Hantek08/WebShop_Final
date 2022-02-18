using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class Shipment
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int Freight { get; set; }
    }
}
