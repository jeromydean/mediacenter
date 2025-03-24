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

  private void ConfigureServices(IServiceCollection services)
  {
    services.AddTransient<IMovieService, MovieService>((sp) =>
    {
      //TODO read this in from the config
      return new MovieService(Path.Combine(Environment.CurrentDirectory,@"..\..\..\..\..\..\images"));
    });

    services.AddTransient<MainViewModel>();
    services.AddTransient<MainView>();
  }
}

