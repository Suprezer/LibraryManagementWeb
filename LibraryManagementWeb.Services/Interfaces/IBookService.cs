using LibraryManagementWeb.Models;

namespace LibraryManagementWeb.Services.Interfaces;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
}