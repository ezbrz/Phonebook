namespace Phonebook.Models
{
    public class SearchingFilter
    {
        //class for filtering and searching records
        public string SearchPattern { get; set; }

        public OrderPropertyEnum Property { get; set; }

        public bool IsDecendig { get; set; }
    }
}