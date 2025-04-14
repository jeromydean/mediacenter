using MediaCenter.Common.Enums;
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
      //todo later we will have async data access but for now......
      await Task.CompletedTask;

      foreach (string file in Directory.EnumerateFiles(_imageBasePath))
      {
        yield return new MovieModel
        {
          ReleaseDate = DateTime.Now,
          Rating = MPARating.NC17,
          Description = $"{file} description",
          ImageUri = new Uri(new Uri(file).AbsoluteUri),
          MediaUri = new Uri(@"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"),
          Position = .25f,
        };
      }
    }
  }
}