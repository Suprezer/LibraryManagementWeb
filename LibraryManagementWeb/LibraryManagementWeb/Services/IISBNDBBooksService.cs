using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;

namespace LibraryManagementWeb.Services
{
    public interface IISBNDBBooksService
    {
        Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria);
    }
}
