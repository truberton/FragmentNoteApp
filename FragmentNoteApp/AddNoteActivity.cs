using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace FragmentNoteApp
{
    [Activity(Label = "Note")]
    class AddNoteActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.add_note);

            var noteBtn = FindViewById<Button>(Resource.Id.addNote);
            noteBtn.Click += NoteBtn_Click;
        }

        private void NoteBtn_Click(object sender, EventArgs e)
        {
            string title = FindViewById<EditText>(Resource.Id.titleText).Text;
            string cont = FindViewById<EditText>(Resource.Id.contentText).Text;
            var db = new DatabaseServices();
            db.CreateDatabase();

            db.AddNote(title, cont);
            FindViewById<EditText>(Resource.Id.titleText).Text = "";
            FindViewById<EditText>(Resource.Id.contentText).Text = "";
        }
    }
}