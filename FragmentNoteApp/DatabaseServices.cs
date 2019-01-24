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
        public SQLiteConnection db;
        public static DatabaseServices DatabaseConnection { get; set; }
        public static List<Note> NotesList { get; set; }

        public DatabaseServices()
        {
            CreateDatabase();
            CreateTableWithData();
            NotesList = GetAllNotes().ToList();
        }

        public void CreateDatabase()
        {
            string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "mydatabase6.db3");
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

        public void UpdateNote(int id, string description)
        {
            var newNote = new Note
            {
                Id = id,
                Title = GetOneNote(id).Title,
                Description = description
            };
            db.Update(newNote);
        }

        public TableQuery<Note> GetAllNotes()
        {
            var table = db.Table<Note>();
            return table;
        }

        public void DeleteNote(int id)
        {
            var noteToDelete = new Note();
            noteToDelete.Id = id;
            db.Delete(noteToDelete);
        }

        public Note GetOneNote(int id)
        {
            var table = GetAllNotes();
            foreach (var item in table)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}