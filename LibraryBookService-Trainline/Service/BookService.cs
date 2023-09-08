using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Models.Response;

namespace LibraryBookService_Trainline.Service
{
    public interface IBookService
    {
        public Task<BookResponse> GetBook(Guid id);

        Task<BookResponse> GetAllBooks();
    }

    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBookRepository _bookRepository;

        public BookService(ILogger<BookService> logger, IBookRepository bookRepository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));    
        }

        public async Task<BookResponse> GetBook(Guid bookId)
        {
            BookResponse response = new BookResponse(); 

            var result = await _bookRepository.GetBook(bookId);

            if (result == null)
            {
                response.ResponseStatus.Code = -110;
                response.ResponseStatus.Message = $"No books were found in database for provided book id {bookId}";
            }

            else
            {
                response.Books = result;
            }

            return response;
        }

        public async Task<BookResponse> GetAllBooks()
        {
            BookResponse response = new BookResponse();

            var result = await _bookRepository.GetAllBooks();

            if (result == null)
            {
                response.ResponseStatus.Code = -111;
                response.ResponseStatus.Message = $"No books were found in database. Check database.";
            }

            else
            {
                response.Books = result;
            }

            return response;
        }
    }
}
