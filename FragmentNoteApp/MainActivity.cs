using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

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
            var createBtn = FindViewById(Resource.Id.createBtn);
            deleteBtn.Click += DeleteBtn_Click;
            createBtn.Click += CreateBtn_Click;
        }

        private void CreateBtn_Click(object sender, EventArgs e)
        {
            var addActivity = new Intent(this, typeof(AddNoteActivity));
            StartActivity(addActivity);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var db = new DatabaseServices();
            db.CreateDatabase();

            db.DeleteNote(ValueHolder.SelectedId);
        }
    }
}