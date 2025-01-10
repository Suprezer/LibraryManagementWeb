namespace LibraryManagementWeb.Models
{
    public class BookCollection
    {
        public int TotalBooks { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
