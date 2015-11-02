# Calendar Events
This is where calendar events are stored and brought to the application.

# How to create events introduction
Making lists allows you to update students about certain dates they should remember. Such as:

* Assignements that are due.
* Meetups for your groups.
* Special dates such as Prom or dances.
* Outside school events.
* College Meetups
* University Meetups

Students are able to subscribe to lists that are in this directory. 

This is a great tool to keep students up to date with events and make them remember or remind them about these events.
Here are instructions on how to make a list.

## Make or use existing category.

Please check if the event you want to add already has an category that makes sense. School dances should put in the "Dances" listing. And so on.

### Using a current category

1. Above this readme is all the directorys for listings. Every single one is listed. Click on the one you want to add or remove or tweak an event.
2. When you click it, click the "edit" button at the top, you will be brought to an editor.
3. In the editor you might already see lines of write up that explain each importiant date. Here is how the layout goes:

Layout:
day:month:year:period:name:description

Example:
5:5:2015:1:"Christmas Dance":"Wear green and red or anything chistmas related."

It's an event. On 5th day of May in 2015. It's on period 1. The name of the event is "Chirstmas Dance" and the description is "Wear green and red or anything chistmas related.".

Take a look at the documentation below for help on making events.

### Creating a new category.

1. Open up the file on the main directory called: "lists.txt" open it up and edit it.
2. At the bottom of the text file create a new line write the exact name of the list. (Example: Dances)
3. Click on the + button to create a new file.

![alt tag](http://i.imgur.com/WuKPvME.png?1)

4. At the very top it will say: "St.-Joseph/ {enter name here}, enter the name of the list as you put in the other text file. IT NEEDS TO BE EXACTLY THE SAME.
5. Go to Using a current category instructions which are above.

# Event Documentation
How to get the most out of your events.

Template:

day:month:year:period:name:description

## Day
First Attribute, it can only be a number. If it's anything else the event will be regejected from the system.
It can only be a number from 1-32

## Month
Second Attribute, it can only be a number. If it's anything else the event will be regejected from the system.
Please do not put "May" or spell it out, use the number as the following:

1. January
2. Febuary
3. March
4. April
5. May
6. June
7. July
8. August
9. September
10. October
11. November
12. Decemeber

## Year
Third Attribute, it can only be a number. If it's anything else the event will be regejected from the system.
It will only accept a number from:
15-99

Example: 2016 would be 16. 2032 would be 32.

## Period
Fourth Attribute, it can only be a number. If it's anything else the event will be regejected from the system.
Each number represents something:

1. Period 1
2. Period 2
3. Period 3
4. Period 4
5. Lunch
6. Before School
7. After School
8. Other

You can specify when it is in the description.

## Name
Fifth Attribute, You can type anything here.

This is the name of the event which will pop up at the top of the notification. You can use anything but the : symbol
since it tells the system you are going to the next attribute.

Good:
Halloween Dance

Bad:
Halloween: Dance

## Description
Sixth Attribute, You can type anything here.

This is the description of the event which will pop up at the top of the notification. You can use anything but the : symbol
since it tells the system you are going to the next attribute.

Good:
Wear orange, black please.

Bad:
Wear: Orange, black please.


