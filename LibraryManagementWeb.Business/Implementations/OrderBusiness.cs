using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LibraryManagementWeb.Business.Interfaces;
using LibraryManagementWeb.Business.Security;
using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;

namespace LibraryManagementWeb.Business.Implementations
{
    public class OrderBusiness : IOrderBusiness
    {
        private readonly IOrderService _orderService;
        private readonly ITokenManager _tokenManager;

        public OrderBusiness(IOrderService orderService, ITokenManager tokenManager)
        {
            _orderService = orderService;
            _tokenManager = tokenManager;
        }

        public async Task<ICollection<Order>> RetrieveOrders(OrderFilter orderFilter)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _orderService.RetrieveOrders(orderFilter, token);
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _orderService.PlaceOrderAsync(order, token);
        }
    }
}
