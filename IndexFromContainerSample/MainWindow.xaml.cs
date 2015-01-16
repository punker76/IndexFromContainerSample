using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;

namespace WpfApplication2
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      this.TestCollection = new ObservableCollection<int>();
      for (var i = 0; i < 20; i++) {
        this.TestCollection.Add(i);
      }

      InitializeComponent();
    }

    public ObservableCollection<int> TestCollection { get; set; }

    private void FilterCheckBoxOnClick(object sender, RoutedEventArgs e)
    {
      var coll = this.TestCollection;
      var collView = CollectionViewSource.GetDefaultView(coll);
      collView.Filter += o => {
                           if (filterCheckBox.IsChecked.GetValueOrDefault()) {
                             return (((int)o) % 2) == 0;
                           }
                           return true;
                         };
    }
  }
}