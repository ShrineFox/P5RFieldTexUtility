namespace P5RFieldTexUtility
{
    partial class P5RFieldTexUtilityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P5RFieldTexUtilityForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseExportFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackBINsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Extract = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceExistingDupesWSameNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoreFileNameDifferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseDupesOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableOutputLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.replaceDuplicatesToolStripMenuItem,
            this.repackBINsToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseExportFolderToolStripMenuItem,
            this.chooseDupesOutputFolderToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // chooseExportFolderToolStripMenuItem
            // 
            this.chooseExportFolderToolStripMenuItem.Name = "chooseExportFolderToolStripMenuItem";
            this.chooseExportFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.chooseExportFolderToolStripMenuItem.Text = "Choose .BIN Export Folder";
            this.chooseExportFolderToolStripMenuItem.Click += new System.EventHandler(this.ExportFolder_Click);
            // 
            // replaceDuplicatesToolStripMenuItem
            // 
            this.replaceDuplicatesToolStripMenuItem.Name = "replaceDuplicatesToolStripMenuItem";
            this.replaceDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(159, 24);
            this.replaceDuplicatesToolStripMenuItem.Text = "Replace Duplicates...";
            this.replaceDuplicatesToolStripMenuItem.Click += new System.EventHandler(this.ReplaceDuplicates_Click);
            // 
            // repackBINsToolStripMenuItem
            // 
            this.repackBINsToolStripMenuItem.Name = "repackBINsToolStripMenuItem";
            this.repackBINsToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.repackBINsToolStripMenuItem.Text = "Repack .BINs";
            this.repackBINsToolStripMenuItem.Click += new System.EventHandler(this.RepackBINs_Click);
            // 
            // tlp_Main
            // 
            this.tlp_Main.AllowDrop = true;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.btn_Extract, 0, 0);
            this.tlp_Main.Controls.Add(this.rtb_Log, 1, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 28);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(598, 291);
            this.tlp_Main.TabIndex = 1;
            // 
            // btn_Extract
            // 
            this.btn_Extract.AllowDrop = true;
            this.btn_Extract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Extract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Extract.Location = new System.Drawing.Point(3, 3);
            this.btn_Extract.Name = "btn_Extract";
            this.btn_Extract.Size = new System.Drawing.Size(293, 285);
            this.btn_Extract.TabIndex = 0;
            this.btn_Extract.Text = "Drag Archives To Extract";
            this.btn_Extract.UseVisualStyleBackColor = true;
            this.btn_Extract.Click += new System.EventHandler(this.ExtractBtn_Click);
            this.btn_Extract.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExtractBtn_DragDrop);
            this.btn_Extract.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // rtb_Log
            // 
            this.rtb_Log.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Log.Location = new System.Drawing.Point(302, 3);
            this.rtb_Log.Name = "rtb_Log";
            this.rtb_Log.ReadOnly = true;
            this.rtb_Log.Size = new System.Drawing.Size(293, 285);
            this.rtb_Log.TabIndex = 1;
            this.rtb_Log.Text = "";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem,
            this.replaceExistingDupesWSameNameToolStripMenuItem,
            this.ignoreFileNameDifferencesToolStripMenuItem,
            this.enableOutputLogToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // replaceExistingDupesWSameNameToolStripMenuItem
            // 
            this.replaceExistingDupesWSameNameToolStripMenuItem.Checked = true;
            this.replaceExistingDupesWSameNameToolStripMenuItem.CheckOnClick = true;
            this.replaceExistingDupesWSameNameToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.replaceExistingDupesWSameNameToolStripMenuItem.Name = "replaceExistingDupesWSameNameToolStripMenuItem";
            this.replaceExistingDupesWSameNameToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.replaceExistingDupesWSameNameToolStripMenuItem.Text = "Replace Existing Dupes w/ Same Name";
            // 
            // ignoreBinaryDifferencesForDuplicatesToolStripMenuItem
            // 
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.Checked = true;
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.CheckOnClick = true;
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.Name = "ignoreBinaryDifferencesForDuplicatesToolStripMenuItem";
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.ignoreBinaryDifferencesForDuplicatesToolStripMenuItem.Text = "Ignore Binary Differences for Duplicates";
            // 
            // ignoreFileNameDifferencesToolStripMenuItem
            // 
            this.ignoreFileNameDifferencesToolStripMenuItem.CheckOnClick = true;
            this.ignoreFileNameDifferencesToolStripMenuItem.Name = "ignoreFileNameDifferencesToolStripMenuItem";
            this.ignoreFileNameDifferencesToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.ignoreFileNameDifferencesToolStripMenuItem.Text = "Ignore File Name Differences";
            // 
            // chooseDupesOutputFolderToolStripMenuItem
            // 
            this.chooseDupesOutputFolderToolStripMenuItem.Name = "chooseDupesOutputFolderToolStripMenuItem";
            this.chooseDupesOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.chooseDupesOutputFolderToolStripMenuItem.Text = "Choose Dupes Output Folder";
            this.chooseDupesOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.DupesFolder_Click);
            // 
            // enableOutputLogToolStripMenuItem
            // 
            this.enableOutputLogToolStripMenuItem.Checked = true;
            this.enableOutputLogToolStripMenuItem.CheckOnClick = true;
            this.enableOutputLogToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableOutputLogToolStripMenuItem.Name = "enableOutputLogToolStripMenuItem";
            this.enableOutputLogToolStripMenuItem.Size = new System.Drawing.Size(356, 26);
            this.enableOutputLogToolStripMenuItem.Text = "Enable Output Log";
            this.enableOutputLogToolStripMenuItem.CheckedChanged += new System.EventHandler(this.OutputLog_CheckedChanged);
            // 
            // P5RFieldTexUtilityForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 319);
            this.Controls.Add(this.tlp_Main);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "P5RFieldTexUtilityForm";
            this.Text = "P5RFieldTexUtility v1.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseExportFolderToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.Button btn_Extract;
        private System.Windows.Forms.ToolStripMenuItem replaceDuplicatesToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.ToolStripMenuItem repackBINsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceExistingDupesWSameNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreBinaryDifferencesForDuplicatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreFileNameDifferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chooseDupesOutputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableOutputLogToolStripMenuItem;
    }
}