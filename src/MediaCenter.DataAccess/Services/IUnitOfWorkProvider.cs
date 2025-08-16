using Microsoft.Data.SqlClient;

namespace MediaCenter.DataAccess.Services
{
  public interface IUnitOfWorkProvider
  {
    Task<TReturn> ExecuteAsync<TReturn>(Func<SqlConnection, Task<TReturn>> func);
  }
}