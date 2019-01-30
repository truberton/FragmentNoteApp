using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace FragmentNoteApp
{
    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar")]
    class PlayNoteActivity : AppCompatActivity
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
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);
            SetSupportActionBar(toolbar);

            PlayId = Intent.Extras.GetInt("current_play_id", 0);

            var editText = FindViewById<EditText>(Resource.Id.contentEditText);
            editText.Text = DatabaseServices.NotesList[PlayId].Description;
            //var detailsFrag = PlayNoteFragment.NewInstance(playId);
            //FragmentManager.BeginTransaction()
            //                .Add(Android.Resource.Id.Content, detailsFrag)
            //                .Commit();
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            switch (id)
            {
                case Resource.Id.editToolBtn:
                    var editText = FindViewById<EditText>(Resource.Id.contentEditText).Text;
                    DatabaseServices.DatabaseConnection.UpdateNote(DatabaseServices.NotesList[PlayId].Id, editText);
                    DatabaseServices.NotesList[PlayId].Description = editText;
                    MainActivity._mainActivity.Recreate();
                    Finish();
                    break;
                case Resource.Id.deleteToolBtn:
                    DatabaseServices.DatabaseConnection.DeleteNote(DatabaseServices.NotesList[PlayId].Id);
                    DatabaseServices.NotesList.RemoveAt(PlayId);
                    //Important refresh stuff.
                    MainActivity._mainActivity.Recreate();
                    Finish();
                    break;
                default:
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}