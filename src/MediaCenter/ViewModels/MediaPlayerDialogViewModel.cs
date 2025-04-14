using System.Windows.Input;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibVLCSharp.Shared;
using LibVLCSharp.WPF;

namespace MediaCenter.ViewModels
{
  public partial class MediaPlayerDialogViewModel : ObservableObject, IClosableViewModel
  {
    public Uri MediaUri { get; set; }
    public float Position { get; set; }
    public Action CloseAction { get; set; }
    public ICommand CloseCommand { get; private set; }
    public ICommand ViewLoadedCommand { get; private set; }
    public MediaPlayerDialogViewModel()
    {
      CloseCommand = new RelayCommand(Close);
      //ViewLoadedCommand = new AsyncRelayCommand(() => { });
    }

    private void Close()
    {
      CloseAction?.Invoke();
    }
  }
}
