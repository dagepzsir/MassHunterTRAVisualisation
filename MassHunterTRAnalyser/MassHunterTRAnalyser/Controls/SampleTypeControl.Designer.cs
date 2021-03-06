﻿namespace MassHunterTRAnalyser
{
    partial class SampleTypeControl
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.sampleTree = new System.Windows.Forms.TreeView();
            this.rjctSample = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sampleDataFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sampleType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.standardLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standardType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.sampleGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rjctSample,
            this.sampleDataFile,
            this.sampleName,
            this.sampleComment,
            this.sampleType,
            this.standardLevel,
            this.standardType,
            this.sampleGroup});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(734, 465);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEnter);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // sampleTree
            // 
            this.sampleTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampleTree.Location = new System.Drawing.Point(740, 0);
            this.sampleTree.Name = "sampleTree";
            this.sampleTree.Size = new System.Drawing.Size(270, 465);
            this.sampleTree.TabIndex = 4;
            // 
            // rjctSample
            // 
            this.rjctSample.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rjctSample.FalseValue = "False";
            this.rjctSample.HeaderText = "Rjct";
            this.rjctSample.IndeterminateValue = "kozep";
            this.rjctSample.Name = "rjctSample";
            this.rjctSample.TrueValue = "True";
            this.rjctSample.Width = 32;
            // 
            // sampleDataFile
            // 
            this.sampleDataFile.HeaderText = "Data File";
            this.sampleDataFile.Name = "sampleDataFile";
            this.sampleDataFile.ReadOnly = true;
            // 
            // sampleName
            // 
            this.sampleName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sampleName.HeaderText = "Sample Name";
            this.sampleName.Name = "sampleName";
            this.sampleName.Width = 98;
            // 
            // sampleComment
            // 
            this.sampleComment.HeaderText = "Comment";
            this.sampleComment.Name = "sampleComment";
            // 
            // sampleType
            // 
            this.sampleType.HeaderText = "Sample Type";
            this.sampleType.Items.AddRange(new object[] {
            "Not set",
            "Blank",
            "Standard",
            "Sample"});
            this.sampleType.Name = "sampleType";
            this.sampleType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sampleType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // standardLevel
            // 
            this.standardLevel.HeaderText = "Standard Level";
            this.standardLevel.Name = "standardLevel";
            // 
            // standardType
            // 
            this.standardType.HeaderText = "Standard Type";
            this.standardType.Name = "standardType";
            this.standardType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.standardType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // sampleGroup
            // 
            this.sampleGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sampleGroup.HeaderText = "Sample Group";
            this.sampleGroup.Name = "sampleGroup";
            // 
            // SampleTypeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sampleTree);
            this.Controls.Add(this.dataGridView1);
            this.Name = "SampleTypeControl";
            this.Size = new System.Drawing.Size(1010, 468);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TreeView sampleTree;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rjctSample;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleDataFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleComment;
        private System.Windows.Forms.DataGridViewComboBoxColumn sampleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn standardLevel;
        private System.Windows.Forms.DataGridViewComboBoxColumn standardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn sampleGroup;
    }
}
