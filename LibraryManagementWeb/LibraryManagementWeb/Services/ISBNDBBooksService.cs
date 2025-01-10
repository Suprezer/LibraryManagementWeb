using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;

namespace LibraryManagementWeb.Services
{
    public class ISBNDBBooksService : IISBNDBBooksService
    {
        private readonly HttpClient _httpClient;

        public ISBNDBBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria)
        {
            var response = await _httpClient.PostAsJsonAsync("api/ISBNDB", searchCriteria);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BookCollection>();
        }
    }
}
