using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;

namespace LibraryManagementWeb.Services.Interfaces
{
    public interface IISBNDBBooksService
    {
        Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria, string token);
    }
}
