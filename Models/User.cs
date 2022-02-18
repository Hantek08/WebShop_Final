using System;
using System.Collections.Generic;

#nullable disable

namespace WebShop_Final.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool? Admin { get; set; }
        public int PostalCodeId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual PostalCode PostalCode { get; set; }
    }
}
