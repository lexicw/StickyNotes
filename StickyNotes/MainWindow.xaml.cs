﻿using System;
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
        private ObservableCollection<StickyNoteViewModel> noteViewModels = new ObservableCollection<StickyNoteViewModel>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            var initialNote = new StickyNoteViewModel();
            noteViewModels.Add(initialNote);
        }

        public ObservableCollection<StickyNoteViewModel> NoteViewModels
        {
            get { return noteViewModels; }
            set { noteViewModels = value; }
        }


        private void AddNewNoteButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewStickyNoteWindow addNoteWindow = new AddNewStickyNoteWindow(noteViewModels);
            addNoteWindow.ShowDialog();
        }
    }
}


