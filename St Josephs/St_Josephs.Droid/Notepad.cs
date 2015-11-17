using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.refractored.fab;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Media;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Net;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.IO;

namespace St_Josephs.Droid
{
    [Activity(Label = "Notepad", ParentActivity = typeof(MainActivity), Theme = "@style/NotepadTheme")]
    public class Notepad : Activity
    {

        public Boolean inflated = false;
        public Boolean inflated2 = false;
        DateTime _lastMouseEventTime = DateTime.UtcNow;
        private Android.Net.Uri _currentImageUri;

        Bitmap bitmap1;
        Bitmap bitmap2;
        Bitmap bitmap3;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Window.RequestFeature(WindowFeatures.ActionBar);

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

            //Load papers.
            ImageButton button1 = FindViewById<ImageButton>(Resource.Id.paper1);
            ImageButton button2 = FindViewById<ImageButton>(Resource.Id.paper2);
            ImageButton button3 = FindViewById<ImageButton>(Resource.Id.paper3);

            string[] filePaths = Directory.GetFiles(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "*.jpeg");
            if(filePaths.Count() == 3)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(bitmap1);
                bitmap2 = BitmapFactory.DecodeFile(filePaths[1]);
                button2.SetImageBitmap(bitmap2);
                bitmap3 = BitmapFactory.DecodeFile(filePaths[2]);
                button3.SetImageBitmap(bitmap3);
            } else if(filePaths.Count() == 2)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(bitmap1);
                bitmap2 = BitmapFactory.DecodeFile(filePaths[1]);
                button2.SetImageBitmap(bitmap2);
            } else if (filePaths.Count() == 1)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(bitmap1);
            } else
            {
                //No images in the array. Perhaps put something here.
            }

            button1.Touch += delegate {
                DateTime now = DateTime.UtcNow;
                if (now.Subtract(_lastMouseEventTime).TotalSeconds >= 0.3)
                {
                    if (bitmap1 != null)
                    {
                    FrameLayout frame = FindViewById<FrameLayout>(Resource.Id.imageShow);

                    ActionBar.Hide();

                    fab.Visibility = (ViewStates.Gone);
                    frame.Visibility = (ViewStates.Visible);

                    ImageView image = FindViewById<ImageView>(Resource.Id.mainView);
                    image.SetImageBitmap(bitmap1);
                    }
                }
                _lastMouseEventTime = now;
            };
        }

        private void ListClicked(object sender, DialogClickEventArgs e)
        {
            switch ((int)e.Which)
            {
                case 0:

                    var takePictureIntent = new Intent(MediaStore.ActionImageCapture);
                    StartActivityForResult(takePictureIntent, 1001);

                    break;
                case 1:
                    StartActivity(typeof(NewNote));
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        //PREPARE IMAGE.
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1001 && resultCode == Result.Ok)
            {
                var bitmap = (Bitmap)data.Extras.Get("data");
                ImageButton button1 = FindViewById<ImageButton>(Resource.Id.paper1);
                ImageButton button2 = FindViewById<ImageButton>(Resource.Id.paper2);
                ImageButton button3 = FindViewById<ImageButton>(Resource.Id.paper3);

                Bitmap bmp2 = ((BitmapDrawable)button2.Drawable).Bitmap;
                button3.SetImageBitmap(bmp2);

                Bitmap bmp1 = ((BitmapDrawable)button1.Drawable).Bitmap;
                button2.SetImageBitmap(bmp1);

                button1.SetImageBitmap(bitmap);

                //Now lets actually save the image to the device.
                var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
                string[] filePaths = Directory.GetFiles(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, "*.jpeg");
                var filePath = System.IO.Path.Combine(sdCardPath, filePaths.Count() + ".jpeg");
                var stream = new FileStream(filePath, FileMode.Create);
                bitmap.Compress(Bitmap.CompressFormat.Jpeg, 100, stream);
                stream.Close();


                //TODO: Do something useful with the thumbnail
            } else
            {
                var builder = new AlertDialog.Builder(this);
                builder.SetTitle("Opps!");
                builder.SetMessage("We couldn't get the image! Did you cancel?");
                builder.SetCancelable(true);
                builder.Create().Show(); 
            }
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