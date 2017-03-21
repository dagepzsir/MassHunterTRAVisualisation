namespace MassHunterTRAnalyser.Controls
{
    partial class SampleGroupping
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("sample1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("sample2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Group1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("sample1");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Group2", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.ungruppedSamples = new System.Windows.Forms.ListView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // ungruppedSamples
            // 
            this.ungruppedSamples.Location = new System.Drawing.Point(284, 0);
            this.ungruppedSamples.Name = "ungruppedSamples";
            this.ungruppedSamples.Size = new System.Drawing.Size(273, 438);
            this.ungruppedSamples.TabIndex = 1;
            this.ungruppedSamples.UseCompatibleStateImageBehavior = false;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node1";
            treeNode1.Text = "sample1";
            treeNode2.Name = "Node3";
            treeNode2.Text = "sample2";
            treeNode3.Name = "Node0";
            treeNode3.Text = "Group1";
            treeNode4.Name = "Node5";
            treeNode4.Text = "sample1";
            treeNode5.Name = "Node4";
            treeNode5.Text = "Group2";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(278, 438);
            this.treeView1.TabIndex = 2;
            // 
            // SampleGroupping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.ungruppedSamples);
            this.Name = "SampleGroupping";
            this.Size = new System.Drawing.Size(557, 459);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ungruppedSamples;
        private System.Windows.Forms.TreeView treeView1;
    }
}
