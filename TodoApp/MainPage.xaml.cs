using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TodoApp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<TodoItem> _orginalList;
        public ObservableCollection<TodoItem> Items { get; }

        public MainPage()
        {
            InitializeComponent();
            Items = new ObservableCollection<TodoItem>();
            DataContext = this;
        }

        private void AddItem_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.Empty.Equals(ItemTextBox.Text.Trim()))
            {
                return;
            }
            Items.Add(new TodoItem() { CreateTime = DateTime.Now, Description = ItemTextBox.Text});
            ItemTextBox.Text = "";
        }

        private void FilterList_OnClick(object sender, RoutedEventArgs e)
        {
            var isChecked = ((CheckBox) sender).IsChecked;
            if (isChecked != null && (bool) isChecked)
            {
                var items = Items.Where(item => item.Done).ToList();
                _orginalList = Items.ToList();
                FilterList(items);
            }
            else
            {
                FilterList(_orginalList);
            }
        }

        private void FilterList(IEnumerable<TodoItem> items)
        {
            Items.Clear();
            items.ToList().ForEach(item => Items.Add(item));
        }
    }

    public sealed class DoneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool) value ? new SolidColorBrush(Colors.LightGreen) : new SolidColorBrush(Colors.LightCoral);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}