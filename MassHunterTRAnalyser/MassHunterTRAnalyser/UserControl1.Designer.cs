namespace MassHunterTRAnalyser
{
    partial class UserControl1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(120, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(613, 95);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.ScaleView.Zoomable = false;
            chartArea2.AxisY.MajorGrid.Enabled = false;
            chartArea2.CursorX.Interval = 0.01D;
            chartArea2.CursorX.IsUserEnabled = true;
            chartArea2.CursorX.IsUserSelectionEnabled = true;
            chartArea2.CursorX.LineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Enabled = false;
            this.chart1.Location = new System.Drawing.Point(0, 100);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(733, 334);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.SelectionRangeChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanging);
            this.chart1.SelectionRangeChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chart1_SelectionRangeChanged);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 3);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(114, 94);
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 437);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 115);
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
            this.addSelectionButton.Location = new System.Drawing.Point(453, 437);
            this.addSelectionButton.Name = "addSelectionButton";
            this.addSelectionButton.Size = new System.Drawing.Size(118, 23);
            this.addSelectionButton.TabIndex = 4;
            this.addSelectionButton.Text = "Add to all Samples";
            this.addSelectionButton.UseVisualStyleBackColor = true;
            this.addSelectionButton.Click += new System.EventHandler(this.addSelectionButton_Click);
            // 
            // selectedRangeRadio
            // 
            this.selectedRangeRadio.AutoSize = true;
            this.selectedRangeRadio.Location = new System.Drawing.Point(12, 42);
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
            this.groupBox1.Location = new System.Drawing.Point(453, 466);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 69);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Adding options";
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addSelectionButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(733, 555);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn SelectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectionEnd;
        private System.Windows.Forms.Button addSelectionButton;
        private System.Windows.Forms.RadioButton selectedRangeRadio;
        private System.Windows.Forms.RadioButton allRangeRadio;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
