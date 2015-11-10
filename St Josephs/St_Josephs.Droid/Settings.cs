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
using Android.Preferences;

namespace St_Josephs.Droid
{
    [Activity(Label = "Settings")]
    public class Settings : PreferenceActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            AddPreferencesFromResource(Resource.Xml.Settings);

            Preference button = (Preference)FindPreference("agree");
            button.PreferenceClick += delegate {
                Agreement();
            };

            Preference button2 = (Preference)FindPreference("github");
            button2.PreferenceClick += delegate {
                Github();
            };

        }

        void Agreement()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle("Agreement");
            alertDialog.SetMessage("YOU KNOWINGLY AND FREELY ASSUME ALL RISK WHEN USING THE APPLICATIONS AND SERVICES. YOU, ON BEHALF OF YOURSELF, YOUR PERSONAL REPRESENTATIVES AND YOUR HEIRS, HEREBY VOLUNTARILY AGREE TO RELEASE, WAIVE, DISCHARGE, HOLD HARMLESS, DEFEND AND INDEMNIFY ST. JOSEPHS APPLICATION AND ITS DEVELOPERS FROM ANY AND ALL CLAIMS, ACTIONS OR LOSSES FOR BODILY INJURY, PROPERTY DAMAGE, WRONGFUL DEATH, EMOTIONAL DISTRESS, LOSS OF SERVICES OR OTHER DAMAGES OR HARM, WHETHER TO YOU OR TO THIRD PARTIES, WHICH MAY RESULT FROM YOUR USE OF THE SERVICES. DO NOT HOLD DEVELOPERS/SCHOOL STAFF RESPONCIABLE FOR ANY WRONG OR INCORRECT INFORMATION POSTED ON THIS APPLICATION. THIS APPLICATION IS TO BE USED 'AS IS' WITHOUT ANY WARRENTIES. BY USING THIS APPLICATION YOU AGREE TO THESE TERMS.");
            alertDialog.SetButton("UNDERSTAND", (s, ev) =>
            {
            });
            alertDialog.Show();
        }

        void Github()
        {
            var uri = Android.Net.Uri.Parse("https://github.com/brandonandre/St.-Joseph");
            var intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
        }
    }



}