using LibraryManagementWeb.Business.Interfaces;
using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementWeb.Models.Models;
using LibraryManagementWeb.Business.Security;
using LibraryManagementWeb.Services.Interfaces;
using LibraryManagementWeb.Models.Models.Filters;
using LibraryManagementWeb.Services.Services;

namespace LibraryManagementWeb.Business.Implementations
{
    public class BorrowingBusiness : IBorrowingBusiness
    {
        private readonly IBorrowingService _borrowingService;
        private readonly ITokenManager _tokenManager;

        public BorrowingBusiness(IBorrowingService borrowingService, ITokenManager tokenManager)
        {
            _borrowingService = borrowingService;
            _tokenManager = tokenManager;
        }

        public async Task<Guid> BorrowBookAsync(Borrowing borrowing)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _borrowingService.BorrowBookAsync(borrowing, token);
        }

        public async Task<ICollection<Borrowing>> GetBorrowingBooksByUserIdAsync(Guid userId)
        {
            var token = await _tokenManager.GetToken(TokenStateEnum.Valid);
            if (string.IsNullOrEmpty(token))
            {
                token = await _tokenManager.GetToken(TokenStateEnum.Invalid);
            }

            return await _borrowingService.GetBorrowingsByUserId(userId, token);
        }
    }
}
