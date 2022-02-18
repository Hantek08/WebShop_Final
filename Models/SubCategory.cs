using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public string SubCategoryName { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
