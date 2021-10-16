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
            dateInp.CustomFormat = "yyyy.MM.dd HH:mm";
            dateInp.Value = DateTime.Now.Date;


            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            bool newdb = File.Exists("reception.db");
            if (newdb == true)
            {
                sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
                sqlite_conn.Open();
                MessageBox.Show("DB exist");
            }
            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=reception.db;Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"CREATE TABLE IF NOT EXISTS Client (update_date TEXT PRIMARY KEY, research_date TEXT, research_name VARCHAR(100), name VARCHAR(100));";
                sqlite_cmd.ExecuteNonQuery();
                MessageBox.Show("DB created");
            }

            sqlite_conn.Close();

            //sqlite_conn = new SQLiteConnection("Data Source=reception.db;Version=3;New=True;Compress=True;");
            //sqlite_conn.Open();
            //sqlite_cmd.CommandText = $"DROP TABLE Client;";
            //sqlite_cmd.ExecuteNonQuery();
        }
        private void tenMinTimer_Tick(object sender, EventArgs e)
        {
            hourLab.Text = "Time: "+ DateTime.Now.Hour+":"+DateTime.Now.Minute;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // BASIC DATA VALIDATION
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
            // TODO: DATA VALIDATION
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"INSERT INTO " +
                $"Client(update_date,research_date,research_name,name) " +
                $"VALUES(DATETIME('now'),'{dateInp.Value:yyyy-MM-dd HH:mm:ss}','{researchInp.Text}','{nameInp.Text}')";

            //MessageBox.Show(sqlite_cmd.CommandText);
            MessageBox.Show(sqlite_cmd.ExecuteNonQuery().ToString());

            sqlite_conn.Close();
        }
    }
}
