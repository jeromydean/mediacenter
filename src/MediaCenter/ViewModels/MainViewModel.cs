using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MediaCenter.Common.Models;
using MediaCenter.DataAccess.Services;

namespace MediaCenter.ViewModels
{
  public class MainViewModel : ObservableObject
  {
    private readonly IMovieService _movieService;

    public ObservableCollection<Uri> ImageUris { get; set; }
    public ICommand ViewLoadedCommand { get; private set; }
    public MainViewModel(IMovieService movieService)
    {
      _movieService = movieService;

      ImageUris = new ObservableCollection<Uri>();

      ViewLoadedCommand = new AsyncRelayCommand(Initialize);
    }
    private async Task Initialize()
    {
      await foreach(MovieModel movie in _movieService.GetAllMovies())
      {
        ImageUris.Add(movie.ImageUri);
      }

      OnPropertyChanged(nameof(ImageUris));
    }
  }
}