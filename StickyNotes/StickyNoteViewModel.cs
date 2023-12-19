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

        public void AddDummyNote()
        {
            StickyNote = new StickyNote
            {
                Date = DateTime.Now,
                Text = GetRandomText(),
                Color = GetRandomColor()
            };
        }

        private string GetRandomText()
        {
            string[] availableTexts = new string[] {
        "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit.",
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
        "Lorem ipsum dolor sit amet."
    };
            Random rnd = new Random();
            return availableTexts[rnd.Next(availableTexts.Length)];
        }

        private string GetRandomColor()
        {
            string[] availableColors = new string[] { "#e4f0ea", "#f3d8da", "#fdf3d1", "White" };
            Random rnd = new Random();
            return availableColors[rnd.Next(availableColors.Length)];
        }


        //public void AddNewNote()
        //{
        //    StickyNoteViewModel newNote = new StickyNoteViewModel();

        //    newNote.Color = "Yellow";
        //    newNote.Date = DateTime.Now;
        //    newNote.Text = "This is a new note";

        //    // Add the new note view model to the list
        //    StickyNotesList.Add(newNote);
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
