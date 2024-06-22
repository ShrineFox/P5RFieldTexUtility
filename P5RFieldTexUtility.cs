using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public static Version version = new Version(1, 2, 1);
        public static List<string> InputFiles = new List<string>();
        public Config settings = new Config();

        public P5RFieldTexUtilityForm()
        {
            InitializeComponent();
            this.Text += $" v{version.Major}.{version.Minor}.{version.Build}";
            settings = settings.LoadJson();
            ApplySettingsToFormOptions();

            Output.Logging = true;
            Output.LogControl = rtb_Log;
            Output.Log($"Export folder set to \"{settings.BinExportPath}\" by default.");
        }

        private void ApplySettingsToFormOptions()
        {
            // Reflect values from config file in checkbox checked states
            chk_IgnoreBinaryDiff.Checked = settings.IgnoreBinaryDiff;
            chk_OverwriteSameName.Checked = settings.OverwriteSameName;
            chk_IgnoreNameDiff.Checked = settings.IgnoreNameDiff;
            chk_EnableOutputLog.Checked = settings.EnableOutputLog;

            // Values can be changed from the CheckedChanged event once they're enabled here
            chk_IgnoreBinaryDiff.Enabled = true;
            chk_OverwriteSameName.Enabled = true;
            chk_IgnoreNameDiff.Enabled = true;
            chk_EnableOutputLog.Enabled = true;
        }

        private void SetInputFiles()
        {
            var files = WinFormsDialogs.SelectFile("Choose Archives to Extract...", true);
            if (files.Count <= 0)
                return;
            InputFiles = files;
            Output.Log("\nInput files have been chosen via file selection.");
        }

        private void SetExportFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Export Folder...");
            if (!Directory.Exists(folder))
                return;
            settings.BinExportPath = folder;
            settings.SaveJson(settings);
            Output.Log($"\nExport Folder has been set to:\n{folder}");
        }

        private void SetDuplicatesFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Output Folder for Edited Duplicates...");
            if (!Directory.Exists(folder))
                return;
            settings.DuplicateExportPath = folder;
            settings.SaveJson(settings);
            Output.Log($"\nEdited Duplicates Folder has been set to:\n{folder}");
        }

        private void ChooseInputFolder_Click(object sender, EventArgs e)
        {
            SetInputFolder();
        }

        private void SetInputFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Input Folder...");
            if (!Directory.Exists(folder))
                return;
            settings.InputEditedTexPath = folder;
            settings.SaveJson(settings);
            Output.Log($"\nInput Folder has been set to:\n{folder}");
        }

        private void ExportFolder_Click(object sender, EventArgs e)
        {
            SetExportFolder();
        }

        private void DupesFolder_Click(object sender, EventArgs e)
        {
            SetDuplicatesFolder();
        }

        private void ChooseOriginalBinFolder_Click(object sender, EventArgs e)
        {
            SetOriginalBinFolder();
        }

        private void SetOriginalBinFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose OG .BIN Folder...");
            if (!Directory.Exists(folder))
                return;
            settings.OriginalBINDirPath = folder;
            settings.SaveJson(settings);
            Output.Log($"\nOG .BIN Folder has been set to:\n{folder}");
        }

        private void ExtractBtn_Click(object sender, EventArgs e)
        {
            SetInputFiles();
            ExtractToExportFolder();
            WinFormsDialogs.ShowMessageBox("Done Extracting Files","All files have been extracted!", MessageBoxButtons.OK);
        }

        private void ExtractBtn_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            InputFiles = data.ToList();
            Output.Log("\nInput files have been chosen via drag and drop.");
            ExtractToExportFolder();
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void ExtractToExportFolder()
        {
            foreach (var file in InputFiles)
            {
                PAKFileSystem pak = new PAKFileSystem();
                if (PAKFileSystem.TryOpen(file, out pak))
                {
                    string outputFolder = settings.BinExportPath + Path.DirectorySeparatorChar + Path.GetFileName(file);
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
                }
                else
                    Output.Log($"\nCould not open archive: \"{Path.GetFileName(file)}\"");

                Output.Log($"\nDone extracting files from archives.");
            }
        }

        private void ReplaceDuplicates_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settings.BinExportPath))
                SetExportFolder();
            if (!Directory.Exists(settings.BinExportPath))
                return;

            if (!Directory.Exists(settings.DuplicateExportPath))
                SetDuplicatesFolder();
            if (!Directory.Exists(settings.DuplicateExportPath))
                return;

            var editedFiles = WinFormsDialogs.SelectFile("Choose Edited Extracted File(s)...", true);
            if (editedFiles.Count <= 0)
                return;
            Output.Log("\nEdited Extracted Files have been chosen.");

            var uneditedExportFiles = Directory.GetFiles(settings.BinExportPath, "*", SearchOption.AllDirectories);

            foreach (var editedFile in editedFiles)
            {
                // Find original file from exported folder that matches edited file's name...
                if (uneditedExportFiles.Any(x => Path.GetFileName(x).ToLower().Equals(Path.GetFileName(editedFile).ToLower())))
                {
                    // Get file info for original file with matching name
                    var originalFile = uneditedExportFiles.First(x => Path.GetFileName(x).ToLower().Equals(Path.GetFileName(editedFile).ToLower()));
                    FileInfo originalFileInfo = new FileInfo(originalFile);
                    
                    // For each file in unedited file export folder...
                    foreach (var exportedFile in uneditedExportFiles)
                    {
                        FileInfo exportedFileInfo = new FileInfo(exportedFile);

                        // If file has the same name as the original file...
                        // (unless ignore different names option is enabled)
                        if (settings.IgnoreNameDiff || 
                            Path.GetFileName(originalFile).ToLower() == Path.GetFileName(exportedFile).ToLower())
                        {
                            // If file has the same size as the original matching name file...
                            // (unless ignore binary differences option is enabled)
                            if (settings.IgnoreBinaryDiff ||
                                originalFileInfo.Length == exportedFileInfo.Length)
                            {
                                // If files are 100% identical bytewise...
                                // (unless ignore binary differences option is enabled)
                                if (settings.IgnoreBinaryDiff ||
                                    FileSys.AreFilesIdentical(exportedFile, originalFile))
                                {
                                    // Create new output path for edited file using name/foldername of identical unedited file
                                    string newPath = Path.Combine(settings.DuplicateExportPath, Path.GetFileName(Path.GetDirectoryName(exportedFile)), Path.GetFileName(exportedFile));
                                    Directory.CreateDirectory(Path.GetDirectoryName(newPath));
                                    if (settings.OverwriteSameName || !File.Exists(newPath))
                                    {
                                        File.Copy(editedFile, newPath, settings.OverwriteSameName);
                                        Output.Log($"\nCopied duplicate file to:\n\t\"{newPath}\"");
                                    }
                                    else
                                    {
                                        Output.Log($"\nSKIPPED replacing file since it already exists:\n\t\"{newPath}\"");
                                    }
                                }
                            }
                        }
                    }
                }                
            }
            Output.Log($"\nDone copying edits to duplicate files folder.");
        }

        private void RepackBINs_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settings.DuplicateExportPath))
                SetDuplicatesFolder();
            if (!Directory.Exists(settings.DuplicateExportPath))
                return;

            if (!Directory.Exists(settings.OriginalBINDirPath))
                SetOriginalBinFolder();
            if (!Directory.Exists(settings.OriginalBINDirPath))
                return;

            var repackedFolder = WinFormsDialogs.SelectFolder("Choose Repacked .BIN Destination Folder...");
            if (!Directory.Exists(repackedFolder))
                return;
            Output.Log($"\nRepacked .BIN Destination Folder has been chosen:\n\t{repackedFolder}");

            foreach (var dir in Directory.GetDirectories(settings.DuplicateExportPath).Where(x => x.EndsWith(".BIN")))
            {
                InjectNewTexIntoPAC(dir, repackedFolder);
            }
            Output.Log($"\nDone repacking .BIN files.");
        }

        private void InjectNewTexIntoPAC(string editedDupeDir, string repackedFolder)
        {
            if (!Directory.GetFiles(settings.OriginalBINDirPath, "*", SearchOption.TopDirectoryOnly)
                .Any(x => Path.GetFileName(x).Equals(Path.GetFileName(editedDupeDir))))
            {
                MessageBox.Show($"OG .BIN not found, skipping repack: {Path.GetFileName(editedDupeDir)}");
                return;
            }

            string originalBin = Directory.GetFiles(settings.OriginalBINDirPath, "*", SearchOption.TopDirectoryOnly)
                .First(x => Path.GetFileName(x).Equals(Path.GetFileName(editedDupeDir)));

            PAKFileSystem pak = new PAKFileSystem();
            pak.Load(originalBin);
            foreach (var file in Directory.GetFiles(editedDupeDir))
                pak.AddFile(Path.GetFileName(file), file, ConflictPolicy.Replace);

            string binOutPath = Path.Combine(repackedFolder, Path.GetFileName(editedDupeDir));
            pak.Save(binOutPath);
            Output.Log($"\nRepacked .BIN to:\n\t\"{binOutPath}\"");
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            var chk = (ToolStripMenuItem)sender;
            if (chk.Enabled)
            {
                settings.IgnoreBinaryDiff = chk_IgnoreBinaryDiff.Checked;
                settings.OverwriteSameName = chk_OverwriteSameName.Checked;
                settings.IgnoreNameDiff = chk_IgnoreNameDiff.Checked;
                settings.EnableOutputLog = chk_EnableOutputLog.Checked;
                Output.Logging = chk_EnableOutputLog.Checked;
                settings.SaveJson(settings);
            }
        }

        private void CollectUniqueTex_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(settings.DuplicateExportPath))
                SetDuplicatesFolder();
            if (!Directory.Exists(settings.DuplicateExportPath))
                return;

            if (!Directory.Exists(settings.InputEditedTexPath))
                SetInputFiles();
            if (!Directory.Exists(settings.InputEditedTexPath))
                return;

            List<string> files = new List<string>();
            foreach (var dds in Directory.GetFiles(settings.DuplicateExportPath, "*.dds", SearchOption.AllDirectories))
            {
                string ddsFileName = Path.GetFileName(dds);
                if (!files.Any(x => Path.GetFileName(x) == ddsFileName))
                {
                    files.Add(ddsFileName);
                    File.Copy(dds, Path.Combine(settings.InputEditedTexPath, ddsFileName), true);
                }
            }
            Output.Log($"\nDone copying unique textures\n\tfrom: \"{settings.DuplicateExportPath}\"\b\tto:\n\t\"{settings.InputEditedTexPath}\"");
        }
    }
}
