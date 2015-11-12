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
using Android.Graphics;

namespace St_Josephs.Droid
{
    [Activity(Label = "Map", ParentActivity = typeof(MainActivity), Theme = "@style/MapTheme")]
    public class Map : FragmentActivity, IOnMapReadyCallback
    {

        public PolygonOptions rectOptions = new PolygonOptions();
        public Boolean inflated = false;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Map);

            var mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            mapFragment.GetMapAsync(this);
        }


        public void OnMapReady(GoogleMap googleMap)
        {

            googleMap.MapType = GoogleMap.MapTypeSatellite;

            LatLng LOCATION = new LatLng(45.036079, -74.750179);

            googleMap.MoveCamera(CameraUpdateFactory.NewLatLngZoom(LOCATION, 15));

            //Points

            //SCHOOL POLY
            rectOptions
              .Add(new LatLng(45.036704, -74.751250),
                   new LatLng(45.036968, -74.750636),
                   new LatLng(45.036985, -74.750648),
                   new LatLng(45.037001, -74.750605),
                   new LatLng(45.036988, -74.750591),
                   new LatLng(45.037051, -74.750439),
                   new LatLng(45.036745, -74.750173),
                   new LatLng(45.036681, -74.750328),
                   new LatLng(45.036653, -74.750306),
                   new LatLng(45.036644, -74.750339),
                   new LatLng(45.036665, -74.750358),
                   new LatLng(45.036601, -74.750510),
                   new LatLng(45.036468, -74.750403),
                   new LatLng(45.036503, -74.750317),
                   new LatLng(45.036437, -74.750256),
                   new LatLng(45.036501, -74.750100),
                   new LatLng(45.036192, -74.749832),
                   new LatLng(45.036264, -74.749660),
                   new LatLng(45.035688, -74.749151),
                   new LatLng(45.035423, -74.749753),
                   new LatLng(45.035370, -74.749720),
                   new LatLng(45.035257, -74.749985),
                   new LatLng(45.035542, -74.750238),
                   new LatLng(45.035466, -74.750410),
                   new LatLng(45.035655, -74.750581),
                   new LatLng(45.035733, -74.750409),
                   new LatLng(45.035887, -74.750537),
                   new LatLng(45.035868, -74.750573),
                   new LatLng(45.036169, -74.750846),
                   new LatLng(45.036188, -74.750802),
                   new LatLng(45.036704, -74.751250));


            // Get back the mutable Polygon
            Polygon polygon = googleMap.AddPolygon(rectOptions);
            

            //Portables
            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.036332, -74.749487))
                .SetTitle("Portable 1"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.036241, -74.749414))
                .SetTitle("Portable 2"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.036171, -74.749351))
                .SetTitle("Portable 3"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.035997, -74.749290))
                .SetTitle("Portable 4"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.035917, -74.749221))
                .SetTitle("Portable 5"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.035849, -74.749162))
                .SetTitle("Portable 6"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.035767, -74.749090))
                .SetTitle("Portable 7"));

            googleMap.AddMarker(new MarkerOptions()
                .SetPosition(new LatLng(45.035683, -74.749021))
                .SetTitle("Portable 8"));

            //Resturants

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.030370, -74.753572))
                .SetSnippet("Resturant - Fast Food")
                .SetTitle("Wendys"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.030815, -74.755434))
                .SetSnippet("Resturant - Fast Food")
                .SetTitle("Subway"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.030676, -74.755776))
                .SetSnippet("Resturant - Pizza")
                .SetTitle("Famous Pizza"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.030119, -74.754619))
                .SetSnippet("Resturant - Fast Food")
                .SetTitle("Burger King"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.029571, -74.754101))
                .SetSnippet("Resturant - Pizza")
                .SetTitle("Pizza Hut"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.029567, -74.752740))
                .SetSnippet("Resturant - Fast Food")
                .SetTitle("Mc. Donalds"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.028259, -74.752297))
                .SetSnippet("Coffee Shoppe")
                .SetTitle("Tim Hortons"));

            googleMap.AddMarker(new MarkerOptions()
                .SetIcon(BitmapDescriptorFactory.DefaultMarker(50))
                .SetPosition(new LatLng(45.026756, -74.750792))
                .SetSnippet("Resturant - Fast Food")
                .SetTitle("Billy K's"));
        }


        //Preparing the menu to inflate it.
        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            if (inflated == false)
            {
                MenuInflater.Inflate(Resource.Menu.map, menu);
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
                case Resource.Id.inside:
                    StartActivity(typeof(Notepad));
                    return false;
            }
            return base.OnOptionsItemSelected(item);
        }

    }
}