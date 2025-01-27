using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System.Net.Http.Json;


namespace LibraryManagementWeb.Services.Services;

public class BookService : IBookService
{
    private readonly HttpClient _httpClient;

    public BookService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BookCollection> GetBooksAsync(BookSearchCriteria searchCriteria, string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var response = await _httpClient.PostAsJsonAsync("api/books/search", searchCriteria);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<BookCollection>();
    }
}