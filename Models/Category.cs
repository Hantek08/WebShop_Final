using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
