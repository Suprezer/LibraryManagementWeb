using LibraryManagementWeb.Models.Filters;
using LibraryManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Interfaces
{
    public interface IISBNDBBooksBusiness
    {
        Task<BookCollection> GetISBNDBBooksAsync(BookSearchCriteria searchCriteria);
    }
}
