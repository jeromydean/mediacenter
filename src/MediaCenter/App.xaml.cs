using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MediaCenter.DataAccess.Services;
using MediaCenter.Services;
using MediaCenter.ViewModels;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCenter;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
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
    //services.AddTransient<IMovieService, MovieService>(_ => new MovieService(@"C:\Users\user\source\repos\images"));

    services.AddTransient<MainViewModel>();
    services.AddTransient<MainView>();

    services.AddTransient<MovieDialogViewModel>();
    services.AddTransient<MovieDialogView>();

    services.AddTransient<MediaPlayerDialogViewModel>();
    services.AddTransient<MediaPlayerDialog>();

    services.AddSingleton<IDialogCoordinator>(DialogCoordinator.Instance);
    services.AddSingleton<IViewService, ViewService>();

    //may need to make this lazy....  sometimes it takes a while to load
    services.AddSingleton<IVLCProvider>(new VLCProvider());
  }
}