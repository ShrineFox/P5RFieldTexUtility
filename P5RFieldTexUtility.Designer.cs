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
            this.chooseDupesOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceDuplicatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repackBINsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_IgnoreBinaryDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_OverwriteSameName = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_IgnoreNameDiff = new System.Windows.Forms.ToolStripMenuItem();
            this.chk_EnableOutputLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Extract = new System.Windows.Forms.Button();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
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
            // chooseDupesOutputFolderToolStripMenuItem
            // 
            this.chooseDupesOutputFolderToolStripMenuItem.Name = "chooseDupesOutputFolderToolStripMenuItem";
            this.chooseDupesOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(283, 26);
            this.chooseDupesOutputFolderToolStripMenuItem.Text = "Choose Dupes Output Folder";
            this.chooseDupesOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.DupesFolder_Click);
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
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chk_IgnoreBinaryDiff,
            this.chk_OverwriteSameName,
            this.chk_IgnoreNameDiff,
            this.chk_EnableOutputLog});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // chk_IgnoreBinaryDiff
            // 
            this.chk_IgnoreBinaryDiff.Checked = true;
            this.chk_IgnoreBinaryDiff.CheckOnClick = true;
            this.chk_IgnoreBinaryDiff.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_IgnoreBinaryDiff.Enabled = false;
            this.chk_IgnoreBinaryDiff.Name = "chk_IgnoreBinaryDiff";
            this.chk_IgnoreBinaryDiff.Size = new System.Drawing.Size(356, 26);
            this.chk_IgnoreBinaryDiff.Text = "Ignore Binary Differences for Duplicates";
            this.chk_IgnoreBinaryDiff.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chk_OverwriteSameName
            // 
            this.chk_OverwriteSameName.Checked = true;
            this.chk_OverwriteSameName.CheckOnClick = true;
            this.chk_OverwriteSameName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_OverwriteSameName.Enabled = false;
            this.chk_OverwriteSameName.Name = "chk_OverwriteSameName";
            this.chk_OverwriteSameName.Size = new System.Drawing.Size(356, 26);
            this.chk_OverwriteSameName.Text = "Replace Existing Dupes w/ Same Name";
            this.chk_OverwriteSameName.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chk_IgnoreNameDiff
            // 
            this.chk_IgnoreNameDiff.CheckOnClick = true;
            this.chk_IgnoreNameDiff.Enabled = false;
            this.chk_IgnoreNameDiff.Name = "chk_IgnoreNameDiff";
            this.chk_IgnoreNameDiff.Size = new System.Drawing.Size(356, 26);
            this.chk_IgnoreNameDiff.Text = "Ignore File Name Differences";
            this.chk_IgnoreNameDiff.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // chk_EnableOutputLog
            // 
            this.chk_EnableOutputLog.Checked = true;
            this.chk_EnableOutputLog.CheckOnClick = true;
            this.chk_EnableOutputLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_EnableOutputLog.Enabled = false;
            this.chk_EnableOutputLog.Name = "chk_EnableOutputLog";
            this.chk_EnableOutputLog.Size = new System.Drawing.Size(356, 26);
            this.chk_EnableOutputLog.Text = "Enable Output Log";
            this.chk_EnableOutputLog.CheckedChanged += new System.EventHandler(this.CheckedChanged);
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
        private System.Windows.Forms.ToolStripMenuItem chk_OverwriteSameName;
        private System.Windows.Forms.ToolStripMenuItem chk_IgnoreBinaryDiff;
        private System.Windows.Forms.ToolStripMenuItem chk_IgnoreNameDiff;
        private System.Windows.Forms.ToolStripMenuItem chooseDupesOutputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chk_EnableOutputLog;
    }
}