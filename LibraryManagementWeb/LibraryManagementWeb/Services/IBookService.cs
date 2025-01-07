using LibraryManagementWeb.Models;

namespace LibraryManagementWeb.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
}