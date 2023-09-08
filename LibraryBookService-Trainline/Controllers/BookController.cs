using LibraryBookService_Trainline.Models.Response;
using LibraryBookService_Trainline.Service;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookService_Trainline.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpGet(Name = "GetBookById/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleBookResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleBookResponse))]
        public async Task<IActionResult> Get(Guid bookId)
        {
            SingleBookResponse response = new SingleBookResponse();

            try 
            {
                response = await _bookService.GetBook(bookId);

                return new OkObjectResult(response);
            }

            catch (Exception ex) 
            {
                _logger.LogError($"[Operation=GetBook], Status=Failure, Message=Exception Thrown, details {ex.Message}");

                response.ResponseStatus.Code = 500;
                response.ResponseStatus.Message = "Internal Server Error";
                return new ObjectResult(response) { StatusCode = 500 };
            }
        }

        [HttpGet(Name = "GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BookResponse))]
        public async Task<IActionResult> GetAllBooks()
        {
            BookResponse response = new BookResponse();

            try
            {
                response = await _bookService.GetAllBooks();

                return new OkObjectResult(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"[Operation=GetBook], Status=Failure, Message=Exception Thrown, details {ex.Message}");

                response.ResponseStatus.Code = 500;
                response.ResponseStatus.Message = "Internal Server Error";
                return new ObjectResult(response) { StatusCode = 500 };
            }
        }
    }
}