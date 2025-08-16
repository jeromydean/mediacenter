using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dapper;
using MahApps.Metro.Controls.Dialogs;
using MediaCenter.Common.Models;
using MediaCenter.DataAccess.Services;
using MediaCenter.Services;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;
using static Dapper.SqlMapper;
using Movie = MediaCenter.Common.Models.Movie;

namespace MediaCenter.ViewModels
{
  public partial class MainViewModel : BaseViewModel
  {
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly IViewService _viewService;
    private readonly IMovieService _movieService;
    private readonly IServiceProvider _serviceProvider;
    private readonly IUnitOfWorkProvider _unitOfWorkProvider;

    [ObservableProperty]
    private bool _showTitleBar = true;

    public ObservableCollection<MovieModel> Movies { get; set; }
    public ICommand ViewLoadedCommand { get; private set; }
    public ICommand ViewMovieDialogCommand { get; private set; }
    public MainViewModel(IDialogCoordinator dialogCoordinator,
      IViewService viewService,
      IMovieService movieService,
      IServiceProvider serviceProvider,
      IUnitOfWorkProvider unitOfWorkProvider)
    {
      _serviceProvider = serviceProvider;
      _dialogCoordinator = dialogCoordinator;
      _viewService = viewService;
      _movieService = movieService;
      _unitOfWorkProvider = unitOfWorkProvider;

      Movies = new ObservableCollection<MovieModel>();

      ViewLoadedCommand = new AsyncRelayCommand(Initialize);
      ViewMovieDialogCommand = new AsyncRelayCommand<MovieModel>(ViewMovieDialog);
    }

    private async Task Initialize()
    {
     await _unitOfWorkProvider.ExecuteAsync<int>(async (con) =>
      {

        DynamicParameters parameters = new DynamicParameters();
        parameters.Add("@id", 10001,
          dbType: System.Data.DbType.Int64);

        GridReader gridReader = await con.QueryMultipleAsync("dbo.GetMovie",
          parameters,
          commandType: System.Data.CommandType.StoredProcedure);

        var movies = gridReader.ReadFirst<Movie>();
        var movieFiles = gridReader.Read<MovieFile>().ToList();

        return 1;
      });



      //      int rowsAffected = await unitOfWorkProvider.ExecuteAsync<int>(async (con) =>
      //      {
      //        var movies = await con.QueryAsync<Movie, MovieCast, Movie>(@"SELECT TOP (10)
      //m.id , m.unique_movie_title, m.title, m.year, m.imdb_link, m.rating, 
      //m.votes, m.summary, m.last_update_date, m.own_this_movie, m.mpaa_rating_id,
      //mc.id [movie_cast_id], mc.movie_id, mc.actor_name
      //FROM
      //Movie AS m INNER JOIN
      //             MovieCast AS mc ON m.id = mc.movie_id
      //ORDER BY
      //  m.id ASC", (m, mc) =>
      //        {
      //          m.Cast.Add(mc);
      //          return m;
      //        }, splitOn: "movie_cast_id");

      //        var result = movies.GroupBy(p => p.id).Select(g =>
      //        {
      //          var groupedPost = g.First();
      //          groupedPost.Cast = g.Select(p => p.Cast.Single()).ToList();
      //          return groupedPost;
      //        });



      //        return 1;
      //      });


      //      List<Movie> movies = (await unitOfWorkProvider.ExecuteAsync<IEnumerable<Movie>>((con) =>
      //      {
      //        return con.QueryAsync<Movie>(@"SELECT
      //  TOP 10 *
      //FROM
      //  Movie");
      //      })).ToList();







      await foreach (MovieModel movie in _movieService.GetAllMovies())
      {
        Movies.Add(movie);
      }

      OnPropertyChanged(nameof(Movies));




    }

    private async Task ViewMovieDialog(MovieModel movieModel)
    {
      MovieDialogView? mpd = null;
      MovieDialogViewModel? mpdvm = null;
      mpd = _serviceProvider.GetRequiredService<MovieDialogView>();
      mpd.DataContext = (mpdvm = new MovieDialogViewModel(_dialogCoordinator,
        _serviceProvider,
        movieModel ,(v) =>
      {
        _dialogCoordinator.HideMetroDialogAsync(this, mpd);
      }));

      //doesn't await custom dialogs
      await _dialogCoordinator.ShowMetroDialogAsync(this, mpd);
      await mpd.WaitUntilUnloadedAsync();
    }
  }
}