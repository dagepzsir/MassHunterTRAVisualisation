namespace WindowsFormsApplication1
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
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.traChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPanel = new System.Windows.Forms.Panel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.selectedChartInfoTable = new System.Windows.Forms.DataGridView();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openButton = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsButton = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshButton = new System.Windows.Forms.ToolStripMenuItem();
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.tableSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView1 = new System.Windows.Forms.ListView();
            this.sampleDataFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sampleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.traChart)).BeginInit();
            this.chartPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedChartInfoTable)).BeginInit();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.Panel2.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableSplitContainer1)).BeginInit();
            this.tableSplitContainer1.Panel1.SuspendLayout();
            this.tableSplitContainer1.Panel2.SuspendLayout();
            this.tableSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // traChart
            // 
            this.traChart.AllowDrop = true;
            this.traChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            legend1.Name = "Legend1";
            this.traChart.Legends.Add(legend1);
            this.traChart.Location = new System.Drawing.Point(3, 3);
            this.traChart.Name = "traChart";
            this.traChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.traChart.Size = new System.Drawing.Size(400, 420);
            this.traChart.TabIndex = 0;
            this.traChart.Text = "chart1";
            this.traChart.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            this.traChart.AxisViewChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ViewEventArgs>(this.traChart_AxisViewChanged);
            this.traChart.DragDrop += new System.Windows.Forms.DragEventHandler(this.chart1_DragDrop);
            this.traChart.DragEnter += new System.Windows.Forms.DragEventHandler(this.chart1_DragEnter);
            this.traChart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.traChart_KeyPress);
            this.traChart.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseDoubleClick);
            // 
            // chartPanel
            // 
            this.chartPanel.AllowDrop = true;
            this.chartPanel.AutoScroll = true;
            this.chartPanel.Controls.Add(this.traChart);
            this.chartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartPanel.Location = new System.Drawing.Point(0, 0);
            this.chartPanel.Name = "chartPanel";
            this.chartPanel.Size = new System.Drawing.Size(1041, 426);
            this.chartPanel.TabIndex = 3;
            // 
            // selectedChartInfoTable
            // 
            this.selectedChartInfoTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedChartInfoTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectedChartInfoTable.Location = new System.Drawing.Point(0, 0);
            this.selectedChartInfoTable.Name = "selectedChartInfoTable";
            this.selectedChartInfoTable.Size = new System.Drawing.Size(888, 191);
            this.selectedChartInfoTable.TabIndex = 5;
            this.selectedChartInfoTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.traChart_KeyPress);
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsButton,
            this.refreshButton});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(1041, 24);
            this.mainMenuStrip.TabIndex = 6;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openButton
            // 
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(103, 22);
            this.openButton.Text = "Open";
            this.openButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // optionsButton
            // 
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(61, 20);
            this.optionsButton.Text = "Options";
            this.optionsButton.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Enabled = false;
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(58, 20);
            this.refreshButton.Text = "Refresh";
            this.refreshButton.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.mainSplitContainer.Name = "mainSplitContainer";
            this.mainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.chartPanel);
            // 
            // mainSplitContainer.Panel2
            // 
            this.mainSplitContainer.Panel2.Controls.Add(this.tableSplitContainer1);
            this.mainSplitContainer.Size = new System.Drawing.Size(1041, 621);
            this.mainSplitContainer.SplitterDistance = 426;
            this.mainSplitContainer.TabIndex = 7;
            // 
            // tableSplitContainer1
            // 
            this.tableSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.tableSplitContainer1.Name = "tableSplitContainer1";
            // 
            // tableSplitContainer1.Panel1
            // 
            this.tableSplitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // tableSplitContainer1.Panel2
            // 
            this.tableSplitContainer1.Panel2.Controls.Add(this.selectedChartInfoTable);
            this.tableSplitContainer1.Size = new System.Drawing.Size(1041, 191);
            this.tableSplitContainer1.SplitterDistance = 149;
            this.tableSplitContainer1.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sampleDataFile,
            this.sampleName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(149, 191);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.traChart_KeyPress);
            // 
            // sampleDataFile
            // 
            this.sampleDataFile.Text = "Data File";
            // 
            // sampleName
            // 
            this.sampleName.Text = "Sample Name";
            this.sampleName.Width = 84;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 645);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.traChart_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.traChart)).EndInit();
            this.chartPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedChartInfoTable)).EndInit();
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            this.mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.tableSplitContainer1.Panel1.ResumeLayout(false);
            this.tableSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableSplitContainer1)).EndInit();
            this.tableSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart traChart;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridView selectedChartInfoTable;
        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openButton;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.SplitContainer tableSplitContainer1;
        private System.Windows.Forms.ToolStripMenuItem optionsButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader sampleDataFile;
        private System.Windows.Forms.ColumnHeader sampleName;
        private System.Windows.Forms.ToolStripMenuItem refreshButton;
    }
}

