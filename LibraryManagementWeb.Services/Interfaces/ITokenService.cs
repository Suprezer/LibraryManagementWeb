using LibraryManagementWeb.Models.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string?> GetNewToken(ApiAccount apiAccount);
    }
}
