using System.Windows;
using MediaCenter.ViewModels;

namespace MediaCenter.Views
{
  /// <summary>
  /// Interaction logic for MainView.xaml
  /// </summary>
  public partial class MainView : Window
  {
    public MainView(MainViewModel dataContext)
    {
      DataContext = dataContext;
      InitializeComponent();
    }
  }
}