using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementWeb.Models
{
    public class OrderLine
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Book Book { get; set; }
        public int Quantity { get; set; }

        public OrderLine()
        {
        }
    }
}
