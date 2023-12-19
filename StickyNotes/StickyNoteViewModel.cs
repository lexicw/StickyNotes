using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
    public class StickyNoteViewModel : INotifyPropertyChanged
    {

        private StickyNote _stickyNote;

        public StickyNoteViewModel()
        {            
            _stickyNote = new StickyNote();
        }

        private StickyNote StickyNote
        {
            get => _stickyNote;
            set
            {
                _stickyNote = value;
                OnPropertyChanged(nameof(StickyNote));
            }
        }

        public DateTime Date
        {
            get => StickyNote.Date;
            set
            {
                StickyNote.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Text
        {
            get => StickyNote.Text;
            set
            {
                StickyNote.Text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public string Color
        {
            get => StickyNote.Color;
            set
            {
                StickyNote.Color = value;
                OnPropertyChanged(nameof(Color));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
