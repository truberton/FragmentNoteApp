﻿using System;
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
    public class TitlesFragment : ListFragment
    {
        public int selectedPlayId;
        bool showingTwoFragments;

        public TitlesFragment()
        {
            // Being explicit about the requirement for a default constructor.
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ListAdapter = new ArrayAdapter<String>(Activity, Android.Resource.Layout.SimpleListItemActivated1, DatabaseServices.NotesList.Select(x => x.Title).ToArray());

            if (savedInstanceState != null)
            {
                selectedPlayId = savedInstanceState.GetInt("current_play_id", 0);
            }

            var quoteContainer = Activity.FindViewById(Resource.Id.note_container);
            showingTwoFragments = quoteContainer != null &&
                                  quoteContainer.Visibility == ViewStates.Visible;
            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayQuote(selectedPlayId);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_play_id", selectedPlayId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayQuote(position);
        }

        void ShowPlayQuote(int playId)
        {
            selectedPlayId = playId;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectedPlayId, true);

                PlayNoteFragment playQuoteFragment = FragmentManager.FindFragmentById(Resource.Id.note_container) as PlayNoteFragment;

                if (playQuoteFragment == null || playQuoteFragment.PlayId != playId)
                {
                    var container = Activity.FindViewById(Resource.Id.note_container);
                    var quoteFrag = PlayNoteFragment.NewInstance(selectedPlayId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.note_container, quoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayNoteActivity));
                intent.PutExtra("current_play_id", playId);
                StartActivity(intent);

            }
        }
    }
}