# P5RFieldTexUtility
![](https://i.imgur.com/rjENEU8.png)  
I made this to help batch replace duplicates of the same field texture that exists in multiple P5R ``.BIN`` files.  
You can use it to mass extract ``.dds`` textures from ``.BIN``s and narrow down unique textures for editing.  
Select your edited files and it will find all copies of that file from your extracted ``.BIN`` folder for you.  
You can either repack your ``.BIN`` files or remove unedited textures for Reloaded-II PAK emulation.  
  
## Features
- Drag/drop to extract and repack all P5R texture ``.BINs`` in a folder
- Use the Utilities dropdown to:
  - Replace all .DDS files in a folder (and its subfolders) with ones from your custom texture folder that have the same filename
    - This is useful for quickly replacing multiple textures that have the same filename across multiple extracted .BINs
  - Collect unique textures from a folder (and its subfolders) and copy them to a new folder
    - This can help you narrow down all of the unique files you can edit from a folder containing multiple extracted .BINs without worrying about duplicates
  - Isolate files that don't match the filenames of your custom textures
    - This can be useful for finding unedited textures after replacing with your custom textures, or for removing them when using Reloaded-II's PAK Emulator
  
## For Best Results
- Use DXT5 format when saving .DDS
- Keep filenames the same as the original texture or it won't output in a way that replaces the original
- Keep image dimensions to multiples of 4 or else the game will crash trying to load your textures.
