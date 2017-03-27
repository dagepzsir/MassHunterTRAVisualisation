namespace MassHunterTRAnalyser.Controls
{
    partial class CalibrationControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartOptions = new System.Windows.Forms.GroupBox();
            this.yTitleBoldCheckBox = new System.Windows.Forms.CheckBox();
            this.xTitleBoldCheckBox = new System.Windows.Forms.CheckBox();
            this.yIntervallTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.xIntervallTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.yTitelTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.xTitleTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yMaxTextBox = new System.Windows.Forms.TextBox();
            this.yMinTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xMaxTextbox = new System.Windows.Forms.TextBox();
            this.xMinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.chartOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.Title = "Koncentráció (ug/g)";
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.AxisY.Title = "Jel (cps)";
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(805, 321);
            this.chart1.TabIndex = 0;
            this.chart1.TabStop = false;
            this.chart1.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(492, 136);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.TabStop = false;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chart1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartOptions);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(805, 461);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.TabIndex = 2;
            // 
            // chartOptions
            // 
            this.chartOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chartOptions.Controls.Add(this.yTitleBoldCheckBox);
            this.chartOptions.Controls.Add(this.xTitleBoldCheckBox);
            this.chartOptions.Controls.Add(this.yIntervallTextBox);
            this.chartOptions.Controls.Add(this.label7);
            this.chartOptions.Controls.Add(this.xIntervallTextBox);
            this.chartOptions.Controls.Add(this.label8);
            this.chartOptions.Controls.Add(this.yTitelTextBox);
            this.chartOptions.Controls.Add(this.label6);
            this.chartOptions.Controls.Add(this.xTitleTextBox);
            this.chartOptions.Controls.Add(this.label5);
            this.chartOptions.Controls.Add(this.label3);
            this.chartOptions.Controls.Add(this.yMaxTextBox);
            this.chartOptions.Controls.Add(this.yMinTextBox);
            this.chartOptions.Controls.Add(this.label4);
            this.chartOptions.Controls.Add(this.label2);
            this.chartOptions.Controls.Add(this.xMaxTextbox);
            this.chartOptions.Controls.Add(this.xMinTextBox);
            this.chartOptions.Controls.Add(this.label1);
            this.chartOptions.Location = new System.Drawing.Point(498, 3);
            this.chartOptions.Name = "chartOptions";
            this.chartOptions.Size = new System.Drawing.Size(307, 130);
            this.chartOptions.TabIndex = 1;
            this.chartOptions.TabStop = false;
            this.chartOptions.Text = "Chart Options";
            // 
            // yTitleBoldCheckBox
            // 
            this.yTitleBoldCheckBox.AutoSize = true;
            this.yTitleBoldCheckBox.Location = new System.Drawing.Point(193, 100);
            this.yTitleBoldCheckBox.Name = "yTitleBoldCheckBox";
            this.yTitleBoldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.yTitleBoldCheckBox.TabIndex = 10;
            this.yTitleBoldCheckBox.Text = "Bold";
            this.yTitleBoldCheckBox.UseVisualStyleBackColor = true;
            // 
            // xTitleBoldCheckBox
            // 
            this.xTitleBoldCheckBox.AutoSize = true;
            this.xTitleBoldCheckBox.Location = new System.Drawing.Point(193, 74);
            this.xTitleBoldCheckBox.Name = "xTitleBoldCheckBox";
            this.xTitleBoldCheckBox.Size = new System.Drawing.Size(47, 17);
            this.xTitleBoldCheckBox.TabIndex = 8;
            this.xTitleBoldCheckBox.Text = "Bold";
            this.xTitleBoldCheckBox.UseVisualStyleBackColor = true;
            // 
            // yIntervallTextBox
            // 
            this.yIntervallTextBox.Location = new System.Drawing.Point(256, 45);
            this.yIntervallTextBox.Name = "yIntervallTextBox";
            this.yIntervallTextBox.Size = new System.Drawing.Size(45, 20);
            this.yIntervallTextBox.TabIndex = 6;
            this.yIntervallTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.yIntervallTextBox_Validating);
            this.yIntervallTextBox.Validated += new System.EventHandler(this.yIntervallTextBox_Validated);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(193, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Y Intervall:";
            // 
            // xIntervallTextBox
            // 
            this.xIntervallTextBox.Location = new System.Drawing.Point(256, 19);
            this.xIntervallTextBox.Name = "xIntervallTextBox";
            this.xIntervallTextBox.Size = new System.Drawing.Size(45, 20);
            this.xIntervallTextBox.TabIndex = 5;
            this.xIntervallTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.xIntervallTextBox_Validating);
            this.xIntervallTextBox.Validated += new System.EventHandler(this.xIntervallTextBox_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(193, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "X Intervall:";
            // 
            // yTitelTextBox
            // 
            this.yTitelTextBox.Location = new System.Drawing.Point(53, 98);
            this.yTitelTextBox.Name = "yTitelTextBox";
            this.yTitelTextBox.Size = new System.Drawing.Size(134, 20);
            this.yTitelTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Y Title:";
            // 
            // xTitleTextBox
            // 
            this.xTitleTextBox.Location = new System.Drawing.Point(53, 72);
            this.xTitleTextBox.Name = "xTitleTextBox";
            this.xTitleTextBox.Size = new System.Drawing.Size(134, 20);
            this.xTitleTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "X Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Y Max:";
            // 
            // yMaxTextBox
            // 
            this.yMaxTextBox.Location = new System.Drawing.Point(143, 45);
            this.yMaxTextBox.Name = "yMaxTextBox";
            this.yMaxTextBox.Size = new System.Drawing.Size(44, 20);
            this.yMaxTextBox.TabIndex = 4;
            this.yMaxTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.yMaxTextBox_Validating);
            this.yMaxTextBox.Validated += new System.EventHandler(this.yMaxTextBox_Validated);
            // 
            // yMinTextBox
            // 
            this.yMinTextBox.Location = new System.Drawing.Point(143, 19);
            this.yMinTextBox.Name = "yMinTextBox";
            this.yMinTextBox.Size = new System.Drawing.Size(44, 20);
            this.yMinTextBox.TabIndex = 3;
            this.yMinTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.yMinTextBox_Validating);
            this.yMinTextBox.Validated += new System.EventHandler(this.yMinTextBox_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Y Min:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X Max:";
            // 
            // xMaxTextbox
            // 
            this.xMaxTextbox.Location = new System.Drawing.Point(53, 45);
            this.xMaxTextbox.Name = "xMaxTextbox";
            this.xMaxTextbox.Size = new System.Drawing.Size(44, 20);
            this.xMaxTextbox.TabIndex = 2;
            this.xMaxTextbox.Validating += new System.ComponentModel.CancelEventHandler(this.xMaxTextbox_Validating);
            this.xMaxTextbox.Validated += new System.EventHandler(this.xMaxTextbox_Validated);
            // 
            // xMinTextBox
            // 
            this.xMinTextBox.Location = new System.Drawing.Point(53, 19);
            this.xMinTextBox.Name = "xMinTextBox";
            this.xMinTextBox.Size = new System.Drawing.Size(44, 20);
            this.xMinTextBox.TabIndex = 1;
            this.xMinTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.xMinTextBox_KeyUp);
            this.xMinTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.xMinTextBox_Validating);
            this.xMinTextBox.Validated += new System.EventHandler(this.xMinTextBox_Validated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X Min:";
            // 
            // CalibrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "CalibrationControl";
            this.Size = new System.Drawing.Size(805, 461);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.chartOptions.ResumeLayout(false);
            this.chartOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox chartOptions;
        private System.Windows.Forms.CheckBox yTitleBoldCheckBox;
        private System.Windows.Forms.CheckBox xTitleBoldCheckBox;
        private System.Windows.Forms.TextBox yIntervallTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox xIntervallTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox yTitelTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox xTitleTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox yMaxTextBox;
        private System.Windows.Forms.TextBox yMinTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox xMaxTextbox;
        private System.Windows.Forms.TextBox xMinTextBox;
        private System.Windows.Forms.Label label1;
    }
}
