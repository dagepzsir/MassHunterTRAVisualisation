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
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acqDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSampleNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.sampleTypesTab = new System.Windows.Forms.TabPage();
            this.sampleTypeControl1 = new MassHunterTRAnalyser.SampleTypeControl();
            this.rangesTab = new System.Windows.Forms.TabPage();
            this.selectionControl = new MassHunterTRAnalyser.SelectionControl();
            this.calibrationTab = new System.Windows.Forms.TabPage();
            this.calibrationControl1 = new MassHunterTRAnalyser.Controls.CalibrationControl();
            this.averagesTab = new System.Windows.Forms.TabPage();
            this.averagesControl = new MassHunterTRAnalyser.Controls.AveragesControl();
            this.openXLSDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.sampleTypesTab.SuspendLayout();
            this.rangesTab.SuspendLayout();
            this.calibrationTab.SuspendLayout();
            this.averagesTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1015, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.importToolStripMenuItem,
            this.loadSampleNamesToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openBtn_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchToolStripMenuItem,
            this.acqDataToolStripMenuItem});
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // batchToolStripMenuItem
            // 
            this.batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            this.batchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.batchToolStripMenuItem.Text = "Batch";
            this.batchToolStripMenuItem.Click += new System.EventHandler(this.batchToolStripMenuItem_Click);
            // 
            // acqDataToolStripMenuItem
            // 
            this.acqDataToolStripMenuItem.Name = "acqDataToolStripMenuItem";
            this.acqDataToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.acqDataToolStripMenuItem.Text = "Acq Data";
            // 
            // loadSampleNamesToolStripMenuItem
            // 
            this.loadSampleNamesToolStripMenuItem.Name = "loadSampleNamesToolStripMenuItem";
            this.loadSampleNamesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.loadSampleNamesToolStripMenuItem.Text = "Load Sample Names";
            this.loadSampleNamesToolStripMenuItem.Click += new System.EventHandler(this.loadSampleNamesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.sampleTypesTab);
            this.tabControl1.Controls.Add(this.rangesTab);
            this.tabControl1.Controls.Add(this.calibrationTab);
            this.tabControl1.Controls.Add(this.averagesTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 562);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // sampleTypesTab
            // 
            this.sampleTypesTab.Controls.Add(this.sampleTypeControl1);
            this.sampleTypesTab.Location = new System.Drawing.Point(4, 22);
            this.sampleTypesTab.Name = "sampleTypesTab";
            this.sampleTypesTab.Padding = new System.Windows.Forms.Padding(3);
            this.sampleTypesTab.Size = new System.Drawing.Size(1007, 536);
            this.sampleTypesTab.TabIndex = 0;
            this.sampleTypesTab.Text = "Sample Types";
            this.sampleTypesTab.UseVisualStyleBackColor = true;
            // 
            // sampleTypeControl1
            // 
            this.sampleTypeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sampleTypeControl1.Location = new System.Drawing.Point(3, 3);
            this.sampleTypeControl1.Name = "sampleTypeControl1";
            this.sampleTypeControl1.Size = new System.Drawing.Size(1001, 530);
            this.sampleTypeControl1.TabIndex = 0;
            // 
            // rangesTab
            // 
            this.rangesTab.Controls.Add(this.selectionControl);
            this.rangesTab.Location = new System.Drawing.Point(4, 22);
            this.rangesTab.Name = "rangesTab";
            this.rangesTab.Padding = new System.Windows.Forms.Padding(3);
            this.rangesTab.Size = new System.Drawing.Size(1007, 536);
            this.rangesTab.TabIndex = 1;
            this.rangesTab.Text = "Sample Sections";
            this.rangesTab.UseVisualStyleBackColor = true;
            // 
            // selectionControl
            // 
            this.selectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectionControl.Location = new System.Drawing.Point(3, 3);
            this.selectionControl.Name = "selectionControl";
            this.selectionControl.Size = new System.Drawing.Size(1001, 530);
            this.selectionControl.TabIndex = 3;
            // 
            // calibrationTab
            // 
            this.calibrationTab.Controls.Add(this.calibrationControl1);
            this.calibrationTab.Location = new System.Drawing.Point(4, 22);
            this.calibrationTab.Name = "calibrationTab";
            this.calibrationTab.Padding = new System.Windows.Forms.Padding(3);
            this.calibrationTab.Size = new System.Drawing.Size(1007, 536);
            this.calibrationTab.TabIndex = 3;
            this.calibrationTab.Text = "Calibraion lines";
            this.calibrationTab.UseVisualStyleBackColor = true;
            // 
            // calibrationControl1
            // 
            this.calibrationControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationControl1.Location = new System.Drawing.Point(3, 3);
            this.calibrationControl1.Name = "calibrationControl1";
            this.calibrationControl1.Size = new System.Drawing.Size(1001, 530);
            this.calibrationControl1.TabIndex = 0;
            // 
            // averagesTab
            // 
            this.averagesTab.Controls.Add(this.averagesControl);
            this.averagesTab.Location = new System.Drawing.Point(4, 22);
            this.averagesTab.Name = "averagesTab";
            this.averagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.averagesTab.Size = new System.Drawing.Size(1007, 536);
            this.averagesTab.TabIndex = 2;
            this.averagesTab.Text = "Averages/Statistics";
            this.averagesTab.UseVisualStyleBackColor = true;
            // 
            // averagesControl
            // 
            this.averagesControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.averagesControl.Location = new System.Drawing.Point(3, 3);
            this.averagesControl.Name = "averagesControl";
            this.averagesControl.Size = new System.Drawing.Size(1001, 530);
            this.averagesControl.TabIndex = 0;
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
            this.ClientSize = new System.Drawing.Size(1015, 586);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(987, 624);
            this.Name = "MainForm";
            this.Text = "TRAnalyser for Agilent MassHunter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.sampleTypesTab.ResumeLayout(false);
            this.rangesTab.ResumeLayout(false);
            this.calibrationTab.ResumeLayout(false);
            this.averagesTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private SelectionControl selectionControl;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage sampleTypesTab;
        private System.Windows.Forms.TabPage rangesTab;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        public SampleTypeControl sampleTypeControl1;
        private System.Windows.Forms.OpenFileDialog openXLSDialog;
        private System.Windows.Forms.TabPage averagesTab;
        private Controls.AveragesControl averagesControl;
        private System.Windows.Forms.TabPage calibrationTab;
        private Controls.CalibrationControl calibrationControl1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acqDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSampleNamesToolStripMenuItem;
    }
}

