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
    public class ValueHolder
    {
        public static int SelectedId { get; set; }

        public static List<int> IdList { get; set; }
    }
}