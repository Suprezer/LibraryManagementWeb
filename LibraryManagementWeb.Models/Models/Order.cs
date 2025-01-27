using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWeb.Models
{
    public class Order
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
        //public int TotalBooks => OrderLines.Count;

        public Order()
        {
        }
    }
}
