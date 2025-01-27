using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementWeb.Models.Models
{
    public class Borrowing
    {
        public Guid? Id { get; set; }
        public Guid? BookId { get; set; }
        public Book? Book { get; set; }
        public Guid? UserId { get; set; }
        //public IdentityUser User { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
