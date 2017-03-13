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
            this.isotopeRatioDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.elementDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.isotopeRatioDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.standardName});
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(159, 371);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // standardName
            // 
            this.standardName.Text = "Standard Name";
            this.standardName.Width = 153;
            // 
            // addStdButton
            // 
            this.addStdButton.Location = new System.Drawing.Point(3, 377);
            this.addStdButton.Name = "addStdButton";
            this.addStdButton.Size = new System.Drawing.Size(75, 23);
            this.addStdButton.TabIndex = 1;
            this.addStdButton.Text = "Add";
            this.addStdButton.UseVisualStyleBackColor = true;
            this.addStdButton.Click += new System.EventHandler(this.addStdButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // elementDataGridView
            // 
            this.elementDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.elementDataGridView.Location = new System.Drawing.Point(6, 19);
            this.elementDataGridView.Name = "elementDataGridView";
            this.elementDataGridView.Size = new System.Drawing.Size(675, 225);
            this.elementDataGridView.TabIndex = 3;
            // 
            // isotopeRatioDataGridView
            // 
            this.isotopeRatioDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.isotopeRatioDataGridView.Location = new System.Drawing.Point(6, 250);
            this.isotopeRatioDataGridView.Name = "isotopeRatioDataGridView";
            this.isotopeRatioDataGridView.Size = new System.Drawing.Size(675, 150);
            this.isotopeRatioDataGridView.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.elementDataGridView);
            this.groupBox1.Controls.Add(this.isotopeRatioDataGridView);
            this.groupBox1.Location = new System.Drawing.Point(165, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 406);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Standard Data";
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
            this.Size = new System.Drawing.Size(852, 409);
            this.Load += new System.EventHandler(this.StandardEditorControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.elementDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.isotopeRatioDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader standardName;
        private System.Windows.Forms.Button addStdButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView elementDataGridView;
        private System.Windows.Forms.DataGridView isotopeRatioDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
