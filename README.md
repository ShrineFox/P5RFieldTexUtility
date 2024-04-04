# P5RFieldTexUtility
![](https://i.imgur.com/mJyVYJd.png)
## Features
- Choose an Export folder from ``File > Choose Export Folder`` or else it will default to ``.\Export``.
- Drag P5R Texture .BIN files onto the button and the contents should be extracted to your chosen Export Folder.
- Click ``Replace Duplicates...`` to choose a destination for duplicate files (this might be ``MODEL/FIELD_TEX/TEXTURES`` in your PAK emulator folder)
- When prompted, select the file(s) you want to replace (edited ``.DDS`` images). They should be output to your chosen destination folder in folders named after the .BINs duplicates are found in.
- Optionally, click ``Repack .BINs`` if you want to use ``.BIN`` files instead of the PAK Emulator for any reason.

## For Best Results
- Use DXT5 format when saving .DDS
- Keep filenames the same as the original texture or it won't output in a way that replaces the original
- Keep image dimensions to multiples of 4 or else the game will crash trying to load your textures.