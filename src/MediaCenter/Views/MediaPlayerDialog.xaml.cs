using LibVLCSharp.Shared;
using MahApps.Metro.Controls.Dialogs;
using MediaCenter.ViewModels;

namespace MediaCenter.Views
{
  /// <summary>
  /// Interaction logic for MediaPlayerDialog.xaml
  /// </summary>
  public partial class MediaPlayerDialog : CustomDialog
  {
    private readonly IVLCProvider _vlcProvider;

    private MediaPlayerControls? _playerControls;
    private bool _mediaEndReached;

    public MediaPlayerDialog(IVLCProvider vlcProvider)
    {
      InitializeComponent();
      _vlcProvider = vlcProvider;
    }

    private void MediaPlayerDialog_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
      videoView.MediaPlayer = new MediaPlayer(_vlcProvider.Instance);
      videoView.MediaPlayer.Play(new Media(_vlcProvider.Instance, ((MediaPlayerDialogViewModel)DataContext).MediaUri));
      videoView.MediaPlayer.Position = ((MediaPlayerDialogViewModel)DataContext).Position;
      videoView.MediaPlayer.PositionChanged += MediaPlayer_PositionChanged;
      videoView.MediaPlayer.EndReached += MediaPlayer_EndReached;

      System.Windows.Point videoViewLocation = PointToScreen(new System.Windows.Point(0, 0));

      _playerControls = new MediaPlayerControls
      {
        Width = ActualWidth,
        Height = ActualHeight,
        Left = videoViewLocation.X,
        Top = videoViewLocation.Y,
        Position = ((MediaPlayerDialogViewModel)DataContext).Position,
        Length = videoView.MediaPlayer.Length
      };

      _playerControls.Closed += _playerControls_Closed;
      _playerControls.PausePlayPressed += _playerControls_PausePlayPressed;
      _playerControls.PositionChanged += _playerControls_PositionChanged;
      _playerControls.Show();
    }

    private void MediaPlayer_EndReached(object? sender, EventArgs e)
    {
      _mediaEndReached = true;
      Dispatcher.BeginInvoke(() => _playerControls?.Close());
    }

    private void MediaPlayer_PositionChanged(object? sender, MediaPlayerPositionChangedEventArgs e)
    {
      if (_playerControls != null)
      {
        _playerControls.SetPosition(e.Position);
        _playerControls.Length = videoView?.MediaPlayer?.Length ?? 0;
      }
    }

    private void _playerControls_PositionChanged(object? sender, MediaPlayerControls.PositionChangedEventArgs e)
    {
      if (videoView.MediaPlayer != null)
      {
        videoView.MediaPlayer.Position = (float)e.Value;
      }
    }

    private void _playerControls_PausePlayPressed(object? sender, EventArgs e)
    {
      if (videoView.MediaPlayer != null && videoView.MediaPlayer.IsPlaying)
      {
        videoView.MediaPlayer.Pause();
      }
      else
      {
        videoView.MediaPlayer?.Play();
      }
    }

    private void _playerControls_Closed(object? sender, EventArgs e)
    {
      if (DataContext is MediaPlayerDialogViewModel model)
      {
        model.CloseAction();
      }
    }

    protected override void OnClose()
    {
      if (_playerControls != null)
      {
        _playerControls.Closed -= _playerControls_Closed;
        _playerControls.PausePlayPressed -= _playerControls_PausePlayPressed;
        _playerControls.PositionChanged -= _playerControls_PositionChanged;
        _playerControls = null;
      }

      ((MediaPlayerDialogViewModel)DataContext).Position = _mediaEndReached
        ? 0f
        : videoView?.MediaPlayer?.Position ?? 0f;

      videoView?.MediaPlayer?.Stop();
      videoView?.MediaPlayer?.Dispose();
      videoView?.Dispose();

      base.OnClose();
    }
  }
}