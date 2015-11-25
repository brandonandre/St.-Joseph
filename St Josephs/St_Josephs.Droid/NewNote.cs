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
using System.IO;
using Android.Graphics;

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

                    //TODO create error messages if no title/text. Jeyon. (else)

                    TextView title = FindViewById<TextView>(Resource.Id.title);
                    TextView text = FindViewById<TextView>(Resource.Id.text);

                    int total = Utility.getInt(this, "totalNotes");

                    if (title.Text != "")
                    {
                        Utility.SaveString(this, "Title" + total + 1, title.Text);
                    }
                    if (text.Text != "")
                    {
                        Utility.SaveString(this, "Text" + total + 1, text.Text);
                    }

                    if (Utility.getBoolean(this, "notepad_checkbox_preference", false))
                    {
                        //Show notification

                        Notification.BigTextStyle textStyle = new Notification.BigTextStyle();

                        string longTextMessage = text.Text;
                        textStyle.BigText(longTextMessage);

                        textStyle.SetSummaryText("St. Joseph's App."); //Only take 20 characters for the summary

                        Intent secondIntent = new Intent(this, typeof(MainActivity));
                        secondIntent.PutExtra("id", ""+ total+1);

                        TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);

                        stackBuilder.AddParentStack(Java.Lang.Class.FromType(typeof(MainActivity)));
                        stackBuilder.AddNextIntent(secondIntent);

                        const int pendingIntentId = 0;
                        PendingIntent pendingIntent =
                            stackBuilder.GetPendingIntent(pendingIntentId, PendingIntentFlags.OneShot);

                        Notification.Builder builder = new Notification.Builder(this)
                        .SetContentIntent(pendingIntent)
                        .SetContentTitle(title.Text + " Note")
                        .SetContentText(text.Text)
                        .SetColor(Color.ParseColor("#FDD835"))
                        .SetSmallIcon(Resource.Drawable.ic_insert_drive_file_white_24dp);

                        builder.SetStyle(textStyle);

                        Notification notification = builder.Build();

                        NotificationManager notificationManager =
                            GetSystemService(Context.NotificationService) as NotificationManager;

                        const int notificationId = 0;
                        notificationManager.Notify(notificationId, notification);
                    }
                    
                    Utility.SaveNumber(this, "totalNotes", total+1);
                    Toast.MakeText(this, "Created '"+title.Text+"' note. (Note: "+ total+1 +")", ToastLength.Long).Show();
                    StartActivity(typeof(MainActivity));

                    return false;
            }
            return base.OnOptionsItemSelected(item);
        }

    }

}