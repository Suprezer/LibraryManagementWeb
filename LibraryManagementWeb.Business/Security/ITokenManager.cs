﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Business.Security
{
    public interface ITokenManager
    {
        Task<string?> GetToken(TokenStateEnum currentState);
    }
}
