using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Interfaces.Service;
using LibraryBookService_Trainline.Models;
using LibraryBookService_Trainline.Models.Response;

namespace LibraryBookService_Trainline.Service
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookRepository _bookRepository;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));    
        }

        public async Task<GeneralResponse> InsertNewBook(Book book)
        {
            GeneralResponse response = new GeneralResponse();

            var result = await _bookRepository.Insert(book);

            if (result != 0)
            {
                response.ResponseStatus.Code = -112;
                response.ResponseStatus.Message = $"Could not insert book into database.";
            }

            else
            {
                response.ResponseStatus.Code = 0;
                response.ResponseStatus.Message = $"Successfully inserted book with book id {book.Id} into database.";
            }

            return response;
        }

        public async Task<MultiBookResponse> GetAllBooks()
        {
            MultiBookResponse response = new MultiBookResponse();

            var result = await _bookRepository.GetAllBooks();

            if (result == null)
            {
                response.ResponseStatus.Code = -111;
                response.ResponseStatus.Message = $"No books were found in database. Check database.";
            }

            else
            {
                response.ResponseStatus.Code = 0;
                response.ResponseStatus.Message = $"Successfully retrieved all books from database.";
                response.Books = result;
            }

            return response;
        }

        public async Task<SingleBookResponse> GetBook(Guid bookId)
        {
            SingleBookResponse response = new SingleBookResponse();

            var result = await _bookRepository.GetBook(bookId);

            if (result == null)
            {
                response.ResponseStatus.Code = -110;
                response.ResponseStatus.Message = $"No book was found in database for provided book id {bookId}";
            }

            else
            {
                response.ResponseStatus.Code = 0;
                response.ResponseStatus.Message = $"BookRequest found in database for provided book id {bookId}";
                response.Book = result;
            }

            return response;
        }

        public async Task<GeneralResponse> UpdateBook(Book book)
        {
            GeneralResponse response = new GeneralResponse(); 

            var result = await _bookRepository.Update(book);

            if (result != 0)
            {
                response.ResponseStatus.Code = -111;
                response.ResponseStatus.Message = $"Could not update details for provided book id {book.Id}";
            }

            else
            {
                response.ResponseStatus.Code = 0;
                response.ResponseStatus.Message = $"Successfully updated details in database for provided book id {book.Id}";
            }

            return response;
        }

        public async Task<GeneralResponse> DeleteBook(Guid bookId)
        {
            GeneralResponse response = new GeneralResponse();

            int result = await _bookRepository.Delete(bookId);

            if (result != 0)
            {
                response.ResponseStatus.Code = -110;
                response.ResponseStatus.Message = $"No book was found in database for provided book id {bookId}";
            }

            else
            {
                response.ResponseStatus.Code = 0;
                response.ResponseStatus.Message = $"Succesfully deleted book for provided book id {bookId}";
            }

            return response;
        }
    }
}
