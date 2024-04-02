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
        public static List<string> InputFiles = new List<string>();
        public static string ExportFolder = "./Export";
        public static string EditedDupesFolder = "./EditedDuplicates";

        public P5RFieldTexUtilityForm()
        {
            InitializeComponent();
            rtb_Log.Text += $"Export folder set to \"{ExportFolder}\" by default.";
        }

        private void InputFiles_Click(object sender, EventArgs e)
        {
            SetInputFiles();
        }

        private void SetInputFiles()
        {
            var files = WinFormsDialogs.SelectFile("Choose Archives to Extract...", true);
            if (files.Count <= 0)
                return;
            InputFiles = files;
            rtb_Log.Text += "\nInput files have been chosen via file selection.";
        }

        private void ExportFolder_Click(object sender, EventArgs e)
        {
            SetExportFolder();
        }

        private void SetExportFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Export Folder...");
            if (!Directory.Exists(folder))
                return;
            ExportFolder = folder;
            rtb_Log.Text += $"\nExport Folder has been set to:\n{folder}";
        }

        private void ExtractBtn_Click(object sender, EventArgs e)
        {
            SetInputFiles();
            ExtractToExportFolder();
            WinFormsDialogs.ShowMessageBox("Done Extracting Files","All files have been extracted!", MessageBoxButtons.OK);
        }

        private void ExtractToExportFolder()
        {
            foreach (var file in InputFiles)
            {
                PAKFileSystem pak = new PAKFileSystem();
                if (PAKFileSystem.TryOpen(file, out pak))
                {
                    string outputFolder = ExportFolder + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    rtb_Log.Text += $"\nExtracting all files in \"{Path.GetFileName(file)}\" to:\n\t\"{outputFolder}\"";

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
                            //rtb_Log.Text += $"\n\t\tExtracted \"{Path.GetFileName(outputFile)}\"";
                        }
                    }
                }
                else
                    rtb_Log.Text += $"\nCould not open archive: \"{Path.GetFileName(file)}\"";

                rtb_Log.Text += $"\nDone extracting files from archives.";
            }
        }

        private void ExtractBtn_DragDrop(object sender, DragEventArgs e)
        {
            var data = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            InputFiles = data.ToList();
            rtb_Log.Text += "\nInput files have been chosen via drag and drop.";
            ExtractToExportFolder();
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void SetEditedDupesFolder()
        {
            var folder = WinFormsDialogs.SelectFolder("Choose Output Folder for Edited Duplicates...");
            if (!Directory.Exists(folder))
                return;
            EditedDupesFolder = folder;
            rtb_Log.Text += $"\nEdited Duplicates Folder has been set to:\n{folder}";
        }

        private void ReplaceDuplicates_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ExportFolder))
                SetExportFolder();
            if (!Directory.Exists(ExportFolder))
                return;

            if (!Directory.Exists(EditedDupesFolder))
                SetEditedDupesFolder();
            if (!Directory.Exists(EditedDupesFolder))
                return;

            var editedFiles = WinFormsDialogs.SelectFile("Choose Edited Extracted File(s)...", true);
            if (editedFiles.Count <= 0)
                return;
            rtb_Log.Text += "\nEdited Extracted Files have been chosen.";

            var uneditedExportFiles = Directory.GetFiles(ExportFolder, "*", SearchOption.AllDirectories);

            foreach (var editedFile in editedFiles)
            {
                // Find original file from exported folder that matches edited file's name...
                if (uneditedExportFiles.Any(x => Path.GetFileName(x).Equals(Path.GetFileName(editedFile))))
                {
                    // Get file info for original file with matching name
                    var originalFile = uneditedExportFiles.First(x => Path.GetFileName(x).Equals(Path.GetFileName(editedFile)));
                    FileInfo originalFileInfo = new FileInfo(originalFile);
                    
                    // For each file in unedited file export folder...
                    foreach (var exportedFile in uneditedExportFiles)
                    {
                        // If file has the same size as the original matching name file...
                        FileInfo exportedFileInfo = new FileInfo(exportedFile);
                        if (originalFileInfo.Length == exportedFileInfo.Length)
                        {
                            // If files are 100% identical bytewise...
                            if (FileSys.AreFilesIdentical(exportedFile, originalFile))
                            {
                                // Create new output path for edited file using name/foldername of identical unedited file
                                string newPath = Path.Combine(EditedDupesFolder, Path.GetFileName(Path.GetDirectoryName(exportedFile)), Path.GetFileName(exportedFile));
                                Directory.CreateDirectory(Path.GetDirectoryName(newPath));
                                File.Copy(editedFile, newPath, true);
                                rtb_Log.Text += $"\nCopied duplicate file to:\n\t\"{newPath}\"";
                                // Create Dummy .BIN

                            }
                        }
                    }
                }                
            }
            rtb_Log.Text += $"\nDone copying edits to duplicate files folder.";
        }

        private void RepackBINs_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(ExportFolder))
                SetExportFolder();
            if (!Directory.Exists(ExportFolder))
                return;

            if (!Directory.Exists(EditedDupesFolder))
                SetEditedDupesFolder();
            if (!Directory.Exists(EditedDupesFolder))
                return;

            var repackedFolder = WinFormsDialogs.SelectFolder("Choose Repacked .BIN Destination Folder...");
            if (!Directory.Exists(repackedFolder))
                return;
            rtb_Log.Text += $"\nRepacked .BIN Destination Folder has been chosen:\n\t{repackedFolder}";

            foreach(var dir in Directory.GetDirectories(EditedDupesFolder).Where(x => x.EndsWith(".BIN")))
            {
                InjectNewTexIntoPAC(dir, repackedFolder);
            }
            rtb_Log.Text += $"\nDone repacking .BIN files.";
        }

        private void InjectNewTexIntoPAC(string editedDupeDir, string repackedFolder)
        {
            string originalDir = Directory.GetDirectories(ExportFolder, "*", SearchOption.AllDirectories)
                .First(x => Path.GetFileName(x).Equals(Path.GetFileName(editedDupeDir)));

            PAKFileSystem pak = new PAKFileSystem();
            foreach (var file in Directory.GetFiles(originalDir))
                pak.AddFile(Path.GetFileName(file), file, ConflictPolicy.Replace);
            foreach (var file in Directory.GetFiles(editedDupeDir))
                pak.AddFile(Path.GetFileName(file), file, ConflictPolicy.Replace);

            string binOutPath = Path.Combine(repackedFolder, Path.GetFileName(editedDupeDir));
            pak.Save(binOutPath);
            rtb_Log.Text += $"\nRepacked .BIN to:\n\t\"{binOutPath}\"";
        }
    }
}
