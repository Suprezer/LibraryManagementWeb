using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Interfaces
{
    public interface IOrderBusiness
    {
        Task<ICollection<Order>> RetrieveOrders(OrderFilter orderFilter);
        Task<bool> PlaceOrderAsync(Order order);
    }
}
