using System;
using System.Collections.Generic;
using System.Text;

namespace GamingWPF
{
    public partial class Order
    {
        public override string ToString()
        {       
            return $"{OrderId} - {CustomerId} - {GameId} Ordered on: {OrderDate.ToString("dd/MM/yyyy")} Will be delivered on: {DeliveryDate.ToString("dd/MM/yyyy")}";
        }
    }
}
