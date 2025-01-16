using LibraryManagementWeb.Business.Interfaces;
using LibraryManagementWeb.Business.Security;
using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Implementations
{
    public class ISBNDBBooksBusiness : IISBNDBBooksBusiness
    {
        private readonly IISBNDBBooksService _isbnDbBooksService;
        private readonly ITokenManager _tokenManager;

        public ISBNDBBooksBusiness(IISBNDBBooksService isbnDbBooksService, ITokenManager tokenManager)
        {
            _isbnDbBooksService = isbnDbBooksService;
            _tokenManager = tokenManager;
        }

        public async Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _isbnDbBooksService.GetISBNDBBooksAsync(searchCriteria, token);
        }
    }
}
