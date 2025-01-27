using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;

namespace LibraryManagementWeb.Services.Interfaces;

public interface IBookService
{
    Task<BookCollection> GetBooksAsync(BookSearchCriteria searchCriteria, string token);
}