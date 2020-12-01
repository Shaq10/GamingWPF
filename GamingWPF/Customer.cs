using System;
using System.Collections.Generic;

#nullable disable

namespace GamingWPF
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int HouseNum { get; set; }
        public string FirstLineAddress { get; set; }
        public string SecondLineAddress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
