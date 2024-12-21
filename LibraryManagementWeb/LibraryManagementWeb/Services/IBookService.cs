using LibraryManagementAPI.DTOs;

namespace LibraryManagementWeb.Services;

public interface IBookService
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
}