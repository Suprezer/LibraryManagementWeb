using System.ComponentModel.DataAnnotations;
using LibraryManagement.Application.DTOs;

namespace LibraryManagementAPI.DTOs
{
    public class Book
    {
        public Guid Id { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        //[StringLength(100)]
        public string Title { get; set; }

        [Required]
        //[StringLength(50)]
        public IEnumerable<Author> Authors { get; set; }

        [Required]
        //[StringLength(50)]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }
    }
}
