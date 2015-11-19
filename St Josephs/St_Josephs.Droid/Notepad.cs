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
using Android.Content.PM;
using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace St_Josephs.Droid
{

    public static class App
    {
        public static File _file;
        public static File _dir;
        public static Bitmap bitmap;
    }

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

            // Create directory if missing.
            CreateDirectoryForPictures();

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

            string[] filePaths = System.IO.Directory.GetFiles(Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures).AbsolutePath + File.Separator + "StJoseph");
            if(filePaths.Count() == 3)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap1, 200, 230, true));
                bitmap2 = BitmapFactory.DecodeFile(filePaths[1]);
                button2.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap2, 200, 230, true));
                bitmap3 = BitmapFactory.DecodeFile(filePaths[2]);
                button3.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap3, 200, 230, true));
            } else if(filePaths.Count() == 2)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap1, 200, 230, true));
                bitmap2 = BitmapFactory.DecodeFile(filePaths[1]);
                button2.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap2, 200, 230, true));
            } else if (filePaths.Count() == 1)
            {
                bitmap1 = BitmapFactory.DecodeFile(filePaths[0]);
                button1.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap1, 200, 230, true));
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
                    image.SetImageBitmap(Bitmap.CreateScaledBitmap(bitmap1, 1000, 1330, true));
                    }
                }
                _lastMouseEventTime = now;
            };
        }

        private void CreateDirectoryForPictures()
        {
            App._dir = new File(
                Environment.GetExternalStoragePublicDirectory(
                    Environment.DirectoryPictures), "StJoseph");
            if (!App._dir.Exists())
            {
                App._dir.Mkdirs();
            }
        }

        private void ListClicked(object sender, DialogClickEventArgs e)
        {
            switch ((int)e.Which)
            {
                case 0:

                    var takePictureIntent = new Intent(MediaStore.ActionImageCapture);
                    App._file = new File(App._dir, String.Format("stJosephs_{0}.jpg", Guid.NewGuid()));
                    takePictureIntent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file));
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

                Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                Uri contentUri = Uri.FromFile(App._file);
                mediaScanIntent.SetData(contentUri);
                SendBroadcast(mediaScanIntent);

                ImageButton button1 = FindViewById<ImageButton>(Resource.Id.paper1);
                ImageButton button2 = FindViewById<ImageButton>(Resource.Id.paper2);
                ImageButton button3 = FindViewById<ImageButton>(Resource.Id.paper3);

                Matrix matrix = new Matrix();
                matrix.SetRotate(getNeededRotation(contentUri.Path));

                BitmapFactory.Options options = new BitmapFactory.Options();

                int w = 300;
                int h = 330;

                Bitmap bit = Bitmap.CreateBitmap(BitmapFactory.DecodeFile(App._file.Path, options), 0, 0, w, h, matrix, false);
                if (App.bitmap != null)
                {

                    Bitmap bmp2 = ((BitmapDrawable)button2.Drawable).Bitmap;
                    button3.SetImageBitmap(bmp2);

                    Bitmap bmp1 = ((BitmapDrawable)button1.Drawable).Bitmap;
                    button2.SetImageBitmap(bmp1);

                    button1.SetImageBitmap(App.bitmap);
                }

                GC.Collect();


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

        //Rotatation needed.
        private int getNeededRotation(string filepath)
        {
            ExifInterface exif = new ExifInterface(filepath);
            int orientation = exif.GetAttributeInt(ExifInterface.TagOrientation, -1);
            int rotate = 0;
            switch (orientation)
            {
                case 6:
                    {
                        rotate = 90;
                        break;
                    }
                case 3:
                    {
                        rotate = 180;
                        break;
                    }
                case 8:
                    {
                        rotate = 270;
                        break;
                    }
                default:
                    {
                        rotate = 0;
                        break;
                    }


            }
            exif.Dispose();
            return rotate;
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