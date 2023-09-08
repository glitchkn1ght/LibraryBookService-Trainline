﻿using System.ComponentModel.DataAnnotations;

namespace LibraryBookService_Trainline.Models
{
    public class Book
    {
        public Book() { }
        
        public Book(Guid id, string title, string author, DateOnly publicationDate)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Author { get; set; } = string.Empty;

        public DateOnly PublicationDate { get; set; }
    }
}
