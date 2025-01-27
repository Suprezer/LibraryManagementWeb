using LibraryManagementWeb.Business.Interfaces;
using LibraryManagementWeb.Business.Security;
using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Implementations
{
    // Implementation of the IISBNDBBooksBusiness interface
    public class ISBNDBBooksBusiness : IISBNDBBooksBusiness
    {
        private readonly IISBNDBBooksService _isbnDbBooksService;
        private readonly ITokenManager _tokenManager;

        // Constructor to initialize the service and token manager dependencies
        public ISBNDBBooksBusiness(IISBNDBBooksService isbnDbBooksService, ITokenManager tokenManager)
        {
            _isbnDbBooksService = isbnDbBooksService;
            _tokenManager = tokenManager;
        }

        // Method to get books from ISBNDB based on search criteria
        public async Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria)
        {
            // Retrieve token with assumption it's valid
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);

            // If the token is null or empty, make another request but this time knowing that its invalid,
            // meaning we need to get a new token
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            // Call the service to get books using the search criteria and token
            return await _isbnDbBooksService.GetISBNDBBooksAsync(searchCriteria, token);
        }
    }
}
