namespace LibraryBookService_Trainline.Models
{
    public class Book
    {
        public Book(Guid id, string title, string author, DateOnly publicationDate)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateOnly PublicationDate { get; set; }
    }
}
