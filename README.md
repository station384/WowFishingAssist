# Wow Fishing Assistant
Automates fishing in World of Warcraft.

### Options in World or warcraft.

Auto loot needs to be turned on.

To utilize baits you must put the bait in a button bar that uses the = key as a map (usually the last button on your main bar)

To utilize sell junk you will need a traveling tundra mount, and you will need to zoom in first person then save your camera view 1 focused on the bobber.


### Useage
Note make sure you have room in your bags.

You may have to seed slots with fish you want, otherwise junk items will eventually take up the spots.

0. Load WOW.
1. Find a place to fish.
2. Load the Wow Fishing Assistant
3. Zoom in your view on your charater so you are in first person view
4. Cast you fishing ling a few times
5. Adjust you view (camera) so the bobber appears in the monitor window
6. Cast a few times and make sure each cast is within the bounds of the monitor
7. When everything looks good click start.

## Advanced features
Some fishing areas have particles floating around, this can cause false positives, to help mitigate this, you can filter on color.
For example if all the particals are green,  then you would want to use the blue filter as the green in the particals will be removed and only shades of blue will be evaluated.

Assistant can apply the Scarlett Herring lure to help improve catch

Filters are applied realtime.

Motion detection settings need to be applyed.

## Disclaimer
This can be considered a bot because it reacts to events on the screen without human intervention.  
This doesn't use any Wow APIs or is in any way tied to Wow code It does not use memory sniffing or in any way effect the running of the wow client. 

This program watches the screen, when it sees movement it clicks where it saw movement, and then presses a key. 

## Final thoughts
This was thrown together is a few hours to see if I could do something better than I did years ago.  
I used existing tools to accomplish this task. Some of the tools used are

* [Aforge Vision project](https://github.com/andrewkirillov/AForge.NET)
* [SharpDX project](https://github.com/sharpdx/SharpDX)
* Screen capture code taken from an answer from [Pomme De Terre](https://stackoverflow.com/users/4342169/pomme-de-terre) on question [Fast Way to take a screen shot](https://stackoverflow.com/questions/6812068/c-sharp-which-is-the-fastest-way-to-take-a-screen-shot)  
Thank you for that answer, this was much faster and less cpu intensive way of getting the screen than using GDI+ functions.
