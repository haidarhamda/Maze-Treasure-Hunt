namespace Tubes_2
{
    partial class Legend
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
            this.label4 = new System.Windows.Forms.Label();
            this.IndianRedBox = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BlueBox = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.YellowBox = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(776, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Solution";
            // 
            // IndianRedBox
            // 
            this.IndianRedBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.IndianRedBox.Enabled = false;
            this.IndianRedBox.Location = new System.Drawing.Point(728, 15);
            this.IndianRedBox.Name = "IndianRedBox";
            this.IndianRedBox.Size = new System.Drawing.Size(29, 29);
            this.IndianRedBox.TabIndex = 14;
            this.IndianRedBox.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(432, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 19);
            this.label3.TabIndex = 13;
            this.label3.Text = "Current";
            // 
            // BlueBox
            // 
            this.BlueBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.BlueBox.Enabled = false;
            this.BlueBox.Location = new System.Drawing.Point(384, 15);
            this.BlueBox.Name = "BlueBox";
            this.BlueBox.Size = new System.Drawing.Size(29, 29);
            this.BlueBox.TabIndex = 12;
            this.BlueBox.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 9;
            this.label1.Text = "Visited";
            // 
            // YellowBox
            // 
            this.YellowBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.YellowBox.Enabled = false;
            this.YellowBox.Location = new System.Drawing.Point(22, 15);
            this.YellowBox.Name = "YellowBox";
            this.YellowBox.Size = new System.Drawing.Size(29, 29);
            this.YellowBox.TabIndex = 8;
            this.YellowBox.UseVisualStyleBackColor = false;
            // 
            // Legend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IndianRedBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BlueBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YellowBox);
            this.Name = "Legend";
            this.Size = new System.Drawing.Size(869, 62);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label4;
        private Button IndianRedBox;
        private Label label3;
        private Button BlueBox;
        private Label label1;
        private Button YellowBox;
    }
}
