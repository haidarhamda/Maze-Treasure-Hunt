using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        private String _mapFile;
        private int _algoChoice = -1;
        private bool _safeSettings = false;

        public event EventHandler SettingsChanged;

        public String mapfFile{ get; set; }
        public int algoChoice { get; set; }
        public bool safeSettings { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            if(mapfFile != null)
            {
                _safeSettings = true;
                this.SettingsChanged(sender, EventArgs.Empty);
                //MessageBox.Show(mapfFile, "File Detected");
            }
            else
            {
                MessageBox.Show("No file detected. Please insert a maze file for visualization.", "No File Detected");
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilenameTextBox.Text = ofd.FileName;
                mapfFile = ofd.FileName;

            }
        }

        private void BFSButton_CheckedChanged(object sender, EventArgs e)
        {
            if (BFSButton.Checked)
            {
                algoChoice = 0;
            }
            else
            {
                algoChoice = 1;
            }
        }

        private void DFSButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DFSButton.Checked)
            {
                algoChoice = 1;
            }
            else
            {
                algoChoice = 0;
            }
        }
    }
}
