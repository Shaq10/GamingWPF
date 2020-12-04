using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Order
    {
        public override string ToString()
        {
            //return $"{OrderId} - {Customer.FirstName} - {Game.Title}";
            return $"{OrderId} - {CustomerId} - {GameId}";
        }
    }
}
