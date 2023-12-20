using System;
using System.Collections;
using System.Collections.Generic;
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

        private void EditTextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NoteTextBox.Visibility = Visibility.Visible;
            NoteTextBlock.Visibility = Visibility.Collapsed;
            NoteTextBox.Focus();
        }

        private void NoteTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            NoteTextBlock.Visibility = Visibility.Visible;
            NoteTextBox.Visibility = Visibility.Collapsed;

        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsClickWithinTextBox(e.GetPosition(this)))
            {
                NoteTextBlock.Visibility = Visibility.Visible;
                NoteTextBox.Visibility = Visibility.Collapsed;

            }
        }

        private bool IsClickWithinTextBox(Point position)
        {
            // Check if the clicked position falls within the TextBox bounds
            return NoteTextBox.TransformToAncestor(this).TransformBounds(new Rect(0, 0, NoteTextBox.ActualWidth, NoteTextBox.ActualHeight)).Contains(position);
        }
    }
}
