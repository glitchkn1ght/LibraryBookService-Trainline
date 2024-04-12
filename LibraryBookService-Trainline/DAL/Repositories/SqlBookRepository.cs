using Dapper;
using LibraryBookService_Trainline.Interfaces.DAL;
using LibraryBookService_Trainline.Models.Books;
using LibraryBookService_Trainline.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Data;
using System.Net;

namespace LibraryBookService_Trainline.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IPollyConnectionFactory ConnectionFactory;
        private readonly BookRepositorySettings BookRepositorySettings;

        public BookRepository(IPollyConnectionFactory connectionFactory, IOptions<BookRepositorySettings> tradesRepositorySettings)
        {
            ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
            BookRepositorySettings = tradesRepositorySettings.Value;
        }

        public async Task<int> Insert(Book book)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@BookId", book.Id);
                parameters.Add("@Author", book.Author);
                parameters.Add("@Title", book.Title);
                parameters.Add("@PublicationDate", book.PublicationDate);

                parameters.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(this.BookRepositorySettings.InsertProc, parameters, commandType: CommandType.StoredProcedure);

                var result = parameters.Get<int>("@retVal");

                return result;
            }
        }

        public async Task<Book?> GetBook(Guid bookId)
        {
            using (IDbConnection connection = ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@BookId", bookId);

                var books = await connection.QueryAsync<Book>(this.BookRepositorySettings.GetProc, parameters, commandType: CommandType.StoredProcedure);

                return books.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            using (IDbConnection connection = ConnectionFactory.CreateOpenConnection())
            {
                var books = await connection.QueryAsync<Book>(this.BookRepositorySettings.GetProc, commandType: CommandType.StoredProcedure);

                return books;
            }
        }

        public async Task<int> Update(Book book)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@BookId", book.Id);
                parameters.Add("@Author", book.Author);
                parameters.Add("@Title", book.Title);
                parameters.Add("@PublicationDate", book.PublicationDate);

                parameters.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(this.BookRepositorySettings.UpdateProc, parameters, commandType: CommandType.StoredProcedure);

                var result = parameters.Get<int>("@retVal");

                return result;
            }
        }

        public async Task<int> Delete(Guid bookId)
        {
            using (IDbConnection connection = this.ConnectionFactory.CreateOpenConnection())
            {
                var parameters = new DynamicParameters();

                parameters.Add("@BookId", bookId);

                parameters.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await connection.ExecuteAsync(this.BookRepositorySettings.DeleteProc, parameters, commandType: CommandType.StoredProcedure);

                var result = parameters.Get<int>("@retVal");

                return result;
            }
        }
    }
}
