using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication2
{
  public class IndexFromContainerConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      var item = value as ListBoxItem;
      if (item != null) {
        var itemsControl = GetItemsControl(item);
        if (itemsControl != null) {
          var index = itemsControl.ItemContainerGenerator.IndexFromContainer(item);
          return index;
        }
      }
      return -1;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      return DependencyProperty.UnsetValue;
    }

    private ItemsControl GetItemsControl(DependencyObject root)
    {
      while (root != null) {
        root = VisualTreeHelper.GetParent(root);
        if (root is ItemsControl) {
          return (ItemsControl)root;
        }
      }
      return null;
    }
  }
}