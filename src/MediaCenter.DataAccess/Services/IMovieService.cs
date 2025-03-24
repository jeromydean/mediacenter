using MediaCenter.Common.Models;

namespace MediaCenter.DataAccess.Services
{
  public interface IMovieService
  {
    IAsyncEnumerable<MovieModel> GetAllMovies();
  }
}