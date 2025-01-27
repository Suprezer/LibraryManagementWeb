using LibraryManagementWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services.Interfaces
{
    public interface IBorrowingService
    {
        Task<Guid> BorrowBookAsync(Borrowing borrowing, string token);
        Task<ICollection<Borrowing>> GetBorrowingsByUserId(Guid userId, string token);
    }
}
