using System.ComponentModel.DataAnnotations;

namespace LibraryBookService_Trainline.Models
{
    public class BookRequest
    {
        public BookRequest() { }
        
        public BookRequest(string title, string author, DateOnly publicationDate)
        {
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Author { get; set; } = string.Empty;

        public DateOnly PublicationDate { get; set; }
    }
}
