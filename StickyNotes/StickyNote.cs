using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes
{
    public class StickyNote
    {
        private DateTime _date;
        public DateTime Date
        {
            get; set;
        }

        private string _text;
        public string Text
        {
            get; set;
        }

        private string _color;
        public string Color
        {
            get; set;
        }

    }
}
