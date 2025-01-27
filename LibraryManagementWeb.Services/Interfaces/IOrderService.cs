using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services.Interfaces
{
    public interface IOrderService
    {
        Task<ICollection<Order>> RetrieveOrders(OrderFilter orderFilter, string token);
        Task<bool> PlaceOrderAsync(Order order, string token);
    }
}
