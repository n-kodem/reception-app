using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace reception_app
{
    public partial class ResCreator : UserControl
    {
        public ResCreator()
        {
            InitializeComponent();
        }

        private void ResCreator_Load(object sender, EventArgs e)
        {
            nameInp.Init("Patient name");
            researchInp.Init("Research name");
            dayShower.Text = "Today is: " + DateTime.Today;
            hourLab.Text = "Time: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            dateInp.Value = DateTime.Now.Date;


            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            bool newdb = File.Exists("reception.db");
            if (newdb == true)
            {
                sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
                sqlite_conn.Open();
                MessageBox.Show("31");
            }
            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=reception.db;Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "CREATE TABLE Client (id integer primary key, Title  varchar(100),Name  varchar(100),Surname  varchar(100),Dateofbirth DateTime , Propertyname varchar(100),Moveindate DateTime,Relationship varchar(100),Spouse  varchar(100),Gender  varchar(100), spTitle  varchar(100),SpouseName  varchar(100),SpouseSurname  varchar(100),spDateofbirth DateTime ,spRelationship varchar(100),spSpouse  varchar(100),spGender  varchar(100));";
                sqlite_cmd.ExecuteNonQuery();
            }
            sqlite_conn.Close();
        }
        private void tenMinTimer_Tick(object sender, EventArgs e)
        {
            hourLab.Text = "Time: "+ DateTime.Now.Hour+":"+DateTime.Now.Minute;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (
                nameInp.Text!= "Patient name" ||
                researchInp.Text != "Research name" ||
                nameInp.Text=="" ||
                researchInp.Text=="" ||
                dateInp.Value!=DateTime.Now.Date
                )
            {
                var window = MessageBox.Show(
                "Do you really want to cancel reservation?",
                "Close Window",
                MessageBoxButtons.YesNo);

                if (window == DialogResult.Yes) { 
                    foreach (Control ctrl in Form.ActiveForm.Controls)
                    {
                        ctrl.Dispose();
                    }
                    Form.ActiveForm.Controls.Add(new UserControl1());
                };
            }
            else
            {
                foreach (Control ctrl in Form.ActiveForm.Controls)
                {
                    ctrl.Dispose();
                }
                Form.ActiveForm.Controls.Add(new UserControl1());
            }

            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
