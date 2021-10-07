using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reception_app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Dispose();
            }
            this.Controls.Add(new UserControl1());
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
