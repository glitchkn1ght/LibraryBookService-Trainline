using LibraryBookService_Trainline.Validation;
using System.ComponentModel.DataAnnotations;

namespace LibraryBookService_Trainline.Models.Books
{
    public class InsertBookRequest
    {
        public InsertBookRequest() { }

        public InsertBookRequest(string title, string author, DateTime publicationDate)
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

        [Required(AllowEmptyStrings = false)]
        [DateInPast]
        public DateTime PublicationDate { get; set; }
    }
}
