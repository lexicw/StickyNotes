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
            DataContext = new StickyNoteCollectionViewModel();
        }

        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (StickyNoteCollectionViewModel)DataContext;

            var stickyNoteViewModel = new StickyNoteViewModel
            {
                Date = DateTime.Now
            };

            AddNewStickyNoteWindow addNoteWindow = new AddNewStickyNoteWindow(stickyNoteViewModel);
            if (addNoteWindow.ShowDialog() == true)
            {
                mainViewModel.StickyNotesList.Insert(0, stickyNoteViewModel);
                mainViewModel.UpdateStickyNotesListFirstSkipped();
            }
        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete this sticky note?", "Configuration", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                var mainViewModel = (StickyNoteCollectionViewModel)DataContext;
                mainViewModel.RemoveFirstStickyNote();
            }
        }

        private void EditTextMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var mainViewModel = (StickyNoteCollectionViewModel)DataContext;

            if (mainViewModel.StickyNotesList.Count > 0)
            {
                var stickyNoteViewModelToEdit = mainViewModel.StickyNotesList[0];

                AddNewStickyNoteWindow addNoteWindow = new AddNewStickyNoteWindow(stickyNoteViewModelToEdit);
                addNoteWindow.addNewNote.Text = "Edit Sticky Note";
                addNoteWindow.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("There are no sticky notes to edit.");
            }
        }

        private StickyNoteViewModel _draggedItem;
        private bool isDragging = false;

        private void StickyNote_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _draggedItem = sender.CastContext<StickyNoteViewModel>();
            DragDrop.DoDragDrop((DependencyObject)sender, _draggedItem, DragDropEffects.Move);
        }

        private void MainNote_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NoteTextBox.Visibility == Visibility.Visible)
            {
                return;
            }

            isDragging = true;
            var mainNote = (StickyNoteViewModel)((FrameworkElement)sender).DataContext;
            if (mainNote != null && isDragging)
            {
                DragDrop.DoDragDrop((DependencyObject)sender, mainNote, DragDropEffects.Move);
            }
        }

        private void ContextMenuButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var button = sender as Button;

            if (button != null && e.ChangedButton == MouseButton.Left)
            {
                button.ContextMenu.IsOpen = true;
                e.Handled = true;
            }
        }

        private void StickyNote_Drop(object sender, DragEventArgs e)
        {
            var droppedData = sender.CastContext<StickyNoteViewModel>();
            if (droppedData != null && e.Data.GetDataPresent(typeof(StickyNoteViewModel)))
            {
                var mainViewModel = (StickyNoteCollectionViewModel)DataContext;
                var target = droppedData;

                var data = e.Data.GetData(typeof(StickyNoteViewModel)) as StickyNoteViewModel;
                if (data != null)
                {
                    if (data == mainViewModel.StickyNotesList[0])
                    {
                        mainViewModel.StickyNotesList.Remove(data);

                        var targetIndex = mainViewModel.StickyNotesList.IndexOf(target) + 1;
                        mainViewModel.StickyNotesList.Insert(targetIndex, data);
                    }
                    else if (data != target)
                    {
                        var oldIndex = mainViewModel.StickyNotesList.IndexOf(data);
                        var newIndex = mainViewModel.StickyNotesList.IndexOf(target);

                        mainViewModel.StickyNotesList.Move(oldIndex, newIndex);

                    }
                    mainViewModel.UpdateStickyNotesListFirstSkipped();
                }
            }

            _draggedItem = null;
        }


        private void StickyNoteUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var clickedNote = sender.CastContext<StickyNoteViewModel>();

            if (clickedNote != null)
            {
                SetAsMainStickyNote(clickedNote);
            }
        }

        private void MainNote_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(StickyNoteViewModel)))
            {
                var draggedNote = e.Data.GetData(typeof(StickyNoteViewModel)) as StickyNoteViewModel;

                if (draggedNote != null)
                {
                    SetAsMainStickyNote(draggedNote);
                }
            }
            e.Handled = true;
        }


        private void NoteTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SetEditMode(true);
            NoteTextBox.Focus();
        }

        private void NoteTextBox_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void NoteTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SetEditMode(false);
        }

        private void NoteTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SetEditMode(false);
            }
        }

        private void SetAsMainStickyNote(StickyNoteViewModel selectedNote)
        {
            var mainViewModel = (StickyNoteCollectionViewModel)DataContext;

            mainViewModel.StickyNotesList.Remove(selectedNote);

            mainViewModel.StickyNotesList.Insert(0, selectedNote);
            mainViewModel.UpdateStickyNotesListFirstSkipped();
        }


        private void SetEditMode(bool editMode)
        {
            if (editMode == true)
            {
                NoteTextBox.Visibility = Visibility.Visible;
                NoteTextBlock.Visibility = Visibility.Collapsed;
            }
            else
            {
                NoteTextBox.Visibility = Visibility.Collapsed;
                NoteTextBlock.Visibility = Visibility.Visible;
            }
        }

    }

    public static class SenderExtensions
    {
        public static T CastContext<T>(this object sender) where T : class
        {
            if (sender is FrameworkElement frameworkElement)
            {
                var dataContext = frameworkElement.DataContext;
                return dataContext as T;
            }

            if (sender is T t)
            {
                return t;
            }

            return null;
        }
    }
}


