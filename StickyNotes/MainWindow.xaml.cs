using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StickyNotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StickyNotesList = new ObservableCollection<StickyNoteViewModel>();
            DataContext = this;
        }

        public ObservableCollection<StickyNoteViewModel> StickyNotesList { get; set; }

        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var stickyNoteViewModel = new StickyNoteViewModel();

            AddNewStickyNoteWindow addNoteWindow = new AddNewStickyNoteWindow(stickyNoteViewModel);
            if(addNoteWindow.ShowDialog() == true)
            {
                StickyNotesList.Add(stickyNoteViewModel);
            }
        }
    }
}


