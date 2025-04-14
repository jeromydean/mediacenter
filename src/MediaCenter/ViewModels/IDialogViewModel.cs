namespace MediaCenter.ViewModels
{
  public interface IDialogViewModel<T> : IViewModel, IClosableViewModel
  {
    public T? DialogResult { get; set; }
  }
}
