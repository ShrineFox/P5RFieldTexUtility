# P5RFieldTexUtility
![](https://i.imgur.com/mJyVYJd.png)  
I made this to help batch replace duplicates of the same field texture that exists in multiple .BINS.  
You can use it to mass extract .BINs to search for textures to edit.  
Then you can select your edited file. It will find all copies of that file from your extracted .BIN folder for you.  
The output is already structured for Reloaded II PAK emulation, but you can optionally repack your edited textures back into .BINs.
## Features
- Choose an Export folder from ``File > Choose Export Folder`` or else it will default to ``.\Export``.
- Drag P5R Texture .BIN files onto the button and the contents should be extracted to your chosen Export Folder.
- Click ``Replace Duplicates...`` to choose a destination for duplicate files (this might be ``MODEL/FIELD_TEX/TEXTURES`` in your PAK emulator folder)
- When prompted, select the file(s) you want to replace (edited ``.DDS`` images). They should be output to your chosen destination folder in folders named after the .BINs duplicates are found in.
- Optionally, click ``Repack .BINs`` if you want to use ``.BIN`` files instead of the PAK Emulator for any reason.

## Options
- Ignore Binary Differences for Duplicates
- Replace Existing Dupes w/ Same Name
- Ignore File Name Differences (off by default, will replace everything if Ignore Binary Differences isn't on)
- Enable Output Log  
  
Disabling the output log should make the program extract/replace things a little faster since it's not also writing to the textbox every single time.  
Using the other new settings should enable you to replace existing duplicates in your selected output folder, as well as replace files even if their names/binaries don't match. This may improve productivity in some situations.
## For Best Results
- Use DXT5 format when saving .DDS
- Keep filenames the same as the original texture or it won't output in a way that replaces the original
- Keep image dimensions to multiples of 4 or else the game will crash trying to load your textures.