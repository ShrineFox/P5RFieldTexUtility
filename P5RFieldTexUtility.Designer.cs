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
            this.utilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceDuplicateTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collectUniqueTexturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isolateTexturesWithoutMatchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_Log = new System.Windows.Forms.RichTextBox();
            this.tlp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.tlp_ArchiveButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Repack = new System.Windows.Forms.Button();
            this.btn_Extract = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tlp_Main.SuspendLayout();
            this.tlp_ArchiveButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(598, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utilitiesToolStripMenuItem
            // 
            this.utilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.replaceDuplicateTexturesToolStripMenuItem,
            this.collectUniqueTexturesToolStripMenuItem,
            this.isolateTexturesWithoutMatchesToolStripMenuItem});
            this.utilitiesToolStripMenuItem.Name = "utilitiesToolStripMenuItem";
            this.utilitiesToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.utilitiesToolStripMenuItem.Text = "Utilities";
            // 
            // replaceDuplicateTexturesToolStripMenuItem
            // 
            this.replaceDuplicateTexturesToolStripMenuItem.Name = "replaceDuplicateTexturesToolStripMenuItem";
            this.replaceDuplicateTexturesToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.replaceDuplicateTexturesToolStripMenuItem.Text = "Replace With Custom Textures";
            this.replaceDuplicateTexturesToolStripMenuItem.Click += new System.EventHandler(this.ReplaceTextures_Click);
            // 
            // collectUniqueTexturesToolStripMenuItem
            // 
            this.collectUniqueTexturesToolStripMenuItem.Name = "collectUniqueTexturesToolStripMenuItem";
            this.collectUniqueTexturesToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.collectUniqueTexturesToolStripMenuItem.Text = "Collect Unique Textures";
            this.collectUniqueTexturesToolStripMenuItem.Click += new System.EventHandler(this.CollectUniqueTex_Click);
            // 
            // isolateTexturesWithoutMatchesToolStripMenuItem
            // 
            this.isolateTexturesWithoutMatchesToolStripMenuItem.Name = "isolateTexturesWithoutMatchesToolStripMenuItem";
            this.isolateTexturesWithoutMatchesToolStripMenuItem.Size = new System.Drawing.Size(310, 26);
            this.isolateTexturesWithoutMatchesToolStripMenuItem.Text = "Isolate Textures Without Matches";
            this.isolateTexturesWithoutMatchesToolStripMenuItem.Click += new System.EventHandler(this.IsolateUnmatchedTex_Click);
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
            // tlp_Main
            // 
            this.tlp_Main.AllowDrop = true;
            this.tlp_Main.ColumnCount = 2;
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Controls.Add(this.rtb_Log, 1, 0);
            this.tlp_Main.Controls.Add(this.tlp_ArchiveButtons, 0, 0);
            this.tlp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Main.Location = new System.Drawing.Point(0, 28);
            this.tlp_Main.Name = "tlp_Main";
            this.tlp_Main.RowCount = 1;
            this.tlp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_Main.Size = new System.Drawing.Size(598, 291);
            this.tlp_Main.TabIndex = 1;
            // 
            // tlp_ArchiveButtons
            // 
            this.tlp_ArchiveButtons.ColumnCount = 1;
            this.tlp_ArchiveButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ArchiveButtons.Controls.Add(this.btn_Repack, 0, 1);
            this.tlp_ArchiveButtons.Controls.Add(this.btn_Extract, 0, 0);
            this.tlp_ArchiveButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_ArchiveButtons.Location = new System.Drawing.Point(3, 3);
            this.tlp_ArchiveButtons.Name = "tlp_ArchiveButtons";
            this.tlp_ArchiveButtons.RowCount = 2;
            this.tlp_ArchiveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ArchiveButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ArchiveButtons.Size = new System.Drawing.Size(293, 285);
            this.tlp_ArchiveButtons.TabIndex = 2;
            // 
            // btn_Repack
            // 
            this.btn_Repack.AllowDrop = true;
            this.btn_Repack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Repack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Repack.Location = new System.Drawing.Point(3, 145);
            this.btn_Repack.Name = "btn_Repack";
            this.btn_Repack.Size = new System.Drawing.Size(287, 137);
            this.btn_Repack.TabIndex = 2;
            this.btn_Repack.Text = "Drag Archives To Repack";
            this.btn_Repack.UseVisualStyleBackColor = true;
            this.btn_Repack.Click += new System.EventHandler(this.RepackBINs_Click);
            this.btn_Repack.DragDrop += new System.Windows.Forms.DragEventHandler(this.RepackBINs_DragDrop);
            this.btn_Repack.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            // 
            // btn_Extract
            // 
            this.btn_Extract.AllowDrop = true;
            this.btn_Extract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Extract.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btn_Extract.Location = new System.Drawing.Point(3, 3);
            this.btn_Extract.Name = "btn_Extract";
            this.btn_Extract.Size = new System.Drawing.Size(287, 136);
            this.btn_Extract.TabIndex = 1;
            this.btn_Extract.Text = "Drag Archives To Extract";
            this.btn_Extract.UseVisualStyleBackColor = true;
            this.btn_Extract.Click += new System.EventHandler(this.ExtractBINs_Click);
            this.btn_Extract.DragDrop += new System.Windows.Forms.DragEventHandler(this.ExtractBINs_DragDrop);
            this.btn_Extract.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
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
            this.Text = "P5RFieldTexUtility";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tlp_Main.ResumeLayout(false);
            this.tlp_ArchiveButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox rtb_Log;
        private System.Windows.Forms.TableLayoutPanel tlp_Main;
        private System.Windows.Forms.TableLayoutPanel tlp_ArchiveButtons;
        private System.Windows.Forms.Button btn_Repack;
        private System.Windows.Forms.Button btn_Extract;
        private System.Windows.Forms.ToolStripMenuItem utilitiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceDuplicateTexturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem collectUniqueTexturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isolateTexturesWithoutMatchesToolStripMenuItem;
    }
}