using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Data.Entities
{ 
    public partial class OrderItem
    {
        public int OrderItemId { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? Qunity { get; set; }

        public virtual Product OrderItemNavigation { get; set; }
    }
}
