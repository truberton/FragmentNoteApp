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

            List<string> notesList = DatabaseServices.NotesList.Select(x => x.Description).ToList();

            //var textView = new TextView(Activity);
            //var padding = Convert.ToInt32(TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Activity.Resources.DisplayMetrics));
            //textView.SetPadding(padding, padding, padding, padding);
            //textView.TextSize = 24;
            var editText = Activity.FindViewById<EditText>(Resource.Id.contentEditText);
            //try
            //{
                editText.Text = notesList[PlayId];
            //}
            //catch (Exception)
            //{
            //    editText.Text = notesList[0];
            //}

            //var scroller = new ScrollView(Activity);
            //scroller.AddView(textView);

            return null;
        }
    }
}