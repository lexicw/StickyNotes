using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        public StickyNoteViewModel ViewModel { get; }

        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }

}
