using Dapper;
using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Models;
using LibraryBookService_Trainline.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics;

namespace LibraryBookService_Trainline.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IPollyConnectionFactory ConnectionFactory;
        private readonly BookRepositorySettings TradesRepositorySettings;

        public BookRepository(IPollyConnectionFactory connectionFactory, IOptions<BookRepositorySettings> tradesRepositorySettings)
        {
            ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            TradesRepositorySettings = tradesRepositorySettings.Value;
        }

        public async Task<Book> GetBook(Guid bookId)
        {
            return new Book()
            {
                Id = bookId,
                Title = "The Silmarillion",
                Author = "JRR Tolkien",
                PublicationDate = new DateOnly(1977, 9, 15)
            };


            using (IDbConnection connection = ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@BookId", bookId);
                
                var books = await connection.QueryAsync<Book>(this.TradesRepositorySettings.GetProc, parameters, commandType: CommandType.StoredProcedure);

                return books.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            List<Book> allBooks = new List<Book> 
            { 
                new Book(Guid.NewGuid(), "The Silmarillion", "JRR Tolkien", new DateOnly(1977, 9, 15)),
                new Book(Guid.NewGuid(), "The Color Of Magic", "Terry Pratchett", new DateOnly(1983, 11, 24)),
                new Book(Guid.NewGuid(), "American Gods", "Neil Gaiman", new DateOnly(2001, 06, 19)),
            };
            
            
            using (IDbConnection connection = ConnectionFactory.CreateOpenConnection())
            {
                var books = await connection.QueryAsync<Book>(this.TradesRepositorySettings.GetProc, commandType: CommandType.StoredProcedure);

                return books;
            }
        }
    }
}
