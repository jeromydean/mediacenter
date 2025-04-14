using System.Windows;
using MediaCenter.ViewModels;
using MediaCenter.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MediaCenter.Services
{
  public interface IViewService
  {
    ResultType ShowDialog<ViewType, ViewModelType, ResultType>(IViewModel owner = null, Action<ViewModelType>? viewModelInitialization = null)
      where ViewType : IView
      where ViewModelType : IDialogViewModel<ResultType>;
  }

  public class ViewService : IViewService
  {
    private readonly IServiceProvider _serviceProvider;

    public ViewService(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public ResultType ShowDialog<ViewType, ViewModelType, ResultType>(IViewModel? owner = null, Action<ViewModelType>? viewModelInitialization = null)
      where ViewType : IView
      where ViewModelType : IDialogViewModel<ResultType>
    {
      ViewType view = _serviceProvider.GetRequiredService<ViewType>();

      if (owner != null)
      {
        foreach (Window window in App.Current.Windows)
        {
          if (object.ReferenceEquals(window.DataContext, owner))
          {
            view.Owner = window;
            break;
          }
        }
      }

      ViewModelType viewModel = _serviceProvider.GetRequiredService<ViewModelType>();

      if (viewModelInitialization != null)
      {
        viewModelInitialization(viewModel);
      }

      view.DataContext = viewModel;

      bool? showDialogResult = view.ShowDialog();
      ResultType? dialogResult = viewModel.DialogResult;
      return dialogResult;
    }
  }
}
