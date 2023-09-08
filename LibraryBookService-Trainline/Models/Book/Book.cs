using System.ComponentModel.DataAnnotations;

namespace LibraryBookService_Trainline.Models.Books
{
    public class Book
    {
        public Book() { }

        public Book(Guid id, string title, string author, DateTime publicationDate)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Author { get; set; } = string.Empty;

        public DateTime PublicationDate { get; set; }
    }
}
