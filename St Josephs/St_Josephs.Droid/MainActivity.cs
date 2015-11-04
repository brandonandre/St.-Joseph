using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace St_Josephs.Droid
{
	[Activity (Label = "St. Josephs", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/AppTheme")]
    public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
		}

        //Preparing the menu to inflate it.
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.main_menu, menu);
            return base.OnPrepareOptionsMenu(menu);
        }

        //When a menu item is clicked.
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.notepad:
                    //do something
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

    }



}


