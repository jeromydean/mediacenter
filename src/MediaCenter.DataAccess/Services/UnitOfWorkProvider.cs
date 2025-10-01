using System.Configuration;
using Microsoft.Data.SqlClient;

namespace MediaCenter.DataAccess.Services
{
  public class UnitOfWorkProvider : IUnitOfWorkProvider
  {
    public async Task<TReturn> ExecuteAsync<TReturn>(Func<SqlConnection, Task<TReturn>> work)
    {
      TReturn returnValue;
      string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

      using (SqlConnection con = new SqlConnection(connectionString))
      {
        try
        {
          await con.OpenAsync();
          returnValue = await work(con);
          await con.CloseAsync();
        }
        catch (Exception e)
        {
          Console.WriteLine(e);
          throw;
        }
      }

      return returnValue;
    }
  }
}