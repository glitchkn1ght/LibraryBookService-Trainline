using LibraryBookService_Trainline.Models;

namespace LibraryBookService_Trainline.Interfaces.DAL
{
    public interface IBookRepository
    {
        Task<Book> GetBook(Guid bookId);

        Task<IEnumerable<Book>> GetAllBooks();
    }
}