using System.Data;

namespace LibraryBookService_Trainline.Interfaces
{
    public interface IPollyConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}
