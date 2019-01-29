using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace FragmentNoteApp
{
    public class PlayNoteFragment : Fragment
    {
        public int PlayId => Arguments.GetInt("current_play_id", 0);

        public static int StatPlayId { get; set; }
        public static EditText StatEditText { get; set; }

        public static PlayNoteFragment NewInstance(int playId)
        {
            var bundle = new Bundle();
            bundle.PutInt("current_play_id", playId);
            return new PlayNoteFragment { Arguments = bundle };
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (container == null)
            {
                return null;
            }
            var notes = DatabaseServices.DatabaseConnection.GetAllNotes();

            StatPlayId = PlayId;

            List<string> notesList = DatabaseServices.NotesList.Select(x => x.Description).ToList();

            var editText = Activity.FindViewById<EditText>(Resource.Id.contentEditText);
            StatEditText = editText;
            try
            {
                editText.Text = notesList[PlayId];
            }
            catch (Exception)
            {
                editText.Text = notesList[0];
            }

            return null;
        }

        //private void EditBtn_Click(object sender, EventArgs e)
        //{
        //    DatabaseServices.DatabaseConnection.UpdateNote(DatabaseServices.NotesList[PlayId].Id, _editText.Text);
        //    DatabaseServices.NotesList[PlayId].Description = _editText.Text;

        //    //Very important, please never forget this line.
        //    Activity.Recreate();
        //}

        //private void DeleteBtn_Click(object sender, EventArgs e)
        //{
        //    DatabaseServices.DatabaseConnection.DeleteNote(DatabaseServices.NotesList[PlayId].Id);
        //    DatabaseServices.NotesList.RemoveAt(PlayId);

        //    //Very important, please never forget this line.
        //    Activity.Recreate();
        //}
    }
}