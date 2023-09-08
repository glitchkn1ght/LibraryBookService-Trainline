namespace LibraryBookService_Trainline.Models.Response
{
    public class MultiBookResponse
    {
        public ResponseStatus ResponseStatus { get; set; } = new ResponseStatus();

        public IEnumerable<Book> Books { get; set; }
    }
}
