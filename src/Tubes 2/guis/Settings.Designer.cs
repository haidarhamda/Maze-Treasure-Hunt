namespace WinFormsApp1
{
    partial class Settings
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
            this.FileLabel = new System.Windows.Forms.Label();
            this.FilenameTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.AlgorithmLabel = new System.Windows.Forms.Label();
            this.BFSButton = new System.Windows.Forms.RadioButton();
            this.DFSButton = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.DelaySlider = new System.Windows.Forms.TrackBar();
            this.SliderTextBox = new System.Windows.Forms.TextBox();
            this.TSPButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DelaySlider)).BeginInit();
            this.SuspendLayout();
            // 
            // FileLabel
            // 
            this.FileLabel.AutoSize = true;
            this.FileLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FileLabel.Location = new System.Drawing.Point(14, 36);
            this.FileLabel.Name = "FileLabel";
            this.FileLabel.Size = new System.Drawing.Size(51, 21);
            this.FileLabel.TabIndex = 0;
            this.FileLabel.Text = "File:";
            // 
            // FilenameTextBox
            // 
            this.FilenameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilenameTextBox.Enabled = false;
            this.FilenameTextBox.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilenameTextBox.Location = new System.Drawing.Point(14, 60);
            this.FilenameTextBox.Name = "FilenameTextBox";
            this.FilenameTextBox.ReadOnly = true;
            this.FilenameTextBox.Size = new System.Drawing.Size(379, 23);
            this.FilenameTextBox.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DodgerBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(399, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add File";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // AlgorithmLabel
            // 
            this.AlgorithmLabel.AutoSize = true;
            this.AlgorithmLabel.Font = new System.Drawing.Font("Century Schoolbook", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AlgorithmLabel.Location = new System.Drawing.Point(600, 36);
            this.AlgorithmLabel.Name = "AlgorithmLabel";
            this.AlgorithmLabel.Size = new System.Drawing.Size(105, 21);
            this.AlgorithmLabel.TabIndex = 3;
            this.AlgorithmLabel.Text = "Algorithm";
            // 
            // BFSButton
            // 
            this.BFSButton.AutoSize = true;
            this.BFSButton.Font = new System.Drawing.Font("Century Schoolbook", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.BFSButton.Location = new System.Drawing.Point(531, 64);
            this.BFSButton.Name = "BFSButton";
            this.BFSButton.Size = new System.Drawing.Size(62, 23);
            this.BFSButton.TabIndex = 4;
            this.BFSButton.TabStop = true;
            this.BFSButton.Text = "BFS";
            this.BFSButton.UseVisualStyleBackColor = true;
            this.BFSButton.CheckedChanged += new System.EventHandler(this.BFSButton_CheckedChanged);
            // 
            // DFSButton
            // 
            this.DFSButton.AutoSize = true;
            this.DFSButton.Font = new System.Drawing.Font("Century Schoolbook", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.DFSButton.Location = new System.Drawing.Point(619, 64);
            this.DFSButton.Name = "DFSButton";
            this.DFSButton.Size = new System.Drawing.Size(64, 23);
            this.DFSButton.TabIndex = 5;
            this.DFSButton.TabStop = true;
            this.DFSButton.Text = "DFS";
            this.DFSButton.UseVisualStyleBackColor = true;
            this.DFSButton.CheckedChanged += new System.EventHandler(this.DFSButton_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(786, 54);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(102, 36);
            this.button2.TabIndex = 6;
            this.button2.Text = "Visualize";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DelaySlider
            // 
            this.DelaySlider.LargeChange = 10;
            this.DelaySlider.Location = new System.Drawing.Point(83, 123);
            this.DelaySlider.Maximum = 100;
            this.DelaySlider.Minimum = 1;
            this.DelaySlider.Name = "DelaySlider";
            this.DelaySlider.Size = new System.Drawing.Size(600, 56);
            this.DelaySlider.TabIndex = 7;
            this.DelaySlider.Value = 1;
            this.DelaySlider.Scroll += new System.EventHandler(this.DelaySlider_Scroll);
            // 
            // SliderTextBox
            // 
            this.SliderTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SliderTextBox.Enabled = false;
            this.SliderTextBox.Font = new System.Drawing.Font("Century Schoolbook", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SliderTextBox.Location = new System.Drawing.Point(700, 123);
            this.SliderTextBox.Name = "SliderTextBox";
            this.SliderTextBox.Size = new System.Drawing.Size(72, 26);
            this.SliderTextBox.TabIndex = 8;
            this.SliderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TSPButton
            // 
            this.TSPButton.AutoSize = true;
            this.TSPButton.Font = new System.Drawing.Font("Century Schoolbook", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.TSPButton.Location = new System.Drawing.Point(700, 64);
            this.TSPButton.Name = "TSPButton";
            this.TSPButton.Size = new System.Drawing.Size(62, 23);
            this.TSPButton.TabIndex = 9;
            this.TSPButton.TabStop = true;
            this.TSPButton.Text = "TSP";
            this.TSPButton.UseVisualStyleBackColor = true;
            this.TSPButton.CheckedChanged += new System.EventHandler(this.TSPButton_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.TSPButton);
            this.Controls.Add(this.SliderTextBox);
            this.Controls.Add(this.DelaySlider);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DFSButton);
            this.Controls.Add(this.BFSButton);
            this.Controls.Add(this.AlgorithmLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FilenameTextBox);
            this.Controls.Add(this.FileLabel);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(935, 203);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DelaySlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label FileLabel;
        private TextBox FilenameTextBox;
        private Button button1;
        private Label AlgorithmLabel;
        private RadioButton BFSButton;
        private RadioButton DFSButton;
        private Button button2;
        private TrackBar DelaySlider;
        private TextBox SliderTextBox;
        private RadioButton TSPButton;
    }
}
