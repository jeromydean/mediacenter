namespace MediaCenter.Views
{
  public interface IView
  {
    public object DataContext { get; set; }
    public void Show();
    public bool? ShowDialog();
    public System.Windows.Window Owner { get; set; }
  }
}