﻿using LibraryBookService_Trainline.Models.Books;

namespace LibraryBookService_Trainline.Models.Response
{
    public class MultiBookResponse : GeneralResponse
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
