using MahApps.Metro.Controls;
using MediaCenter.ViewModels;

namespace MediaCenter.Views
{
  /// <summary>
  /// Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : MetroWindow
  {
    public MainView(MainViewModel dataContext)
    {
      DataContext = dataContext;
      InitializeComponent();
    }

    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      SearchFlyout.IsOpen = true;
    }
  }
}