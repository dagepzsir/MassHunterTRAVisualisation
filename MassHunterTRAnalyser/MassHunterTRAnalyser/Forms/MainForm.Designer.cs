namespace MassHunterTRAnalyser
{
    partial class MainForm
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
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSampleNamesFromXlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sampleTypesTab = new System.Windows.Forms.TabPage();
            this.sampleTypeControl1 = new MassHunterTRAnalyser.SampleTypeControl();
            this.rangesTab = new System.Windows.Forms.TabPage();
            this.userControl11 = new MassHunterTRAnalyser.UserControl1();
            this.openXLSDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.sampleTypesTab.SuspendLayout();
            this.rangesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.loadSampleNamesFromXlsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(971, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // loadSampleNamesFromXlsToolStripMenuItem
            // 
            this.loadSampleNamesFromXlsToolStripMenuItem.Name = "loadSampleNamesFromXlsToolStripMenuItem";
            this.loadSampleNamesFromXlsToolStripMenuItem.Size = new System.Drawing.Size(169, 20);
            this.loadSampleNamesFromXlsToolStripMenuItem.Text = "Load sample names from xls";
            this.loadSampleNamesFromXlsToolStripMenuItem.Click += new System.EventHandler(this.loadSampleNamesFromXlsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sampleTypesTab);
            this.tabControl1.Controls.Add(this.rangesTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(971, 562);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // sampleTypesTab
            // 
            this.sampleTypesTab.Controls.Add(this.sampleTypeControl1);
            this.sampleTypesTab.Location = new System.Drawing.Point(4, 22);
            this.sampleTypesTab.Name = "sampleTypesTab";
            this.sampleTypesTab.Padding = new System.Windows.Forms.Padding(3);
            this.sampleTypesTab.Size = new System.Drawing.Size(963, 536);
            this.sampleTypesTab.TabIndex = 0;
            this.sampleTypesTab.Text = "Sample Types";
            this.sampleTypesTab.UseVisualStyleBackColor = true;
            // 
            // sampleTypeControl1
            // 
            this.sampleTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleTypeControl1.Location = new System.Drawing.Point(3, 3);
            this.sampleTypeControl1.Name = "sampleTypeControl1";
            this.sampleTypeControl1.Size = new System.Drawing.Size(957, 530);
            this.sampleTypeControl1.TabIndex = 0;
            // 
            // rangesTab
            // 
            this.rangesTab.Controls.Add(this.userControl11);
            this.rangesTab.Location = new System.Drawing.Point(4, 22);
            this.rangesTab.Name = "rangesTab";
            this.rangesTab.Padding = new System.Windows.Forms.Padding(3);
            this.rangesTab.Size = new System.Drawing.Size(963, 536);
            this.rangesTab.TabIndex = 1;
            this.rangesTab.Text = "Sample Sections";
            this.rangesTab.UseVisualStyleBackColor = true;
            // 
            // userControl11
            // 
            this.userControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl11.Location = new System.Drawing.Point(3, 3);
            this.userControl11.Name = "userControl11";
            this.userControl11.Size = new System.Drawing.Size(957, 530);
            this.userControl11.TabIndex = 3;
            // 
            // openXLSDialog
            // 
            this.openXLSDialog.FileName = "openFileDialog1";
            this.openXLSDialog.Filter = "\"Microsoft Excel files|*.xlsx|CSV|*.csv";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 586);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(987, 624);
            this.Name = "MainForm";
            this.Text = "TRAnalyser for Agilent MassHunter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.sampleTypesTab.ResumeLayout(false);
            this.rangesTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private UserControl1 userControl11;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sampleTypesTab;
        private System.Windows.Forms.TabPage rangesTab;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public SampleTypeControl sampleTypeControl1;
        private System.Windows.Forms.ToolStripMenuItem loadSampleNamesFromXlsToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openXLSDialog;
    }
}

