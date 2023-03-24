using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_2
{
    public partial class Legend : UserControl
    {
        public Legend()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            YellowBox.BackColor = Color.Yellow;
            BlueBox.BackColor = Color.Blue;
            IndianRedBox.BackColor = Color.IndianRed;
        }
    }
}
