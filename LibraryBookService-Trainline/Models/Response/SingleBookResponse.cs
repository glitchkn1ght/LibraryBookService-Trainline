namespace LibraryBookService_Trainline.Models.Response
{
    public class SingleBookResponse
    {
        public ResponseStatus ResponseStatus { get; set; }  = new ResponseStatus();
        
        public Book Book { get; set; } = new Book();
    }
}
