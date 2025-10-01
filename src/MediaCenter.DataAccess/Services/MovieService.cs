using System.Data;
using Dapper;
using MediaCenter.Common.Models;

namespace MediaCenter.DataAccess.Services
{
  public class MovieService : IMovieService
  {
    private readonly string _imageBasePath;
    private readonly IUnitOfWorkProvider _unitOfWorkProvider;

    public MovieService(string imageBasePath,
      IUnitOfWorkProvider unitOfWorkProvider)
    {
      _imageBasePath = imageBasePath;
      _unitOfWorkProvider = unitOfWorkProvider;
    }

    public async IAsyncEnumerable<MovieModel> GetAllMovies()
    {
      var movieModels = await _unitOfWorkProvider.ExecuteAsync<List<MovieModel>>(async con =>
      {
        List<MovieModel> models = new List<MovieModel>();
        DynamicParameters parameters = new DynamicParameters();

        SqlMapper.GridReader gridReader = await con.QueryMultipleAsync("dbo.GetMovie", parameters, null, null, CommandType.StoredProcedure);

        var movies = gridReader.Read<Movie>().ToList();
        var movieFiles = gridReader.Read<MovieFile>().ToList();
        var movieGenres = gridReader.Read<MovieGenre>().ToList();
        var movieLanguages = gridReader.Read<MovieLanguage>().ToList();
        var movieCast = gridReader.Read<MovieCast>().ToList();
        var movieSeriesPositions = gridReader.Read<MovieSeriesPosition>().ToList();
        var movieSeries = gridReader.Read<MovieSeries>().ToList();
        var movieCategories = gridReader.Read<MovieCategory>().ToList();

        foreach (Movie movie in movies)
        {
          MovieModel model = new MovieModel();
          model.Movie = movie;
          model.MovieFiles = movieFiles.Where(f => f.movie_id == movie.id).ToList();
          model.MovieGenres = movieGenres.Where(f => f.movie_id == movie.id).ToList();
          model.MovieLanguages = movieLanguages.Where(f => f.movie_id == movie.id).ToList();
          model.MovieCast = movieCast.Where(f => f.movie_id == movie.id).ToList();
          model.MovieSeriesPosition = movieSeriesPositions.FirstOrDefault(f => f.movie_id == movie.id);
          model.MovieSeries = movieSeries.FirstOrDefault(f => f.id == model.MovieSeriesPosition?.series_id);
          model.MovieCategories = movieCategories.Where(f => f.movie_id == movie.id).ToList();

          model.ImageUri = new Uri(new Uri($"{_imageBasePath}{movie.id}.jpg").AbsoluteUri);
          model.MediaUri = new Uri(@"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4");
          model.Position = .25f;

          models.Add(model);
        }

        return models;
      });


      foreach (var model in movieModels)
      {
        yield return model;
      }
    }
  }
}