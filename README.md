# Wow Fishing Assistant
Automates fishing in World of Warcraft.

Options in World or warcraft.  
Casting need to be tied to the = button on the cast bar.
Auto loot needs to be turned on.

Note make sure you have room in your bags.

Find a place to fish.
Load the Wow Fishing Assistant
Zoom in you view on your charater so you are in first person view
Press the = button to cast
Adjust you view (camera) so the bobber appears in the monitor window
Press the = button a few times and make sure each cast is within the bounds of the monitor
When everything looks good click start.

Advanced features
Some fishing areas have particals floating around, this can cause false positives
to help mitigate this you can filter on color.
for example if all the particals are green,  then you would want to use a color channel that does not contain green
I typicaly use red or blue channel to help filter.

Filters are applied realtime.   motion detection settings need to be applyed.


Note can be considured a bot because it reacts to events on the screen.  
This doesn't not use any Wow API or is in any way tied to Wow code,  this program watches the screen, when it sees movement it click where it saw movement, and then presses a key.   Thats it.  
This was thrown together is a few hours to see if I could do somthing better than I did years ago.  I used existing tools to accomplish this task. Some of the tools used are 
Aforge Vision project https://github.com/andrewkirillov/AForge.NET
SharpDX project https://github.com/sharpdx/SharpDX
Screen capture code taken from an answer from https://stackoverflow.com/users/4342169/pomme-de-terre on question https://stackoverflow.com/questions/6812068/c-sharp-which-is-the-fastest-way-to-take-a-screen-shot  
Thank you the answer, this was much faster way of getting the screen than using GDI+ functions.
