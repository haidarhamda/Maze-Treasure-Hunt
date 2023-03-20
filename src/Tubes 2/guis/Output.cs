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

        public String route { get; set; }
        public String execTime { get; set; }
        public String nodes { get; set; }
        public String steps { get; set; }
    }
}
