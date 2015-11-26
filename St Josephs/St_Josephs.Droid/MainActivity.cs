using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using St_Josephs.Droid;
using System.Collections.Generic;

namespace St_Josephs.Droid
{
	[Activity (Label = "St. Josephs", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
	{

        public Boolean inflated = false;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
            inflateNotepad();
		}

        List<string> items = new List<string>();
        public void inflateNotepad()
        {
            ListView noteview = FindViewById<ListView>(Resource.Id.noteview);
            int total = Utility.getInt(this, "totalNotes");
            if(total == 0)
            {
                // Nothing here //
                // Get rid of this card, not needed.

                //items[0] = "nothing.";
                items.Add("Nothing is here...");
            } else
            {
                for (int i = 0; i <= total; i++)
                {
                    var prefs = Application.Context.GetSharedPreferences(PackageName, FileCreationMode.Private);
                    string newTitle = prefs.GetString("Title"+i, "Not found");
                    items.Add(newTitle);
                }
            }
            noteview.Adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }

        //Preparing the menu to inflate it.
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            if (inflated == false)
            {
                MenuInflater.Inflate(Resource.Menu.main_menu, menu);
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
                    StartActivity(typeof(NewNote));
                    return false;
                case Resource.Id.settings:
                    StartActivity(typeof(Settings));
                    return false;
                case Resource.Id.map:
                    StartActivity(typeof(Map));
                    return false;
            }
            return base.OnOptionsItemSelected(item);
        }

    }



}


