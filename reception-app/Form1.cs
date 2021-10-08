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
            //TODO: DB integration
            //TODO: FULL ADMIN PANEL PHPMyAdmin query like
            //TODO: Settings
            //TODO: Backup system
            //TODO: Time count to next Reservation
            //TODO: Finish exit ask system (Performane etc.)
            //TODO: All other things frop paper card

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Dispose();
            }
            this.Controls.Add(new UserControl1());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var window = MessageBox.Show(
                "Close the window?",
                "Are you sure?",
                MessageBoxButtons.YesNo);

            e.Cancel = (window == DialogResult.No);
        }


    }
}
