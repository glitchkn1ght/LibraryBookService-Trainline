using LibraryBookService_Trainline.Models.Books;

namespace LibraryBookService_Trainline.Interfaces.DAL
{
    public interface IBookRepository
    {
        Task<int> Insert(Book book);

        Task<Book> GetBook(Guid bookId);

        Task<IEnumerable<Book>> GetAllBooks();

        Task<int> Update(Book book);

        Task<int> Delete(Guid bookId);
    }
}