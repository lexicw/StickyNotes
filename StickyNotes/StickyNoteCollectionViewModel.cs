using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
    class StickyNoteCollectionViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<StickyNoteViewModel> StickyNotesList { get; set; }

        private StickyNote _stickyNote;


        private StickyNote StickyNote
        {
            get => _stickyNote;
            set
            {
                _stickyNote = value;
                OnPropertyChanged(nameof(StickyNote));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
