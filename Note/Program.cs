using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> notes = new List<string>
            {
                "до", "ре", "ми", "фа", "соль", "ля", "си"
            };
            new Note(notes[0]).Play();
            new Note(notes[0], true).Play();
            Console.WriteLine((string)new Note(notes[1]));
            Console.WriteLine((string)new LoudNote(notes[0]));
            Console.WriteLine((string)new DefaultNote());
            Console.WriteLine((string)new NoteWithOctave(8,notes[5]));
        }
    }
    class Note
    {
        protected string NotePitch { get; set; }
        protected bool is_long { get; set; }
        protected Dictionary<string, string> LongestNotes = new Dictionary<string, string>
        {
            ["до"] = "до-о",
            ["ре"] = "ре-э",
            ["ми"] ="ми-и",
            ["фа"] = "фа-а",
            ["соль"] = "со-оль",
            ["ля"] = "ля-а",
            ["си"] = "си-и",
        };
        public Note(string notePitch):this(notePitch, false)
        {

        }
        public Note(string notePitch,bool lenght)
        {
            if (lenght)
                NotePitch = LongestNotes[notePitch];
            else
                NotePitch = notePitch;
            is_long = lenght;
        }

        public Note()
        {
        }

        public void Play()
        {
            Console.WriteLine(NotePitch);
        }
        public static implicit operator string(Note note)
        {
            return note.NotePitch;
        }
    }
    class LoudNote : Note
    {
        public LoudNote(string notePitch) : base(notePitch.ToUpper())
        {
        }
    }
    class DefaultNote : Note
    {
        public DefaultNote() : base("до")
        {
        }
    }
    class NoteWithOctave : Note
    {
        static int Octavew;
        public NoteWithOctave(int octavew, string notePitch) :base(notePitch)
        {          
            Octavew = octavew;
        }
        public static implicit operator string(NoteWithOctave note)
        {
            return $"{note.NotePitch}({Octavew.ToString()})";
        }
    }
}
