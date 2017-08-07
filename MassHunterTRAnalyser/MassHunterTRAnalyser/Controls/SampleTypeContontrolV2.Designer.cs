namespace MassHunterTRAnalyser.Controls
{
    partial class SampleTypeContontrolV2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.rejectedColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataFileColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.standardTypeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.standardGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleGroupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(1034, 499);
            this.splitContainer1.SplitterDistance = 749;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rejectedColumn,
            this.dataFileColumn,
            this.sampleNameColumn,
            this.commentColumn,
            this.sampleTypeColumn,
            this.standardTypeColumn,
            this.standardGroupColumn,
            this.sampleGroupColumn});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(749, 499);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(281, 499);
            this.treeView1.TabIndex = 0;
            // 
            // rejectedColumn
            // 
            this.rejectedColumn.HeaderText = "Rjct";
            this.rejectedColumn.Name = "rejectedColumn";
            this.rejectedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rejectedColumn.Width = 30;
            // 
            // dataFileColumn
            // 
            this.dataFileColumn.HeaderText = "Data File";
            this.dataFileColumn.Name = "dataFileColumn";
            // 
            // sampleNameColumn
            // 
            this.sampleNameColumn.HeaderText = "Sample Name";
            this.sampleNameColumn.Name = "sampleNameColumn";
            // 
            // commentColumn
            // 
            this.commentColumn.HeaderText = "Comment";
            this.commentColumn.Name = "commentColumn";
            // 
            // sampleTypeColumn
            // 
            this.sampleTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.sampleTypeColumn.HeaderText = "Sample Type";
            this.sampleTypeColumn.Name = "sampleTypeColumn";
            this.sampleTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sampleTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // standardTypeColumn
            // 
            this.standardTypeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.standardTypeColumn.HeaderText = "Standard type";
            this.standardTypeColumn.Name = "standardTypeColumn";
            this.standardTypeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.standardTypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // standardGroupColumn
            // 
            this.standardGroupColumn.HeaderText = "Standard Group";
            this.standardGroupColumn.Name = "standardGroupColumn";
            // 
            // sampleGroupColumn
            // 
            this.sampleGroupColumn.HeaderText = "Sample Group";
            this.sampleGroupColumn.Name = "sampleGroupColumn";
            // 
            // SampleTypeContontrolV2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "SampleTypeContontrolV2";
            this.Size = new System.Drawing.Size(1034, 499);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rejectedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataFileColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn sampleTypeColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn standardTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardGroupColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleGroupColumn;
    }
}
