using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
    public class StickyNoteCollectionViewModel : INotifyPropertyChanged
    {
        public StickyNoteCollectionViewModel()
        {
            StickyNotesList = new ObservableCollection<StickyNoteViewModel>();
            StickyNotesListFirstSkipped = new ObservableCollection<StickyNoteViewModel>(StickyNotesList.Skip(1));
        }

        private ObservableCollection<StickyNoteViewModel> _stickyNotesList;
        public ObservableCollection<StickyNoteViewModel> StickyNotesList
        {
            get => _stickyNotesList;
            set
            {
                _stickyNotesList = value;
                OnPropertyChanged(nameof(StickyNotesList));
                UpdateStickyNotesListFirstSkipped();
            }
        }

        private ObservableCollection<StickyNoteViewModel> _stickyNotesListFirstSkipped;
        public ObservableCollection<StickyNoteViewModel> StickyNotesListFirstSkipped
        {
            get => _stickyNotesListFirstSkipped;
            set
            {
                _stickyNotesListFirstSkipped = value;
                OnPropertyChanged(nameof(StickyNotesListFirstSkipped));
            }
        }

        public void UpdateStickyNotesListFirstSkipped()
        {
            StickyNotesListFirstSkipped = new ObservableCollection<StickyNoteViewModel>(StickyNotesList.Skip(1));
        }

        public void RemoveFirstStickyNote()
        {
            if (StickyNotesList.Count > 0)
            {
                StickyNotesList.RemoveAt(0); // Remove the first item
            }
            UpdateStickyNotesListFirstSkipped();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
