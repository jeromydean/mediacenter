using System.IO;
using System.Windows;
using MediaCenter.DataAccess.Services;
using MediaCenter.ViewModels;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCenter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  protected override void OnStartup(StartupEventArgs e)
  {
    ServiceCollection serviceCollection = new ServiceCollection();
    ConfigureServices(serviceCollection);

    IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    MainView mainView = serviceProvider.GetRequiredService<MainView>();
    mainView.Show();
  }

  private static void ConfigureServices(IServiceCollection services)
  {
    services.AddTransient<IMovieService, MovieService>(_ => new MovieService(Settings.ContentImageFolderLocation));

    services.AddTransient<MainViewModel>();
    services.AddTransient<MainView>();
  }
}