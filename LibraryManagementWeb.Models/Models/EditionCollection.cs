namespace LibraryManagementWeb.Models
{
    public class EditionCollection
    {
        public int totalEditions { get; set; }
        public ICollection<Edition> Editions { get; set; }
    }
}
