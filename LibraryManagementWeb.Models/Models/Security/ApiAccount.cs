﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Models.Models.Security
{
    public class ApiAccount
    {
        public string? JwtToken { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? GrantType { get; set; }
    }
}
