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
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Support.V4.App;

namespace St_Josephs.Droid
{
    [Activity(Label = "Map")]
    public class Map : FragmentActivity, IOnMapReadyCallback
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Map);

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }


        public void OnMapReady(GoogleMap googleMap)
        {

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(0, 0))
                .SetTitle("Marker"));
        }

    }
}