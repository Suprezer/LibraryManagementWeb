using LibraryManagementWeb.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Interfaces
{
    public interface IBorrowingBusiness
    {
        Task<Guid> BorrowBookAsync(Borrowing borrowing);
        Task<ICollection<Borrowing>> GetBorrowingBooksByUserIdAsync(Guid userId);
    }
}
