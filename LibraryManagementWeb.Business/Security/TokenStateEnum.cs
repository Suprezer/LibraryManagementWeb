using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Security
{
    public enum TokenStateEnum
    {
        Unregistered,
        Registered,
        Valid,
        Invalid
    }
}
