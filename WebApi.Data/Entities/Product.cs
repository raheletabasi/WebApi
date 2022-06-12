using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Data.Entities
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int? Size { get; set; }
        public string Varienty { get; set; }
        public decimal? Price { get; set; }
        public string Status { get; set; }

        public virtual OrderItem OrderItem { get; set; }
    }
}
