using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services
{
    // Implementation of the IISBNDBBooksService interface
    public class ISBNDBBooksService : IISBNDBBooksService
    {
        private readonly HttpClient _httpClient;

        // Constructor to initialize the HttpClient dependency
        public ISBNDBBooksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Method to get books from ISBNDB based on search criteria and token
        public async Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria, string token)
        {
            // Set the authorization header with the provided token
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Send a POST request with the search criteria to the "api/ISBNDB" endpoint
            var response = await _httpClient.PostAsJsonAsync("api/ISBNDB", searchCriteria);

            // Ensure the response indicates success, status code 200-299
            response.EnsureSuccessStatusCode();

            // Read the response content as a BookCollection object
            var books = await response.Content.ReadFromJsonAsync<BookCollection>();

            // Return the BookCollection object
            return books;
        }
    }
}
