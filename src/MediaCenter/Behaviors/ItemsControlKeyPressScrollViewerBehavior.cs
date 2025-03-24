using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Xaml.Behaviors;

namespace MediaCenter.Behaviors
{
  public class ItemsControlKeyPressScrollViewerBehavior : Behavior<ItemsControl>
  {
    protected override void OnAttached()
    {
      AssociatedObject.KeyDown += AssociatedObject_KeyDown;
    }

    private void AssociatedObject_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
    {
      if (e.Key == Key.PageDown)
      {
        ScrollViewer scrollViewer = GetScrollViewer();
      }
    }

    private ScrollViewer GetScrollViewer()
    {
      int childCount = VisualTreeHelper.GetChildrenCount(AssociatedObject);
      for(int c = 0; c < childCount; c++)
      {
        DependencyObject child = VisualTreeHelper.GetChild(AssociatedObject, c);
      }

      return new ScrollViewer();
    }
  }
}
