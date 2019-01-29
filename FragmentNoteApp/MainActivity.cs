using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace FragmentNoteApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public Bundle _savedInstanceState { get; set; }
        public static MainActivity _mainActivity { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _mainActivity = this;
            AppCenter.Start("72405402-098f-448e-b266-7433631d2f8a",
       typeof(Analytics), typeof(Crashes));
            AppCenter.Start("72405402-098f-448e-b266-7433631d2f8a", typeof(Analytics), typeof(Crashes));
            AppCenter.Start("72405402-098f-448e-b266-7433631d2f8a", typeof(Distribute));
            DatabaseServices.DatabaseConnection = new DatabaseServices();
            //DatabaseServices.DatabaseConnection.CreateDatabase();
            //DatabaseServices.DatabaseConnection.CreateTableWithData();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
            _mainActivity = this;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (true)
            {
                switch (id)
                {
                    case Resource.Id.editToolBtn:
                        DatabaseServices.DatabaseConnection.UpdateNote(DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].Id, PlayNoteFragment.StatEditText.Text);
                        DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].Description = PlayNoteFragment.StatEditText.Text;

                        //Very important, please never forget this line.
                        this.Recreate();
                        break;
                    case Resource.Id.deleteToolBtn:
                        DatabaseServices.DatabaseConnection.DeleteNote(DatabaseServices.NotesList[PlayNoteFragment.StatPlayId].Id);
                        DatabaseServices.NotesList.RemoveAt(PlayNoteFragment.StatPlayId);

                        //Very important, please never forget this line.
                        this.Recreate();
                        break;
                    default:
                        break;
                }
            }

            return base.OnOptionsItemSelected(item);
        }

        //Add button on click.
        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            //Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
            //    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
            var addActivity = new Intent(this, typeof(AddNoteActivity));
            StartActivity(addActivity);
        }
    }
}

