using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace St_Josephs.Droid
{
    [Service(Exported = true)]
    public class MainService : Service
    {

        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug("St. Josephs Logger", "Main Service has started.");
            MainLooper();
            return StartCommandResult.Sticky;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Debug("St. Josephs Logger", "OnCreate service.");
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }

        public void MainLooper()
        {
            Thread tVar = new Thread(() =>
            {

                while (true)
                {
                    Log.Debug("St. Josephs Logger", "Loop Started.");
                    Thread.Sleep(1000);

                    //JSON Parser. 
                    string url = "https://raw.githubusercontent.com/brandonandre/St.-Joseph/testing3/notifications";

                    var c = new System.Net.WebClient();
                    var json = @"" + c.DownloadString(url);

                    JsonTextReader reader = new JsonTextReader(new StringReader(json));
                    while (reader.Read())
                        {
                            if (reader.Value != null)
                                    Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                            else
                            Console.WriteLine("Token: {0}", reader.TokenType);
                        }
                }
            });

            tVar.Start();
        }

        public class OBJECT
        {
            public bool[] notification { get; set; }
        }


        private async Task<string> fetchJSONData(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));
            request.ContentType = "application/json";
            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (WebResponse response = await request.GetResponseAsync())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    string jsonDoc = await Task.Run(() => "" + (stream));
                    Console.Out.WriteLine("Response: {0}", jsonDoc.ToString());

                    // Return the JSON document:
                    return jsonDoc;
                }
            }
        }

    }
}