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
using XamSvg;

namespace St_Josephs.Droid
{
    [Activity(Label = "Inside")]
    public class Inside : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Inside);

            var bmp = SvgFactory.GetBitmap(Resources, Resource.Raw.floor1, 100, 100);
            ImageView img = FindViewById<ImageView>(Resource.Id.map);
            img.SetImageBitmap(bmp);
        }
    }
}