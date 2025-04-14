using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using MediaCenter.Common.Models;
using MediaCenter.DataAccess.Services;
using MediaCenter.Services;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCenter.ViewModels
{
  public partial class MainViewModel : BaseViewModel
  {
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly IViewService _viewService;
    private readonly IMovieService _movieService;
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private bool _showTitleBar = true;

    public ObservableCollection<MovieModel> Movies { get; set; }
    public ICommand ViewLoadedCommand { get; private set; }
    public ICommand ViewMovieDialogCommand { get; private set; }
    public MainViewModel(IDialogCoordinator dialogCoordinator,
      IViewService viewService,
      IMovieService movieService,
      IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
      _dialogCoordinator = dialogCoordinator;
      _viewService = viewService;
      _movieService = movieService;

      Movies = new ObservableCollection<MovieModel>();

      ViewLoadedCommand = new AsyncRelayCommand(Initialize);
      ViewMovieDialogCommand = new AsyncRelayCommand<MovieModel>(ViewMovieDialog);
    }

    private async Task Initialize()
    {
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