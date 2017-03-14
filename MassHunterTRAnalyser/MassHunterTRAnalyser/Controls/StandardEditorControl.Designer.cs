namespace MassHunterTRAnalyser.Controls
{
    partial class StandardEditorControl
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.standardName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addStdButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.elementDataGridView = new System.Windows.Forms.DataGridView();
            this.elementNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.isotopeRatioDataGridView = new System.Windows.Forms.DataGridView();
            this.elementsNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeratorIsotope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.denominatorIsotope = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ratioColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.elementDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isotopeRatioDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.standardName});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(159, 389);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // standardName
            // 
            this.standardName.Text = "Standard Name";
            this.standardName.Width = 153;
            // 
            // addStdButton
            // 
            this.addStdButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addStdButton.Location = new System.Drawing.Point(3, 395);
            this.addStdButton.Name = "addStdButton";
            this.addStdButton.Size = new System.Drawing.Size(75, 23);
            this.addStdButton.TabIndex = 1;
            this.addStdButton.Text = "Add";
            this.addStdButton.UseVisualStyleBackColor = true;
            this.addStdButton.Click += new System.EventHandler(this.addStdButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(84, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // elementDataGridView
            // 
            this.elementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elementNameColumn,
            this.concColumn,
            this.unitColumn});
            this.elementDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementDataGridView.Enabled = false;
            this.elementDataGridView.Location = new System.Drawing.Point(0, 0);
            this.elementDataGridView.Name = "elementDataGridView";
            this.elementDataGridView.Size = new System.Drawing.Size(681, 244);
            this.elementDataGridView.TabIndex = 3;
            this.elementDataGridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.elementDataGridView_CellEnter);
            this.elementDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.elementDataGridView_CellValueChanged);
            // 
            // elementNameColumn
            // 
            this.elementNameColumn.HeaderText = "Element";
            this.elementNameColumn.Name = "elementNameColumn";
            // 
            // concColumn
            // 
            this.concColumn.HeaderText = "Concentration";
            this.concColumn.Name = "concColumn";
            // 
            // unitColumn
            // 
            this.unitColumn.HeaderText = "Unit";
            this.unitColumn.Items.AddRange(new object[] {
            "ug/kg",
            "mg/kg",
            "(m/m)%",
            "ug/g",
            "mg/g"});
            this.unitColumn.Name = "unitColumn";
            // 
            // isotopeRatioDataGridView
            // 
            this.isotopeRatioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.isotopeRatioDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.elementsNameColumn,
            this.numeratorIsotope,
            this.denominatorIsotope,
            this.ratioColumn});
            this.isotopeRatioDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isotopeRatioDataGridView.Enabled = false;
            this.isotopeRatioDataGridView.Location = new System.Drawing.Point(0, 0);
            this.isotopeRatioDataGridView.Name = "isotopeRatioDataGridView";
            this.isotopeRatioDataGridView.Size = new System.Drawing.Size(681, 157);
            this.isotopeRatioDataGridView.TabIndex = 4;
            // 
            // elementsNameColumn
            // 
            this.elementsNameColumn.HeaderText = "Element(s)";
            this.elementsNameColumn.Name = "elementsNameColumn";
            // 
            // numeratorIsotope
            // 
            this.numeratorIsotope.HeaderText = "Numerator Isotope";
            this.numeratorIsotope.Name = "numeratorIsotope";
            // 
            // denominatorIsotope
            // 
            this.denominatorIsotope.HeaderText = "Denominator Isotope";
            this.denominatorIsotope.Name = "denominatorIsotope";
            // 
            // ratioColumn
            // 
            this.ratioColumn.HeaderText = "Ratio";
            this.ratioColumn.Name = "ratioColumn";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Location = new System.Drawing.Point(165, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 424);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standard Data";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.elementDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.isotopeRatioDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(681, 405);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 5;
            // 
            // StandardEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.addStdButton);
            this.Controls.Add(this.listView1);
            this.Name = "StandardEditorControl";
            this.Size = new System.Drawing.Size(852, 427);
            this.Load += new System.EventHandler(this.StandardEditorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elementDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isotopeRatioDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColumnHeader standardName;
        private System.Windows.Forms.Button addStdButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView elementDataGridView;
        private System.Windows.Forms.DataGridView isotopeRatioDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn elementNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn concColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn unitColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn elementsNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeratorIsotope;
        private System.Windows.Forms.DataGridViewTextBoxColumn denominatorIsotope;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratioColumn;
        public System.Windows.Forms.ListView listView1;
    }
}
