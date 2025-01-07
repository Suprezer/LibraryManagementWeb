using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;

namespace LibraryManagementWeb.Services
{
    public interface IOpenLibraryBookService
    {
        Task<IEnumerable<Book>> GetOpenLibraryBooksAsync(BookSearchCriteria criteria);
    }
}
