using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class PostalCode
    {
        public PostalCode()
        {
            Suppliers = new HashSet<Supplier>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string PostalCode1 { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Supplier> Suppliers { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
