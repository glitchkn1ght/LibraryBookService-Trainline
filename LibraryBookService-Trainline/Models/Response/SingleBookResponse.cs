namespace LibraryBookService_Trainline.Models.Response
{
    public class SingleBookResponse : GeneralResponse
    {   
        public Book Book { get; set; } = new Book();
    }
}
