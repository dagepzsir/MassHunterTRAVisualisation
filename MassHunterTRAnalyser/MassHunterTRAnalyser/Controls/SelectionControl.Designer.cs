namespace MassHunterTRAnalyser
{
    partial class SelectionControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SelectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.SelectionStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectionEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addSelectionButton = new System.Windows.Forms.Button();
            this.selectedRangeRadio = new System.Windows.Forms.RadioButton();
            this.allRangeRadio = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.dataFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sampleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sampleType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.ScaleView.Zoomable = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.CursorX.Interval = 0.001D;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorX.LineWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(228, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(736, 434);
            this.chart1.SuppressExceptions = true;
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.SelectionRangeChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanging);
            this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(825, 441);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(136, 109);
            this.checkedListBox1.TabIndex = 2;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectionName,
            this.SelectionType,
            this.SelectionStart,
            this.SelectionEnd});
            this.dataGridView1.Location = new System.Drawing.Point(228, 437);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(450, 115);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // SelectionName
            // 
            this.SelectionName.HeaderText = "Selection Name";
            this.SelectionName.Name = "SelectionName";
            // 
            // SelectionType
            // 
            this.SelectionType.HeaderText = "Selection Type";
            this.SelectionType.Items.AddRange(new object[] {
            "None",
            "Background",
            "Data"});
            this.SelectionType.Name = "SelectionType";
            // 
            // SelectionStart
            // 
            this.SelectionStart.HeaderText = "Selection Start";
            this.SelectionStart.Name = "SelectionStart";
            // 
            // SelectionEnd
            // 
            this.SelectionEnd.HeaderText = "Selection End";
            this.SelectionEnd.Name = "SelectionEnd";
            // 
            // addSelectionButton
            // 
            this.addSelectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addSelectionButton.Location = new System.Drawing.Point(684, 460);
            this.addSelectionButton.Name = "addSelectionButton";
            this.addSelectionButton.Size = new System.Drawing.Size(118, 23);
            this.addSelectionButton.TabIndex = 4;
            this.addSelectionButton.Text = "Apply to all Samples";
            this.addSelectionButton.UseVisualStyleBackColor = true;
            this.addSelectionButton.Click += new System.EventHandler(this.addSelectionButton_Click);
            // 
            // selectedRangeRadio
            // 
            this.selectedRangeRadio.AutoSize = true;
            this.selectedRangeRadio.Location = new System.Drawing.Point(12, 40);
            this.selectedRangeRadio.Name = "selectedRangeRadio";
            this.selectedRangeRadio.Size = new System.Drawing.Size(117, 17);
            this.selectedRangeRadio.TabIndex = 5;
            this.selectedRangeRadio.Text = "Selected selections";
            this.selectedRangeRadio.UseVisualStyleBackColor = true;
            // 
            // allRangeRadio
            // 
            this.allRangeRadio.AutoSize = true;
            this.allRangeRadio.Checked = true;
            this.allRangeRadio.Location = new System.Drawing.Point(12, 19);
            this.allRangeRadio.Name = "allRangeRadio";
            this.allRangeRadio.Size = new System.Drawing.Size(86, 17);
            this.allRangeRadio.TabIndex = 6;
            this.allRangeRadio.TabStop = true;
            this.allRangeRadio.Text = "All selections";
            this.allRangeRadio.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.allRangeRadio);
            this.groupBox1.Controls.Add(this.selectedRangeRadio);
            this.groupBox1.Location = new System.Drawing.Point(684, 489);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding options";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dataFile,
            this.sampleName,
            this.sampleType});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(225, 555);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // dataFile
            // 
            this.dataFile.Text = "Data File";
            // 
            // sampleName
            // 
            this.sampleName.Text = "Sample Name";
            this.sampleName.Width = 79;
            // 
            // sampleType
            // 
            this.sampleType.Text = "Sample Type";
            this.sampleType.Width = 82;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(684, 437);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(69, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Logscale";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // SelectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addSelectionButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.chart1);
            this.Name = "SelectionControl";
            this.Size = new System.Drawing.Size(964, 555);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button addSelectionButton;
        private System.Windows.Forms.RadioButton selectedRangeRadio;
        private System.Windows.Forms.RadioButton allRangeRadio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader dataFile;
        private System.Windows.Forms.ColumnHeader sampleName;
        private System.Windows.Forms.ColumnHeader sampleType;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn SelectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionEnd;
        public System.Windows.Forms.ListView listView1;
    }
}
