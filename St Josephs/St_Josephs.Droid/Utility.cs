namespace St_Josephs.Droid
{
    using System.IO;

    using Android.Graphics;
    using Android.App;
    using Android.Content;

    public static class Utility
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // in order to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }


        public static void SaveString(this Context Context, string key, string value)
        {
            var prefs = Application.Context.GetSharedPreferences(Context.PackageName, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutString(key, value);
            prefEditor.Commit();
        }

        public static void SaveNumber(this Context Context, string key, int value)
        {
            var prefs = Application.Context.GetSharedPreferences(Context.PackageName, FileCreationMode.Private);
            var prefEditor = prefs.Edit();
            prefEditor.PutInt(key, value);
            prefEditor.Commit();
        }

        public static int getInt(this Context Context, string key)
        {
            var prefs = Application.Context.GetSharedPreferences(Context.PackageName, FileCreationMode.Private);
            return prefs.GetInt(key, 0);
        }

        public static string getString(this Context Context, string key)
        {
            var prefs = Application.Context.GetSharedPreferences(Context.PackageName, FileCreationMode.Private);
            return prefs.GetString(key, "No Title Added.");
        }

        public static bool getBoolean(Context Context, string key, bool defaultValue)
        {
            var prefs = Application.Context.GetSharedPreferences(Context.PackageName, FileCreationMode.Private);
            return true; //prefs.GetBoolean(key, defaultValue);
        }

        public static void Populate<T>(this T[] arr, T value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = value;
            }
        }
    }

}