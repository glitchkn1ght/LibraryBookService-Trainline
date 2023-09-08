using System.Data;

namespace LibraryBookService_Trainline.Interfaces.DAL
{
    public interface IPollyConnectionFactory
    {
        IDbConnection CreateOpenConnection();
    }
}
