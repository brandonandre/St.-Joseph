# St. Joseph Secondary School App.
This is where we will be storing our application, feel free to look at our code to check out what our app does and how we did it.

# Open Source Project
This project is completely open source to expire other students to create apps. We want this to be used as a resourse to help you out or just to see our programming techniques. Check out the contribute section near the bottom of the read me if you would like to learn more about contributing to the project! Enjoy.

# Android Downloads
You can download the latest apk here:

https://drive.google.com/folderview?id=0B0k8hqQOhiUNb090QURlMEdmNzQ&usp=sharing

# Visit our website
http://brandonandre.github.io/St.-Joseph/

# Main Features
This app will allow you to do the following:

  * Get notifications about school events.
  * See how many house points the school has.
  * View the school calendar.
  * See our schools tweets and various information.
  * School Bus Cancellations.
  * School map built in.
  * Notepad.

# Creating A Notification

Requirements
  * You need special permission to create a notification. You may request notifcations to me on facebook but I need some verification on the event.
  * If you are editing the notification.json file please make sure you understand how to do it.
  
## Notification Documentation
### "Notifications":[]
This is where the app checks if it needs to display notifications. It has room for 3 values meaning you can show up to 3 notifications at once. This can only have two diffrent inputs being:

* true
* false

! Please use no caps for this. It will not register if you have a capital letter. Thank you.

### "notificationTitle":[]
This is where the app gets the notification title for the notification. Notice how it has 3 ""'s that corraspond which what you put above. Make sure you turn the selected notification on from the other step by putting it 'true'.

![alt tag](http://i.imgur.com/N57sUtn.png)

The title is the top part of the notification, We recommend making the titles very short since it can only show a limited amount of space. Examples:

```
"Dress down day tomorrow"

"Can food drive"

"No School tomorrow"
```

You can type anything in the "" except " since it will break it. Do:

```
"Do 'this'!"
```

DON'T:

```
"Don't do "This""
```
You can use ', not " again. You need to have a set of "", once only.

### "notificationMessage":[]
![alt tag](http://i.imgur.com/N57sUtn.png) 

This is the bottom text of the notification. The user can expand these notifcations to show more text. When making the message it's a good idea to remember this:

* You can put as much information in here as you want. This does not mean you need to write a book.
* I recommend using no more than 4 sentences.
* Try to get the most importaint information in the first sentence. Since if the notification is unexpanded it will only show the first part.
* Like if the event cost money or requires something then that should be in the first sentence.

Please follow the text rules shown in the "NotificationTitle" section above.

### "notificationType":[]
(Not required but a nice touch to get the point across.)

The type changes the icon shown in the status bar of peoples phones:

![alt tag](http://i.imgur.com/6Ce2OlT.png) 

As well of the color used when you open the notification shade.

![alt tag](http://i.imgur.com/N57sUtn.png) 

Here are a table of what value to use:

| Value | Description | Icon | Color |
| ------------- | ------------- | ------------- | ------------- |
| "Event"  | A school event is happening. | ![alt tag](http://i.imgur.com/3YQlC8F.png) | ![alt tag](http://i.imgur.com/9Mu4QvR.png) |
| "Dress"  | Dress down day. | ![alt tag](http://i.imgur.com/9O30ekq.png) | ![alt tag](http://i.imgur.com/CRTLu4g.png) |
| "NoSchool"  | No School Today. | ![alt tag](http://i.imgur.com/q7V5bd3.png) | ![alt tag](http://i.imgur.com/SrxxRjQ.png) |
| "Sport"  | Sporting Event. | ![alt tag](http://i.imgur.com/EphHe4f.png) | ![alt tag](http://i.imgur.com/zqxYLEV.png) |
| "Snow"  | Freezing Rain/Snow | ![alt tag](http://i.imgur.com/3ZUKiOL.png) | ![alt tag](http://i.imgur.com/DY4AgCo.png) |
| "Bus"  | Bus Delays/Cancelations | ![alt tag](http://i.imgur.com/rWHFG3Y.png) | ![alt tag](http://i.imgur.com/dedzBtv.png) |
| "Default" or ""  | Default. | ![alt tag](http://i.imgur.com/JXysZ2N.png) | ![alt tag](http://i.imgur.com/mrA1ihx.png) |


# Developers

  * Brandon Andre (Main Programmer)
  * Kyle Johnson (Programmer)
  * Jeyon Jeyanandan (Programmer)

# Contribute

We welcome anybody to create pull requests or just have some suggestions to the application. We will look over the changes and test them out to the beta channel.

Thank you!

# License

   Copyright 2015 Brandon Andre

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
