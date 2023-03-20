﻿namespace WinFormsApp1
{
    partial class Output
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
            this.RouteLabel = new System.Windows.Forms.Label();
            this.NodesLabel = new System.Windows.Forms.Label();
            this.StepsLabel = new System.Windows.Forms.Label();
            this.ExecTimeLabel = new System.Windows.Forms.Label();
            this.RouteTextBox = new System.Windows.Forms.TextBox();
            this.NodesTextBox = new System.Windows.Forms.TextBox();
            this.StepsTextBox = new System.Windows.Forms.TextBox();
            this.ExecTimeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RouteLabel
            // 
            this.RouteLabel.AutoSize = true;
            this.RouteLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RouteLabel.Location = new System.Drawing.Point(47, 35);
            this.RouteLabel.Name = "RouteLabel";
            this.RouteLabel.Size = new System.Drawing.Size(73, 21);
            this.RouteLabel.TabIndex = 0;
            this.RouteLabel.Text = "Route: ";
            // 
            // NodesLabel
            // 
            this.NodesLabel.AutoSize = true;
            this.NodesLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NodesLabel.Location = new System.Drawing.Point(47, 93);
            this.NodesLabel.Name = "NodesLabel";
            this.NodesLabel.Size = new System.Drawing.Size(69, 21);
            this.NodesLabel.TabIndex = 1;
            this.NodesLabel.Text = "Nodes:";
            // 
            // StepsLabel
            // 
            this.StepsLabel.AutoSize = true;
            this.StepsLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StepsLabel.Location = new System.Drawing.Point(558, 35);
            this.StepsLabel.Name = "StepsLabel";
            this.StepsLabel.Size = new System.Drawing.Size(62, 21);
            this.StepsLabel.TabIndex = 2;
            this.StepsLabel.Text = "Steps:";
            // 
            // ExecTimeLabel
            // 
            this.ExecTimeLabel.AutoSize = true;
            this.ExecTimeLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecTimeLabel.Location = new System.Drawing.Point(558, 93);
            this.ExecTimeLabel.Name = "ExecTimeLabel";
            this.ExecTimeLabel.Size = new System.Drawing.Size(153, 21);
            this.ExecTimeLabel.TabIndex = 3;
            this.ExecTimeLabel.Text = "Execution Time:";
            // 
            // RouteTextBox
            // 
            this.RouteTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RouteTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RouteTextBox.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RouteTextBox.Location = new System.Drawing.Point(137, 35);
            this.RouteTextBox.Name = "RouteTextBox";
            this.RouteTextBox.Size = new System.Drawing.Size(381, 21);
            this.RouteTextBox.TabIndex = 4;
            this.RouteTextBox.Text = "0";
            // 
            // NodesTextBox
            // 
            this.NodesTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NodesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NodesTextBox.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.NodesTextBox.Location = new System.Drawing.Point(137, 93);
            this.NodesTextBox.Name = "NodesTextBox";
            this.NodesTextBox.Size = new System.Drawing.Size(381, 21);
            this.NodesTextBox.TabIndex = 5;
            this.NodesTextBox.Text = "0";
            // 
            // StepsTextBox
            // 
            this.StepsTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StepsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StepsTextBox.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.StepsTextBox.Location = new System.Drawing.Point(626, 35);
            this.StepsTextBox.Name = "StepsTextBox";
            this.StepsTextBox.Size = new System.Drawing.Size(209, 21);
            this.StepsTextBox.TabIndex = 6;
            this.StepsTextBox.Text = "0";
            // 
            // ExecTimeTextBox
            // 
            this.ExecTimeTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ExecTimeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ExecTimeTextBox.Font = new System.Drawing.Font("Century Schoolbook", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExecTimeTextBox.Location = new System.Drawing.Point(717, 93);
            this.ExecTimeTextBox.Name = "ExecTimeTextBox";
            this.ExecTimeTextBox.Size = new System.Drawing.Size(196, 21);
            this.ExecTimeTextBox.TabIndex = 7;
            this.ExecTimeTextBox.Text = "0";
            // 
            // Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.ExecTimeTextBox);
            this.Controls.Add(this.StepsTextBox);
            this.Controls.Add(this.NodesTextBox);
            this.Controls.Add(this.RouteTextBox);
            this.Controls.Add(this.ExecTimeLabel);
            this.Controls.Add(this.StepsLabel);
            this.Controls.Add(this.NodesLabel);
            this.Controls.Add(this.RouteLabel);
            this.Name = "Output";
            this.Size = new System.Drawing.Size(935, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label RouteLabel;
        private Label NodesLabel;
        private Label StepsLabel;
        private Label ExecTimeLabel;
        private TextBox RouteTextBox;
        private TextBox NodesTextBox;
        private TextBox StepsTextBox;
        private TextBox ExecTimeTextBox;
    }
}