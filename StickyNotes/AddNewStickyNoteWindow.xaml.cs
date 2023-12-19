using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for AddNewStickyNoteWindow.xaml
    /// </summary>
    public partial class AddNewStickyNoteWindow : Window
    {
        public AddNewStickyNoteWindow(StickyNoteViewModel stickyNoteViewModel)
        {
            InitializeComponent();
            ViewModel = stickyNoteViewModel;
            DataContext = ViewModel;

            ColorStackPanel.DataContext = this;

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;

            ViewModel.Color = "#FFFFFF";
        }

        public StickyNoteViewModel ViewModel { get; }


        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void ColorRadioButton_Click(object sender, RoutedEventArgs e)
        {
            var checkedValue = ColorStackPanel.Children.OfType<RadioButton>().FirstOrDefault(r => r.IsChecked.HasValue && r.IsChecked.Value);
            var color = checkedValue.Background;

            ViewModel.Color = color.ToString();
        }

    }

    [ValueConversion(typeof(object), typeof(bool))]
    public class EqualityToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter?.Equals(value) ?? false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

}
