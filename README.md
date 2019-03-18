# Wow Fishing Assistant
Automates fishing in World of Warcraft.

### Options in World or warcraft.
Casting need to be tied to the = button on the cast bar.

Auto loot needs to be turned on.

### Useage
Note make sure you have room in your bags.

1. Find a place to fish.
2. Load the Wow Fishing Assistant
3. Zoom in you view on your charater so you are in first person view
4. Press the = button to cast
5. Adjust you view (camera) so the bobber appears in the monitor window
6. Press the = button a few times and make sure each cast is within the bounds of the monitor
7. When everything looks good click start.

## Advanced features
Some fishing areas have particals floating around, this can cause false positives to help mitigate this you can filter on color,
For example if all the particals are green,  then you would want to use a color channel that does not contain green.
I typicaly use red or blue channel to help filter.

Filters are applied realtime.

Motion detection settings need to be applyed.

## Disclaimer
This can be considered a bot because it reacts to events on the screen without human intervention.  
This doesn't use any Wow APIa or is in any way tied to Wow code It doens't use memory sniffing or in any way effect to running of the wow client. 

This program watches the screen, when it sees movement it clicks where it saw movement, and then presses a key. 

## Final thoughts
This was thrown together is a few hours to see if I could do somthing better than I did years ago.  
I used existing tools to accomplish this task. Some of the tools used are

* [Aforge Vision project](https://github.com/andrewkirillov/AForge.NET)
* [SharpDX project](https://github.com/sharpdx/SharpDX)
* Screen capture code taken from an answer from [Pomme De Terre](https://stackoverflow.com/users/4342169/pomme-de-terre) on question [Fast Way to take a screen shot](https://stackoverflow.com/questions/6812068/c-sharp-which-is-the-fastest-way-to-take-a-screen-shot)  
Thank you the answer, this was much faster way of getting the screen than using GDI+ functions.
