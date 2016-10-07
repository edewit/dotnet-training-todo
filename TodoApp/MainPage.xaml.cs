using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TodoApp.Annotations;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TodoApp
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
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