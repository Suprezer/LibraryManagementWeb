using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManagementWeb.Models
{
    public class Book
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string CoverImage { get; set; }
        public string TitleLong { get; set; }
        public string PublishedDate { get; set; }
        public string Publisher { get; set; }
        public string Synopsis { get; set; }
        public ICollection<string> Authors { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn { get; set; }
        public string Isbn10 { get; set; }
        public string Language { get; set; }
        public int Pages { get; set; }
        public string Edition { get; set; }
        public int Quantity { get; set; }

        // Purely FE properties
        [JsonIgnore]
        public bool IsSelected { get; set; } = false;
        [JsonIgnore]
        public int TempQuantity { get; set; } = 1;

        public Book()
        {
            
        }
    }
}
