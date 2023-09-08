using LibraryBookService_Trainline.Models.Books;
using LibraryBookService_Trainline.Models.Response;

namespace LibraryBookService_Trainline.Interfaces.Service
{
    public interface IBookService
    {
        public Task<GeneralResponse> InsertNewBook(Book book);

        public Task<SingleBookResponse> GetBook(Guid id);

        public Task<MultiBookResponse> GetAllBooks();

        public Task<GeneralResponse> UpdateBook(Book book);

        public Task<GeneralResponse> DeleteBook(Guid bookId);
    }
}
