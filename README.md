# CodeTestWinForm
Working on making an app that creates a powerpoint slide based on text in the title box, text in 
the description area, and selected images in the image search area.

# 10/14/2020
Started doing research and decided to go with a windows forms app. 

After working on it for the day I successfully have the title box and text area text box adding to a new ppt slide.
Now I just need to find out what API to use to scrape for the images and put them onto the ppt slide.

# 10/15/2020
Researched a lot of the day and ended up using the programmable search engine from Google.

After a couple hours of implementation and fiddling around with it, I successfully have search
results from words used in the title box show up in picture boxes. I'm working on being able to
select images and then feed them into the ppt slide.

I can't run anymore tests today though because I reached my limit of usage on the API. So I'm 
messing around with code to find out how to feed those images to the ppt slide and then see if the 
code works when I get to use the API again.

# 10/16/2020
Picked up where I left off yesterday. Did a lot of research on finding the best way to feed the images into the
ppt slide. I decided to use checkboxes to dynamically change the text into the url and then feed that url to be loaded
on the ppt slide. I also went through and did some commenting to show what was going on in the code for visual clarity.
Proud to show what I got done, it is a bit clunky but I got it done. 
