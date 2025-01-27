using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;

namespace LibraryManagementWeb.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<Order>> RetrieveOrders(OrderFilter orderFilter, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/order/GetOrders", orderFilter);
            response.EnsureSuccessStatusCode();

            ICollection<Order> orders = await response.Content.ReadFromJsonAsync<ICollection<Order>>();

            return orders;
        }

        public async Task<bool> PlaceOrderAsync(Order order, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Adding a Guid to all the books in the order
            foreach (var orderLine in order.OrderLines)
            {
                orderLine.Book.Id = Guid.NewGuid();
            }

            // Serialize the order object to JSON and log it
            var orderJson = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
            Console.WriteLine("Order JSON Payload: " + orderJson);

            var response = await _httpClient.PostAsJsonAsync("api/order", order);
            response.EnsureSuccessStatusCode();

            return response.IsSuccessStatusCode;
        }
    }
}
