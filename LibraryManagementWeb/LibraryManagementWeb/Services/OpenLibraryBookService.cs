using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using System.Net.Http.Json;
using System.Text.Json;

namespace LibraryManagementWeb.Services
{
    public class OpenLibraryBookService : IOpenLibraryBookService
    {
        private readonly HttpClient _httpClient;
        public OpenLibraryBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Book>> GetOpenLibraryBooksAsync(BookSearchCriteria criteria)
        {
            // To make the format match the required format by the API, we need to create a new object with the searchCriteria property
            // TODO: Better solution for this
            var requestPayload = new
            {
                searchCriteria = criteria
            };

            var jsonPayload = JsonSerializer.Serialize(requestPayload);

            var response = await _httpClient.PostAsJsonAsync("api/OpenLibraryBooks", requestPayload);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<Book>>();
        }
    }
}
