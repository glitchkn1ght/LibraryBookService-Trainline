using LibraryBookService_Trainline.Interfaces.Service;
using LibraryBookService_Trainline.Models.Books;
using LibraryBookService_Trainline.Models.Response;
using LibraryBookService_Trainline.Validation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryBookService_Trainline.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IModelStateValidator _modelStateValidator;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IModelStateValidator modelStateValidator ,IBookService bookService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _modelStateValidator = modelStateValidator ?? throw new ArgumentNullException(nameof(modelStateValidator));
            _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
        }

        [HttpGet(Name = "GetBookById/{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleBookResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleBookResponse))]
        public async Task<IActionResult> GetBookById([NotEmpty] Guid bookId)
        {
            SingleBookResponse response = new SingleBookResponse();

            try 
            {
                if (!ModelState.IsValid)
                {
                    response.ResponseStatus = _modelStateValidator.MapModelStateErrors(ModelState, response.ResponseStatus);
                    return BadRequest(response);
                }

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

        [HttpGet("GetAllBooks")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MultiBookResponse))]
        public async Task<IActionResult> GetAllBooks()
        {
            MultiBookResponse response = new MultiBookResponse();

            try
            {
                response = await _bookService.GetAllBooks();

                return new OkObjectResult(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"[Operation=GetAllBooks], Status=Failure, Message=Exception Thrown, details {ex.Message}");

                response.ResponseStatus.Code = 500;
                response.ResponseStatus.Message = "Internal Server Error";
                return new ObjectResult(response) { StatusCode = 500 };
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SingleBookResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(SingleBookResponse))]
        public async Task<IActionResult> InsertBook([FromBody] BookRequest bookRequest)
        {
            GeneralResponse response = new GeneralResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    response.ResponseStatus = _modelStateValidator.MapModelStateErrors(ModelState, response.ResponseStatus);
                    return BadRequest(response);
                }

                Book bookToAdd = new Book(Guid.NewGuid(), bookRequest.Title, bookRequest.Author, bookRequest.PublicationDate);

                response = await _bookService.InsertNewBook(bookToAdd);

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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GeneralResponse))]
        public async Task<IActionResult> DeleteBook([NotEmpty] Guid bookId)
        {
            GeneralResponse response = new GeneralResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    response.ResponseStatus = _modelStateValidator.MapModelStateErrors(ModelState, response.ResponseStatus);
                    return BadRequest(response);
                }

                response = await _bookService.DeleteBook(bookId);

                return new OkObjectResult(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"[Operation=DeleteBook], Status=Failure, Message=Exception Thrown, details {ex.Message}");

                response.ResponseStatus.Code = 500;
                response.ResponseStatus.Message = "Internal Server Error";
                return new ObjectResult(response) { StatusCode = 500 };
            }
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GeneralResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GeneralResponse))]
        public async Task<IActionResult> UpdateBook(BookRequest updateBookRequest)
        {
            GeneralResponse response = new GeneralResponse();

            try
            {
                if (!ModelState.IsValid)
                {
                    response.ResponseStatus = _modelStateValidator.MapModelStateErrors(ModelState, response.ResponseStatus);
                    return BadRequest(response);
                }

                Book book = new Book(Guid.NewGuid(), updateBookRequest.Title, updateBookRequest.Author, updateBookRequest.PublicationDate);

                response = await _bookService.UpdateBook(book);

                return new OkObjectResult(response);
            }

            catch (Exception ex)
            {
                _logger.LogError($"[Operation=UpdateBook], Status=Failure, Message=Exception Thrown, details {ex.Message}");

                response.ResponseStatus.Code = 500;
                response.ResponseStatus.Message = "Internal Server Error";
                return new ObjectResult(response) { StatusCode = 500 };
            }
        }
    }
}