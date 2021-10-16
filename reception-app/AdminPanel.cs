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
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;


            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"SELECT MAX(update_date) as update_date,research_date,research_name,name FROM Client GROUP BY research_date;";
            var read = sqlite_cmd.ExecuteReader();

            while (read.Read()) {
                //researchesSet.Columns["Item"].DataPropertyName = "Item";
                researchesSet.Rows.Add(new object[]
                {
                    //read.GetValue(0),
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
    }
}
