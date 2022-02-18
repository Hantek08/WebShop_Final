using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? PostalCodeId { get; set; }

        public virtual PostalCode PostalCode { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
