using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Output : UserControl
    {
        public Output()
        {
            InitializeComponent();
        }

        private String _route;
        private String _execTime;
        private String _nodes;
        private String _steps;

        public String route 
        {
            get { return _route; }
            set {_route = value; RouteTextBox.Text = _route; } 
        }
        public String execTime
        {
            get { return _execTime; }
            set { _execTime = value; ExecTimeTextBox.Text = _execTime; }
        }
        public String nodes 
        {
            get { return _nodes; }
            set { _nodes = value; NodesTextBox.Text = _nodes; }
        }
        public String steps
        {
            get { return _steps; }
            set { _steps = value; StepsTextBox.Text = _steps; }
        }

        private void StepsLabel_Click(object sender, EventArgs e)
        {

        }

        private void Output_Load(object sender, EventArgs e)
        {

        }

        private void RouteTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
