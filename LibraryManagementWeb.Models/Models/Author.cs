﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Models
{
    public class Author
    {
        public Guid? Id { get; set; }
        public string AuthorKey { get; set; }
        public string AuthorName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Biography { get; set; }
    }
}
