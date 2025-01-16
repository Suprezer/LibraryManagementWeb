using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services
{
    public class ISBNDBBooksService : IISBNDBBooksService
    {
        private readonly HttpClient _httpClient;

        public ISBNDBBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsJsonAsync("api/ISBNDB", searchCriteria);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BookCollection>();
        }
    }
}
