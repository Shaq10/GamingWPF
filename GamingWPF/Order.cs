using System;
using System.Collections.Generic;

#nullable disable

namespace GamingWPF
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public string GameId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Cost { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Game Game { get; set; }
    }
}
