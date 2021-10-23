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
using System.Globalization;

namespace reception_app
{
    public partial class ResCreator : UserControl
    {
        public ResCreator()
        {
            InitializeComponent();
        }

        public bool isTableEmpty = false;
        private void ResCreator_Load(object sender, EventArgs e)
        {
            // Adding Hints to TextBoxes
            nameInp.Init("Patient name");
            researchInp.Init("Research name");

            //Gui setup
            submitBtn.Focus();
            dayShower.Text = "Today is: " + DateTime.Today;
            hourLab.Text = "Time: " + DateTime.Now.Hour + ":" + DateTime.Now.Minute;
            dateInp.CustomFormat = "dd.MM.yyyy HH:mm";
            dateInp.Value = DateTime.Now.Date;


            // Create DB if not exists ELSE uses already existing db
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            bool newdb = File.Exists("reception.db");
            if (newdb == true)
            {
                sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
                sqlite_conn.Open();

            }
            else
            {
                sqlite_conn = new SQLiteConnection("Data Source=reception.db;Version=3;New=True;Compress=True;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = $"CREATE TABLE IF NOT EXISTS Client (update_date TEXT PRIMARY KEY," +
                    $" research_id UNSIGNED iNT, research_date TEXT, research_name VARCHAR(100), name VARCHAR(100));";
                sqlite_cmd.ExecuteNonQuery();
                MessageBox.Show("DB created");
                sqlite_cmd.Reset();
            }


            // Data setup
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT COUNT(*) AS 'num' FROM Client";
            var read = sqlite_cmd.ExecuteReader();

            while (read.Read())
            {
                isTableEmpty = (System.Int64)read.GetValue(read.GetOrdinal("num"))==0;
            }
            read.Close();
            if (!isTableEmpty)
            {
                sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id as 'research_id',research_date,research_name,name,DATE('now') as today FROM Client where research_date>=DATE('now') GROUP BY research_id LIMIT 1;";
                read = sqlite_cmd.ExecuteReader();

                while (read.Read())
                {
                        
                    timeToNextRes.Text = "Next res: " + read.GetValue(read.GetOrdinal("research_date")).ToString();
                    if (read.GetValue(read.GetOrdinal("research_date")).ToString() is null)
                        timeToNextRes.Text = "Next res: none";
                    if (read.GetValue(read.GetOrdinal("research_date")).ToString().Substring(0, 10) == read.GetValue(read.GetOrdinal("today")).ToString())
                    {
                        timeToNextRes.ForeColor = Color.Red;
                    }
                }
                sqlite_cmd.Reset();
               


                
                sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name,DATE('now') as today FROM Client where research_date<DATE('now') GROUP BY research_id ORDER BY research_date DESC LIMIT 1;";
                read = sqlite_cmd.ExecuteReader();


                while (read.Read())
                {
                    lastResTime.Text = $"Last res Time: {read.GetValue(read.GetOrdinal("research_date"))}.";
                }

                sqlite_cmd.Reset();
            }
            else
            {
                lastResTime.Text = "Last res Time: none";
                timeToNextRes.Text = "Next res: none";
            }
            sqlite_conn.Close();
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
                    Form.ActiveForm.Controls.Add(new MainPanel());
                };
            }
            else
            {
                foreach (Control ctrl in Form.ActiveForm.Controls)
                {
                    ctrl.Dispose();
                }
                Form.ActiveForm.Controls.Add(new MainPanel());
            }

            
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;

            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"INSERT INTO " +
                $"Client(update_date,research_id,research_date,research_name,name) " +
                $"VALUES(DATETIME('now'),(SELECT IFNULL(MAX(research_id)+1,0) FROM Client)," +
                $"'{dateInp.Value:yyyy-MM-dd HH:mm:ss}','{researchInp.Text}','{nameInp.Text}')";

            sqlite_cmd.ExecuteNonQuery();
            sqlite_conn.Close();
            nameInp.Text = "";
            researchInp.Text = "";
            dateInp.Value = DateTime.Today;
            nameInp.Focus();
            researchInp.Focus();
            cancelBtn.Focus();
        }

        private void lastResTime_Click(object sender, EventArgs e)
        {

        }
    }
}
