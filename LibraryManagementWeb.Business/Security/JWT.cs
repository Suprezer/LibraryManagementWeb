using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Security
{
    public static class JWT
    {
        // Purely for holding the current JWT
        public static string? CurrentJWT { get; set; }

    }
}
