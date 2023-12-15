using System;
using System.Collections.Generic;
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
    /// Interaction logic for StickyNoteUC.xaml
    /// </summary>
    public partial class MainStickyNoteUC : UserControl
    {
        public MainStickyNoteUC()
        {
            InitializeComponent();
            DataContext = new StickyNoteViewModel();
        }

        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Are you sure you want to delete this sticky note?", "Configuration", MessageBoxButton.YesNo, MessageBoxImage.Warning);
        }
    }
}
