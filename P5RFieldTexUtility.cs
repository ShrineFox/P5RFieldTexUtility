using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AtlusFileSystemLibrary;
using AtlusFileSystemLibrary.Common.IO;
using AtlusFileSystemLibrary.FileSystems.PAK;
using ShrineFox.IO;

namespace P5RFieldTexUtility
{
    public partial class P5RFieldTexUtilityForm : Form
    {
        public static Version version = new Version(1, 3, 1);
        public static List<string> BinsToExtract = new List<string>();
        public static List<string> BinsToRepack = new List<string>();
        public Config settings = new Config();

        public P5RFieldTexUtilityForm()
        {
            InitializeComponent();
            this.Text += $" v{version.Major}.{version.Minor}.{version.Build}";
            settings = settings.LoadJson();

            if (settings.MatchPartialNames)
                chk_MatchPartialNames.Checked = true;
            chk_MatchPartialNames.Enabled = true;

            Output.Logging = true;
            Output.LogControl = rtb_Log;
        }

        /* Set Paths Using Dialogs and Save to Settings Json */

        private bool SetBinsToExtract()
        {
            var files = WinFormsDialogs.SelectFile("Choose .BINs to Extract...", true, 
                defaultDirectory: settings.LastInputExtractedBinDir);

            if (files.Count <= 0 || string.IsNullOrEmpty(files[0]))
                return false;
            BinsToExtract = files;
            settings.LastInputExtractedBinDir = Path.GetDirectoryName(files.Last());
            Output.Log("\n.BINs to extract have been set.");
            return true;
        }

        private bool SetBinsToRepack()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Directory of Folders to Repack into .BINs...",
                defaultDirectory: settings.LastTexToRepackDir);

            if (!Directory.Exists(folder))
                return false;
            BinsToExtract = Directory.GetDirectories(folder, "*.BIN", SearchOption.TopDirectoryOnly).ToList();
            settings.LastTexToRepackDir = folder;
            Output.Log($"\n.BINs to repack have been set from: \"{folder}\"");
            return true;
        }

        private bool SetExtractedBinsOutputDir()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Extracted .BIN Destination...", 
                settings.ExtractedOutputDir);

            if (!Directory.Exists(folder))
                return false;
            settings.ExtractedOutputDir = folder;
            settings.SaveJson(settings);
            Output.Log($"\nExtracted .BIN Folder has been set to: \"{folder}\"");
            return true;
        }

        private bool SetRepackedBinDir()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Repacked .BIN Destination...", 
                settings.RepackedBinDir);

            if (!Directory.Exists(folder))
                return false;
            settings.RepackedBinDir = folder;
            settings.SaveJson(settings);
            Output.Log($"\nRepacked .BIN Folder has been set to:\n{folder}");
            return true;
        }

        private bool SetCustomTexDir()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Folder with Custom Textures to Replace With...",
                settings.CustomTexDir);

            if (!Directory.Exists(folder))
                return false;
            settings.CustomTexDir = folder;
            settings.SaveJson(settings);
            Output.Log($"\nFolder with Custom Textures to Replace With has been set to:\n{folder}");
            return true;
        }

        private bool SetReplaceTexDir()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Folder to Replace Textures In...",
                settings.ReplaceTexDir);

            if (!Directory.Exists(folder))
                return false;
            settings.ReplaceTexDir = folder;
            settings.SaveJson(settings);
            Output.Log($"\nFolder With Textures to Replace has been set to:\n{folder}");
            return true;
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /* Button Click Actions */

        private void ExtractBINs_Click(object sender, EventArgs e)
        {
            // Have user select desired .BINs to extract
            if (!SetBinsToExtract())
                return; // quit if user cancels file selection

            ExtractBinTexturesToFolder();
        }

        private void RepackBINs_Click(object sender, EventArgs e)
        {
            // Have user select desired folders to repack into .BIN
            if (!SetBinsToRepack())
                return; // quit if user cancels file selection

            // Have user select desired folder to save repacked .BINs to
            if (!SetRepackedBinDir())
                return; // quit if user cancels file selection

            RepackBinTexturesFromFolders();
        }

        private void ReplaceTextures_Click(object sender, EventArgs e)
        {
            // Have user select folder with textures to replace with
            if (!SetCustomTexDir())
                return; // quit if user cancels file selection

            // Have user select folder with textures to replace
            if (!SetReplaceTexDir())
                return; // quit if user cancels file selection

            ReplaceTextures();
        }

        private void CollectUniqueTex_Click(object sender, EventArgs e)
        {
            string textureSearchDir = WinFormsDialogs.SelectFolder("Choose Folder of Textures to Narrow Down...");
            if (!Directory.Exists(textureSearchDir))
                return;

            string uniqueTexOutputDir = WinFormsDialogs.SelectFolder("Choose Folder to Save Unique Textures To...");
            if (!Directory.Exists(uniqueTexOutputDir))
                return;

            CollectUniqueTex(textureSearchDir, uniqueTexOutputDir);
        }

        private void IsolateUnmatchedTex_Click(object sender, EventArgs e)
        {
            string textureSearchDir = WinFormsDialogs.SelectFolder("Choose Folder of Custom Textures to match...");
            if (!Directory.Exists(textureSearchDir))
                return;

            string matchingTexInputDir = WinFormsDialogs.SelectFolder("Choose Folder to Remove Non-Matching Textures From...");
            if (!Directory.Exists(matchingTexInputDir))
                return;

            string matchingTexOutputDir = WinFormsDialogs.SelectFolder("Choose Folder to Move Non-Matching Textures To...");
            if (!Directory.Exists(matchingTexOutputDir))
                return;

            IsolateeUnmatchedTex(textureSearchDir, matchingTexInputDir, matchingTexOutputDir);
        }

        /* Drag/Drop Actions */
        private void ExtractBINs_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            var bins = data.Where(x => x.ToUpper().EndsWith(".BIN")).ToList();
            if (bins.Count <= 0)
                return;

            BinsToExtract = bins;
            settings.LastInputExtractedBinDir = Path.GetDirectoryName(bins.Last());
            settings.SaveJson(settings);
            Output.Log("\nBINs to extract have been chosen via drag and drop.");

            // Have user select desired .BIN extraction output folder
            if (!SetExtractedBinsOutputDir())
                return; // quit if user cancels file selection

            ExtractBinTexturesToFolder();
        }

        private void RepackBINs_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (data.Length <= 0)
                return;

            BinsToRepack = data.ToList();
            settings.LastTexToRepackDir = Path.GetDirectoryName(data.Last());
            settings.SaveJson(settings);
            Output.Log("\nFolders to repack into .BINs have been chosen via drag and drop.");


            // Have user select desired folder to save repacked .BINs to
            if (!SetRepackedBinDir())
                return; // quit if user cancels file selection

            RepackBinTexturesFromFolders();
        }


        /* File Operations */
        private void ExtractBinTexturesToFolder()
        {
            foreach (var file in BinsToExtract)
            {
                PAKFileSystem pak = new PAKFileSystem();
                if (PAKFileSystem.TryOpen(file, out pak))
                {
                    string outputFolder = settings.ExtractedOutputDir + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    Output.Log($"\nExtracting all files in \"{Path.GetFileName(file)}\" to:\n\t\"{outputFolder}\"");

                    List<string> pakFiles = new List<string>();
                    foreach (var pakFile in pak.EnumerateFiles())
                    {
                        string normalizedFilePath = pakFile.Replace("../", ""); //Remove backwards relative path
                        string outputFile = outputFolder + Path.DirectorySeparatorChar + Path.GetFileName(normalizedFilePath);

                        Directory.CreateDirectory(Path.GetDirectoryName(outputFile));

                        using (var stream = FileUtils.Create(outputFile))
                        using (var inputStream = pak.OpenFile(pakFile))
                        {
                            inputStream.CopyTo(stream);
                            pakFiles.Add(outputFile);
                        }
                    }
                    Output.Log($"\nExtracted files from: \"{Path.GetFileName(file)}\"");
                }
                else
                    Output.Log($"\nCould not open archive: \"{Path.GetFileName(file)}\"");
            }
            Output.Log($"\nDone extracting files from archives.");
            WinFormsDialogs.ShowMessageBox("Done Extracting Files", "All files have been extracted!", MessageBoxButtons.OK);
        }

        private void RepackBinTexturesFromFolders()
        {
            foreach (var folder in BinsToRepack)
            {
                PAKFileSystem pak = new PAKFileSystem();
                foreach (var file in Directory.GetFiles(folder))
                {
                    pak.AddFile(Path.GetFileName(file), file, ConflictPolicy.Replace);
                }
                string outPath = Path.Combine(settings.RepackedBinDir, Path.GetFileName(folder));
                pak.Save(outPath);
                Output.Log($"\nSaved repacked .BIN to: \"{outPath}\"");
            }
            Output.Log($"\nDone repacking textures from: \"{settings.LastTexToRepackDir}\"\n" +
                $"\tto: \"{settings.RepackedBinDir}\"");
        }

        private void ReplaceTextures()
        {
            var filesToReplace = Directory.GetFiles(settings.ReplaceTexDir, "*.dds", SearchOption.AllDirectories);
            var customTex = Directory.GetFiles(settings.CustomTexDir, "*.dds", SearchOption.AllDirectories);

            foreach (var fileToReplace in filesToReplace.Where(x => customTex.Any(y => Path.GetFileNameWithoutExtension(x).Contains(Path.GetFileNameWithoutExtension(y)))))
            {
                var fileToReplaceWith = customTex.First(x => Path.GetFileNameWithoutExtension(fileToReplace).Contains(Path.GetFileNameWithoutExtension(x)));
                if (!settings.MatchPartialNames && Path.GetFileName(fileToReplace) != Path.GetFileName(fileToReplaceWith))
                {
                    // Skipping since filenames don't match completely
                }
                else
                {
                    File.Copy(fileToReplaceWith, fileToReplace, true);
                    Output.Log($"\nCopied duplicate file to:\n\t\"{fileToReplace}\"");
                }
            }
            Output.Log($"\nDone replacing textures from: \"{settings.ReplaceTexDir}\"\n" +
                $"\tin: \"{settings.CustomTexDir}\"");
        }

        private void CollectUniqueTex(string textureSearchDir, string textureOutputDir)
        {
            List<string> files = new List<string>();
            foreach (var dds in Directory.GetFiles(textureSearchDir, "*.dds", SearchOption.AllDirectories))
            {
                string ddsFileName = Path.GetFileNameWithoutExtension(dds);
                if (!files.Any(x => Path.GetFileNameWithoutExtension(x).Contains(ddsFileName)))
                {
                    var matchingFile = files.First(x => Path.GetFileNameWithoutExtension(x).Contains(ddsFileName));
                    if (!settings.MatchPartialNames && ddsFileName != Path.GetFileNameWithoutExtension(matchingFile))
                    {
                        // Skipping since filenames don't match completely
                    }
                    else
                    {
                        files.Add(ddsFileName);
                        File.Copy(matchingFile, Path.Combine(textureOutputDir, ddsFileName), true);
                    }
                }
            }
            Output.Log($"\nDone copying unique textures\n\tfrom: \"{textureSearchDir}\"\b\tto:\n\t\"{textureOutputDir}\"");
        }

        private void IsolateeUnmatchedTex(string customTexDir, string matchingTexInputDir, string matchingTexOutputDir)
        {
            List<string> files = new List<string>();

            if (settings.MatchPartialNames)
            {
                files = Directory.GetFiles(matchingTexInputDir, "*.dds", SearchOption.AllDirectories).Where(x =>
                    !Directory.GetFiles(customTexDir, "*.dds", SearchOption.AllDirectories)
                        .Any(y => Path.GetFileNameWithoutExtension(x).Contains(Path.GetFileNameWithoutExtension(y)))).ToList();
            }
            else
            {
                files = Directory.GetFiles(matchingTexInputDir, "*.dds", SearchOption.AllDirectories).Where(x =>
                    !Directory.GetFiles(customTexDir, "*.dds", SearchOption.AllDirectories)
                        .Any(y => Path.GetFileNameWithoutExtension(x) == Path.GetFileNameWithoutExtension(y))).ToList();
            }

            foreach (var file in files)
            {
                var newDestination = file.Replace(Path.GetDirectoryName(Path.GetDirectoryName(file)), matchingTexOutputDir);
                Directory.CreateDirectory(Path.GetDirectoryName(newDestination));
                File.Move(file, newDestination);
                Output.Log($"\nMoving non-matching textures\n\tfrom: \"{file}\"\b\tto:\n\t\"{newDestination}\"");
            }
            Output.Log($"\nDone moving non-matching textures\n\tfrom: \"{matchingTexInputDir}\"\b\tto:\n\t\"{matchingTexOutputDir}\"");
        }

        private void MatchPartialNames_CheckedChanged(object sender, EventArgs e)
        {
            settings.MatchPartialNames = chk_MatchPartialNames.Checked;
            settings.SaveJson(settings);
        }
    }
}
