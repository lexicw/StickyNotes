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
        private ObservableCollection<StickyNoteViewModel> noteViewModels;

        public AddNewStickyNoteWindow(ObservableCollection<StickyNoteViewModel> noteViewModels)
        {
            InitializeComponent();
            this.noteViewModels = noteViewModels;

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var newNote = new StickyNoteViewModel();
            noteViewModels.Add(newNote);

            this.Close();
        }
    }
}
