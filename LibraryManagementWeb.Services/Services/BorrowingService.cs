using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Models;
using LibraryManagementWeb.Models.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly HttpClient _httpClient;

        public BorrowingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Guid> BorrowBookAsync(Borrowing borrowing, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync($"api/borrowing/borrow?bookId={borrowing.BookId}&userId={borrowing.UserId}", borrowing);
            response.EnsureSuccessStatusCode();

            Guid borrowingId = await response.Content.ReadFromJsonAsync<Guid>();

            if (borrowingId == Guid.Empty)
            {
                throw new Exception("Attemp at borrowing the book has failed");
            }
            else
            {
                return borrowingId;
            }
        }

        public async Task<ICollection<Borrowing>> GetBorrowingsByUserId(Guid userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/borrowing/user/" + userId);
            response.EnsureSuccessStatusCode();

            ICollection<Borrowing> borrowings = await response.Content.ReadFromJsonAsync<ICollection<Borrowing>>();

            return borrowings;
        }
    }
}
