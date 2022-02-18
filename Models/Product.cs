using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? SubCategoryId { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }

        public virtual SubCategory SubCategory { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
