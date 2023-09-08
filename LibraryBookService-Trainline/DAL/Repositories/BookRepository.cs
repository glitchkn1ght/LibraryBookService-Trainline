﻿using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Models;

namespace LibraryBookService_Trainline.DAL.Repositories
{
    public class InMemoryBookRepository : IBookRepository
    {
        public async Task<Book> GetBook(Guid bookId)
        {
            return await Task.FromResult(new Book(Guid.NewGuid(), "The Silmarillion", "JRR Tolkien", new DateOnly(1977, 9, 15)));
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            List<Book> allBooks = new List<Book> 
            { 
                new Book(Guid.NewGuid(), "The Silmarillion", "JRR Tolkien", new DateOnly(1977, 9, 15)),
                new Book(Guid.NewGuid(), "The Color Of Magic", "Terry Pratchett", new DateOnly(1983, 11, 24)),
                new Book(Guid.NewGuid(), "American Gods", "Neil Gaiman", new DateOnly(2001, 06, 19)),
            };

            return await Task.FromResult(allBooks);
        }
    }
}