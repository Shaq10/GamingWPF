using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Customer
    {
        public override string ToString()
        {
            return $"{CustomerId} - {FirstName} - {LastName}";
        }
    }
}
