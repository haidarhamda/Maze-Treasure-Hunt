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
        public String execTime { get; set; }
        public String nodes 
        {
            get { return _nodes; }
            set { _nodes = value; NodesTextBox.Text = _nodes; }
        }
        public String steps { get; set; }

        private void StepsLabel_Click(object sender, EventArgs e)
        {

        }


    }
}
