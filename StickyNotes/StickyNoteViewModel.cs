using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
    public class StickyNoteViewModel : INotifyPropertyChanged
    {
        private StickyNote _stickyNote;

        public StickyNote StickyNote
        {
            get => _stickyNote;
            set
            {
                _stickyNote = value;
                OnPropertyChanged(nameof(StickyNote));
            }
        }

        public StickyNoteViewModel()
        {
            // Initialize a default StickyNote
            StickyNote = new StickyNote
            {
                Date = DateTime.Now,
                Text = "Sample Text",
                Color = "White"
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
