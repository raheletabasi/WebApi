using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public string Status { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonsId { get; set; }

        public virtual SalesPerson Order1 { get; set; }
        public virtual Customer OrderNavigation { get; set; }
    }
}
