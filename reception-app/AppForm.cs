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
    public partial class AppForm : Form
    {
        public AppForm()
        {
            //TODO: Settings
            //TODO: Backup system

            this.Size = new Size(800,600);

            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Dispose();
            }
            this.Controls.Add(new MainPanel());
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
