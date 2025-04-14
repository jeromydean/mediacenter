using System.ComponentModel;
using System.Windows;

namespace MediaCenter.Views
{
  /// <summary>
  /// Interaction logic for MediaPlayerControls.xaml
  /// </summary>
  public partial class MediaPlayerControls : Window, INotifyPropertyChanged
  {
    public class PositionChangedEventArgs : EventArgs
    {
      public double Value { get; set; }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private bool _ignoreViewControlsChanges;
    private bool _ignoreWindowsControlsChanges;

    public event EventHandler PausePlayPressed;
    public event EventHandler<PositionChangedEventArgs> PositionChanged;

    private double _position = 0d;
    private long _length = 0;

    public double Position
    {
      get
      {
        return _position;
      }
      set
      {
        if (_position != value)
        {
          _position = value;
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
          PositionChanged?.Invoke(this, new PositionChangedEventArgs { Value = value });
        }
      }
    }

    public long Length
    {
      get
      {
        return _length;
      }
      set
      {
        if (_length != value)
        {
          _length = value;
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Length)));
        }
      }
    }
    public MediaPlayerControls()
    {
      InitializeComponent();
    }

    public void SetPosition(float position)
    {
      _position = position;
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
    }

    private void controlsRegion_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
      if (!_ignoreViewControlsChanges
        && !viewerControls.IsOpen)
      {
        viewerControls.IsOpen = true;
        _ignoreViewControlsChanges = true;
        viewerControls.IsAutoCloseEnabled = false;
      }
    }

    private void viewerControls_ClosingFinished(object sender, System.Windows.RoutedEventArgs e)
    {
      _ignoreViewControlsChanges = false;
      viewerControls.IsAutoCloseEnabled = false;
    }

    private void viewerControls_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
      viewerControls.IsAutoCloseEnabled = true;
    }

    private void windowRegion_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
    {
      if (!_ignoreWindowsControlsChanges
        && !windowControls.IsOpen)
      {
        windowControls.IsOpen = true;
        _ignoreWindowsControlsChanges = true;
        windowControls.IsAutoCloseEnabled = false;
      }
    }

    private void windowControls_ClosingFinished(object sender, System.Windows.RoutedEventArgs e)
    {
      _ignoreWindowsControlsChanges = false;
      windowControls.IsAutoCloseEnabled = false;
    }

    private void windowControls_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
    {
      windowControls.IsAutoCloseEnabled = true;
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
      Close();
    }

    private void PausePlay_Click(object sender, RoutedEventArgs e)
    {
      PausePlayPressed?.Invoke(this, e);
    }
  }
}
