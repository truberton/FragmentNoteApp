using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace FragmentNoteApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var deleteBtn = FindViewById(Resource.Id.deleteBtn);
            deleteBtn.Click += DeleteBtn_Click;
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var db = new DatabaseServices();
            db.CreateDatabase();

            db.DeleteNote(ValueHolder.SelectedId);
        }
    }
}