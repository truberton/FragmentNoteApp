using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace FragmentNoteApp
{
    class DatabaseServices
    {
        SQLiteConnection db;

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase.db3");
            db = new SQLiteConnection(dbPath);
        }

        public void CreateTableWithData()
        {
            db.CreateTable<Note>();
            if (db.Table<Note>().Count() == 0)
            {
                var newNote = new Note
                {
                    Title = "Monday",
                    Description = "Eksamid"
                };
                db.Insert(newNote);
                newNote.Title = "Tuesday";
                newNote.Description = "Varem tööle";
                db.Insert(newNote);
                newNote.Title = "Wednesday";
                newNote.Description = "Kooli pole vaja minna";
                db.Insert(newNote);
            }
        }

        public void AddNote(string title, string description)
        {
            var newNote = new Note
            {
                Title = title,
                Description = description
            };
            db.Insert(newNote);
        }

        public TableQuery<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table;
        }

        public void DeleteNote(int id)
        {
            var noteToDelete = new Note();
            noteToDelete.Id = ValueHolder.IdList[id];
            db.Delete(noteToDelete);
        }
    }
}