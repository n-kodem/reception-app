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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void resCreator_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Form.ActiveForm.Controls)
            {
                ctrl.Dispose();
            }
            Form.ActiveForm.Controls.Add(new ResCreator());
        }

        private void adminPanel_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Form.ActiveForm.Controls)
            {
                ctrl.Dispose();
            }
            Form.ActiveForm.Controls.Add(new AdminPanel());
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
