using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.refractored.fab;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace St_Josephs.Droid
{
    [Activity(Label = "Notepad", ParentActivity = typeof(MainActivity), Theme = "@style/NotepadTheme")]
    public class Notepad : Activity
    {

        public Boolean inflated = false;
        public Boolean inflated2 = false;
        DateTime _lastMouseEventTime = DateTime.UtcNow;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Notepad);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Touch += delegate {
                DateTime now = DateTime.UtcNow;
                if (now.Subtract(_lastMouseEventTime).TotalSeconds >= 0.3)
                {
                    var builder = new AlertDialog.Builder(this);
                    builder.SetTitle("New...");
                    builder.SetItems(Resource.Array.items, ListClicked);
                    builder.Create().Show();
                }
                _lastMouseEventTime = now;
            };
        }

        private void ListClicked(object sender, DialogClickEventArgs e)
        {
             //List clicked.
        }

        //Preparing the menu to inflate it.
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            if (inflated == false)
            {
                MenuInflater.Inflate(Resource.Menu.notepad, menu);
                inflated = true;
                return base.OnPrepareOptionsMenu(menu);
            }
            return false;
        }

        //When a menu item is clicked.
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.notepad:
                    StartActivity(typeof(Notepad));
                    return false;
                case Resource.Id.settings:
                    StartActivity(typeof(Settings));
                    return false;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}