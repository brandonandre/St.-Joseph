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

        public bool notification1 = false;
        public bool notification2 = false;
        public bool notification3 = false;

        public string notificationTitle1 = "";
        public string notificationTitle2 = "";
        public string notificationTitle3 = "";

        public string notificationMessage1 = "";
        public string notificationMessage2 = "";
        public string notificationMessage3 = "";

        public string notificationType1 = "";
        public string notificationType2 = "";
        public string notificationType3 = "";

        public string json = "";

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
                    json = @"" + c.DownloadString(url);

                    JsonTextReader reader = new JsonTextReader(new StringReader(json));
                    int cuga = 0;

                    //Data
                    notification1 = false;
                    notification2 = false;
                    notification3 = false;

                    notificationTitle1 = "";
                    notificationTitle2 = "";
                    notificationTitle3 = "";

                    notificationMessage1 = "";
                    notificationMessage2 = "";
                    notificationMessage3 = "";

                    notificationType1 = "";
                    notificationType2 = "";
                    notificationType3 = "";

                    while (reader.Read())
                    {

                        if (reader.Value != null)
                        {
                            //Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
                        }
                        else
                        {
                            //Console.WriteLine("Token: {0}", reader.TokenType);
                        }

                        //Console.WriteLine(cuga);

                        Newtonsoft.Json.JsonToken ty = reader.TokenType;
                        string va = reader.Value + "";

                        switch (cuga)
                        {
                            case 0: break; //StartObject (Starting the array.)

                            case 1: break; //PropertyName (Boolean: Notifications)
                            case 2: break; //Open Array.
                            case 3: if (reader.Value.ToString().ToLower().Trim() == "true") { notification1 = true; } else { notification1 = false; } break; //Notification 1.
                            case 4: if (reader.Value.ToString().ToLower().Trim() == "true") { notification2 = true; } else { notification2 = false; } break; //Notification 2.
                            case 5: if (reader.Value.ToString().ToLower().Trim() == "true") { notification3 = true; } else { notification3 = false; } break; //Notification 3.
                            case 6: break; //Close Array.

                            case 7: break; //PropertyName (String: NotificationTitle)
                            case 8: break; //Open Array.
                            case 9: notificationTitle1 = (string)reader.Value; break; //Title 1.
                            case 10: notificationTitle2 = (string)reader.Value; break; //Title 2.
                            case 11: notificationTitle3 = (string)reader.Value; break; //Title 3.
                            case 12: break; //Close Array.

                            case 13: break; //PropertyName (String: NotificationMessage)
                            case 14: break; //Open Array.
                            case 15: notificationMessage1 = (string)reader.Value; break; //Message 1.
                            case 16: notificationMessage2 = (string)reader.Value; break; //Message 2.
                            case 17: notificationMessage3 = (string)reader.Value; break; //Message 3.
                            case 18: break; //Close Array.

                            case 19: break; //PropertyName (String: NotificationType)
                            case 20: break; //Open Array.
                            case 21: notificationType1 = (string)reader.Value; break; //Type 1.
                            case 22: notificationType2 = (string)reader.Value; break; //Type 2.
                            case 23: notificationType3 = (string)reader.Value; break; //Type 3.
                            case 24: break; //Close Array.

                            case 25: break; //End of array.

                            default: break;

                        }

                        cuga = cuga + 1;
                            
                    }

                    cuga = 0;

                    if (notification1)
                    {
                        Console.WriteLine("Build Notification #1");
                        //Notification 1 is opened.
                        // Instantiate the builder and set notification elements:
                        Notification.Builder builder = new Notification.Builder(this)
                            .SetContentTitle(notificationTitle1)
                            .SetContentText(notificationMessage1)
                            .SetSmallIcon(Resource.Drawable.ic_insert_drive_file_white_24dp);

                        // Build the notification:
                        Notification notification = builder.Build();

                        // Get the notification manager:
                        NotificationManager notificationManager =
                            GetSystemService(Context.NotificationService) as NotificationManager;

                        // Publish the notification:
                        const int notificationId = 1; 
                        notificationManager.Notify(notificationId, notification);
                    }

                    if (notification2)
                    {
                        //Notification 1 is opened.
                        // Instantiate the builder and set notification elements:
                        Notification.Builder builder = new Notification.Builder(this)
                            .SetContentTitle(notificationTitle2)
                            .SetContentText(notificationMessage2);
                        //.SetSmallIcon(Resource.Drawable.ic_notification);

                        // Build the notification:
                        Notification notification = builder.Build();

                        // Get the notification manager:
                        NotificationManager notificationManager =
                            GetSystemService(Context.NotificationService) as NotificationManager;

                        // Publish the notification:
                        const int notificationId = 2;
                        notificationManager.Notify(notificationId, notification);
                    }

                    if (notification3)
                    {
                        //Notification 1 is opened.
                        // Instantiate the builder and set notification elements:
                        Notification.Builder builder = new Notification.Builder(this)
                            .SetContentTitle(notificationTitle3)
                            .SetContentText(notificationMessage3);
                        //.SetSmallIcon(Resource.Drawable.ic_notification);

                        // Build the notification:
                        Notification notification = builder.Build();

                        // Get the notification manager:
                        NotificationManager notificationManager =
                            GetSystemService(Context.NotificationService) as NotificationManager;

                        // Publish the notification:
                        const int notificationId = 3;
                        notificationManager.Notify(notificationId, notification);
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