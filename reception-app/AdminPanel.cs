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

namespace reception_app
{
    public partial class AdminPanel : UserControl
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // Data setup
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;


            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"SELECT MAX(update_date) as update_date,research_date,research_name,name FROM Client GROUP BY research_date;";
            var read = sqlite_cmd.ExecuteReader();

            while (read.Read()) {
                researchesSet.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });
            }

            sqlite_conn.Close();
        }

        private void researchesSet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            List<string> sql_commands = new List<string>();

            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"SELECT MAX(update_date) as update_date,research_date,research_name,name FROM Client GROUP BY research_date;";
            var read = sqlite_cmd.ExecuteReader();


            // DB ROWS
            while (read.Read())
            {
                //Every Row
                for(var i = 0; i < researchesSet.RowCount; i += 1)
                {
                    // Comparing data
                    if (researchesSet.Rows[i].Cells[0].Value.ToString() != read.GetValue(read.GetOrdinal("research_date")).ToString() ||
                        researchesSet.Rows[i].Cells[1].Value.ToString() != read.GetValue(read.GetOrdinal("research_name")).ToString() ||
                        researchesSet.Rows[i].Cells[2].Value.ToString() != read.GetValue(read.GetOrdinal("name")).ToString()
                        ) 
                    {

                        // Show changed DEV ONLY maybe change it to kind of submit
                        MessageBox.Show($"{researchesSet.Rows[i].Cells[0].Value} {read.GetValue(read.GetOrdinal("research_date"))}\n" +
                            $"{researchesSet.Rows[i].Cells[1].Value} {read.GetValue(read.GetOrdinal("research_name"))}\n" +
                            $"{researchesSet.Rows[i].Cells[2].Value} {read.GetValue(read.GetOrdinal("name"))}\n");

                        // Add changes to changelist
                        sql_commands.Add($"INSERT INTO " +
                            $"Client(update_date,research_date,research_name,name) " +
                            $"VALUES(DATETIME('now'),'{researchesSet.Rows[i].Cells[0].Value:yyyy-MM-dd HH:mm:ss}'," +
                            $"'{researchesSet.Rows[i].Cells[1].Value}','{researchesSet.Rows[i].Cells[2].Value}')");
                        

                    }
                    
                }
            }

            //Apply changes
            
            foreach (var item in sql_commands)
            {
                sqlite_cmd.Reset();
                sqlite_cmd.CommandText = item;
                sqlite_cmd.ExecuteNonQuery();
            }


            // RELOAD UI
            sqlite_cmd.CommandText = $"SELECT MAX(update_date) as update_date,research_date,research_name,name FROM Client GROUP BY research_date;";
            read = sqlite_cmd.ExecuteReader();

            researchesSet.Rows.Clear();

            while (read.Read())
            {
                researchesSet.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });
            }


            sqlite_conn.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in Form.ActiveForm.Controls)
            {
                ctrl.Dispose();
            }
            Form.ActiveForm.Controls.Add(new UserControl1());
        }
    }
}
