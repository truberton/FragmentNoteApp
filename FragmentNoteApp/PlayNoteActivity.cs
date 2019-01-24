using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FragmentNoteApp
{
    [Activity(Label = "PlayQuoteActivity")]
    class PlayNoteActivity : Activity
    {
        private int PlayId { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            if (Resources.Configuration.Orientation == Android.Content.Res.Orientation.Landscape)
            {
                Finish();
            }
            SetContentView(Resource.Layout.view_note);

            PlayId = Intent.Extras.GetInt("current_play_id", 0);

            var editText = FindViewById<EditText>(Resource.Id.contentEditText);
            editText.Text = DatabaseServices.NotesList[PlayId].Description;
            //var detailsFrag = PlayNoteFragment.NewInstance(playId);
            //FragmentManager.BeginTransaction()
            //                .Add(Android.Resource.Id.Content, detailsFrag)
            //                .Commit();
            var editBtn = FindViewById<Button>(Resource.Id.editBtn);
            var deleteBtn = FindViewById<Button>(Resource.Id.deleteBtn);

            editBtn.Click += EditBtn_Click;
            deleteBtn.Click += DeleteBtn_Click;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DatabaseServices.DatabaseConnection.DeleteNote(DatabaseServices.NotesList[PlayId].Id);
            DatabaseServices.NotesList.RemoveAt(PlayId);
            Finish();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            var editText = FindViewById<EditText>(Resource.Id.contentEditText).Text;
            DatabaseServices.DatabaseConnection.UpdateNote(DatabaseServices.NotesList[PlayId].Id, editText);
            DatabaseServices.NotesList[PlayId].Description = editText;
            Finish();
        }
    }
}