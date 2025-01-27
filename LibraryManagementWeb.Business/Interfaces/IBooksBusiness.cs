using LibraryManagementWeb.Models;
using LibraryManagementWeb.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Interfaces
{
    public interface IBooksBusiness
    {
        Task<BookCollection> GetBooksAsync(BookSearchCriteria searchCriteria);
    }
}
