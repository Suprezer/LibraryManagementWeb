using LibraryManagementWeb.Business.Interfaces;
using LibraryManagementWeb.Business.Security;
using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Models.Models.Filters;
using LibraryManagementWeb.Services.Interfaces;
using LibraryManagementWeb.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Implementations
{
    public class BooksBusiness : IBooksBusiness
    {
        private readonly IBookService _bookService;
        private readonly ITokenManager _tokenManager;

        public BooksBusiness(IBookService bookService, ITokenManager tokenManager)
        {
            _bookService = bookService;
            _tokenManager = tokenManager;
        }

        public async Task<BookCollection> GetBooksAsync(BookSearchCriteria searchCriteria)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _bookService.GetBooksAsync(searchCriteria, token);
        }
    }
}
