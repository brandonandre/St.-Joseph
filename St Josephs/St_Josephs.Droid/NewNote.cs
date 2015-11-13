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

namespace St_Josephs.Droid
{
    [Activity(Label = "New Note", ParentActivity = typeof(Notepad), Theme = "@style/NotepadTheme")]
    public class NewNote : Activity
    {

        public Boolean inflated = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Note);
            // Create your application here
        }

        //Preparing the menu to inflate it.
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            if (inflated == false)
            {
                MenuInflater.Inflate(Resource.Menu.note, menu);
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
                case Resource.Id.save:
                    //StartActivity(typeof(Notepad));
                    return false;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}