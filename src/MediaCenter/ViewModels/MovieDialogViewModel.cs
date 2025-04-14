using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using MediaCenter.Common.Models;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCenter.ViewModels
{
  public class MovieDialogViewModel : ObservableObject
  {
    private readonly IDialogCoordinator _dialogCoordinator;
    private readonly IServiceProvider _serviceProvider;
    private readonly MovieModel _movieModel;
    
    public ICommand CloseCommand { get; private set; }
    public ICommand PlayCommand { get; private set; }
    public MovieDialogViewModel(IDialogCoordinator dialogCoordinator,
      IServiceProvider serviceProvider,
      MovieModel movieModel,
      Action<MovieDialogViewModel> closeHandler)
    {
      _dialogCoordinator = dialogCoordinator;
      _serviceProvider = serviceProvider;
      _movieModel = movieModel;
      
      CloseCommand = new RelayCommand<object>((MovieDialogViewModel) => closeHandler(this));
      PlayCommand = new AsyncRelayCommand(Play);
    }
    public async Task Play()
    {
      //todo put this into a service so we don't have all this logic here
      //also can remove the IServiceProvider
      MediaPlayerDialog? mpd = null;
      MediaPlayerDialogViewModel? mpdvm = null;
      mpd = _serviceProvider.GetRequiredService<MediaPlayerDialog>();
      mpd.DataContext = (mpdvm = new MediaPlayerDialogViewModel
      {
        MediaUri = _movieModel.MediaUri,
        Position = _movieModel.Position,
        CloseAction = () =>
        {
          _dialogCoordinator.HideMetroDialogAsync(this, mpd);
        }
      });

      //doesn't await custom dialogs
      await _dialogCoordinator.ShowMetroDialogAsync(this, mpd);

      //so we need to await this
      await mpd.WaitUntilUnloadedAsync();

      //todo save this so we can resume @ the same position
      double position = mpdvm.Position;
    }
  }
}
