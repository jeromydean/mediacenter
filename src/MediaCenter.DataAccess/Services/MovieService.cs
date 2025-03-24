using MediaCenter.Common.Models;

namespace MediaCenter.DataAccess.Services
{
  public class MovieService : IMovieService
  {
    private readonly string _imageBasePath;

    public MovieService(string imageBasePath)
    {
      _imageBasePath = imageBasePath;
    }

    public async IAsyncEnumerable<MovieModel> GetAllMovies()
    {
      //later we will have async data access but for now......
      await Task.CompletedTask;

      foreach (string file in Directory.EnumerateFiles(_imageBasePath))
      {
        yield return new MovieModel
        {
          ImageUri = new Uri(new Uri(file).AbsoluteUri)
        };
      }
    }
  }
}