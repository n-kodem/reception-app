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
        public static string idToBackup = "";
        public AdminPanel()
        {    
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            submitBtn.Enabled = false;
            backupPanelBtn.Enabled = false;
            delBtn.Enabled = false;

            // Data setup
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;


            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();


            sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name FROM Client GROUP BY research_id;";
            var read = sqlite_cmd.ExecuteReader();

            while (read.Read()) {
                researchesSet.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_id")),
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });

            }

            sqlite_conn.Close();

            backupElementSelector.Items.Clear();
            for (var j = 0;j<researchesSet.Rows.Count;j+=1)
            {
                backupElementSelector.Items.Add($"{int.Parse(researchesSet.Rows[j].Cells[0].Value.ToString()) + 1}");
            }
        }

        private void researchesSet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            submitBtn.Enabled = false;

            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;
            Kolejka test_commands = new Kolejka(researchesSet.RowCount);

            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name FROM Client GROUP BY research_id;";
            var read = sqlite_cmd.ExecuteReader();


            // DB ROWS
            while (read.Read())
            {
                //Every Row
                for(var i = 0; i < researchesSet.RowCount; i += 1)
                {

                    // Comparing data if newest data is not like updated data | checking by research id from dataset
                    if (
                        (
                        researchesSet.Rows[i].Cells[1].Value.ToString() != read.GetValue(read.GetOrdinal("research_date")).ToString() ||
                        researchesSet.Rows[i].Cells[2].Value.ToString() != read.GetValue(read.GetOrdinal("research_name")).ToString() ||
                        researchesSet.Rows[i].Cells[3].Value.ToString() != read.GetValue(read.GetOrdinal("name")).ToString()
                        )
                        &&
                        researchesSet.Rows[i].Cells[0].Value.ToString() == read.GetValue(read.GetOrdinal("research_id")).ToString()
                        ) 
                    {



                        // Add changes to changelist
                        test_commands.push($"INSERT INTO " +
                            $"Client(update_date,research_id,research_date,research_name,name) " +
                            $"VALUES(DATETIME('now','+{i} seconds'),{researchesSet.Rows[i].Cells[0].Value},'{researchesSet.Rows[i].Cells[1].Value:yyyy-MM-dd HH:mm:ss}'," +
                            $"'{researchesSet.Rows[i].Cells[2].Value}','{researchesSet.Rows[i].Cells[3].Value}')");
                        

                    }
                    
                }
            }


            while (test_commands.empty())
            {
                sqlite_cmd.Reset();
                sqlite_cmd.CommandText = test_commands.front();
                if (sqlite_cmd.CommandText is null)
                    break;
                sqlite_cmd.ExecuteNonQuery();
                
                test_commands.usun();
            }

            sqlite_cmd.Reset();
            read.Close();
            sqlite_conn.Close();
            
            
            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            researchesSet.Rows.Clear();
            sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name FROM Client GROUP BY research_id;";
            read = sqlite_cmd.ExecuteReader();
            
            while (read.Read())
            {
                researchesSet.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_id")),
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });
            }

            sqlite_conn.Close();
            backupElementSelector.Items.Clear();
            for (var j = 0; j < researchesSet.Rows.Count; j += 1)
            {
                backupElementSelector.Items.Add($"{int.Parse(researchesSet.Rows[j].Cells[0].Value.ToString())+1}");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (submitBtn.Enabled)
            {
                var window = MessageBox.Show(
                    "You have unsubmitted data, are sure that you want to exit?",
                    "Close Window",
                    MessageBoxButtons.YesNo);

                if (window == DialogResult.Yes)
                {
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

        private void delBackupsBtn_Click(object sender, EventArgs e)
        {
            // Data setup
            SQLiteConnection sqlite_conn;
            SQLiteCommand sqlite_cmd;


            sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"DELETE FROM Client WHERE update_date NOT IN " +
                $"(SELECT MAX(update_date) FROM Client GROUP BY research_id);";

            sqlite_cmd.ExecuteNonQuery();

            sqlite_cmd.Reset();

            // RELOAD UI
            sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name " +
                $"FROM Client GROUP BY research_id;";
            var read = sqlite_cmd.ExecuteReader();

            researchesSet.Rows.Clear();

            while (read.Read())
            {
                researchesSet.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_id")),
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });
            }


            sqlite_conn.Close();
        }

        private void researchesSet_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            submitBtn.Enabled = true;
        }

        private void backupPanelBtn_Click(object sender, EventArgs e)
        {
            if (submitBtn.Enabled)
            {
                var window = MessageBox.Show(
                    "You have unsubmitted data, are sure that you want to exit?",
                    "Close Window",
                    MessageBoxButtons.YesNo);

                if (window == DialogResult.Yes)
                {
                    foreach (Control ctrl in Form.ActiveForm.Controls)
                    {
                        ctrl.Dispose();
                    }
                    Form.ActiveForm.Controls.Add(new BackupPanel());
                };
            }
            else
            {
                foreach (Control ctrl in Form.ActiveForm.Controls)
                {
                    ctrl.Dispose();
                }
                Form.ActiveForm.Controls.Add(new BackupPanel());
            }
        }

        private void backupElementSelector_SelectedItemChanged(object sender, EventArgs e)
        {
            idToBackup = (int.Parse(backupElementSelector.Text) - 1).ToString();
            backupPanelBtn.Enabled = true;
            delBtn.Enabled = true;
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            var window = MessageBox.Show(
            "Are you sure that you want to delete this research? This action cannot be undone.",
            "Warning!",
            MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            if(window == DialogResult.Yes)
            {
                SQLiteConnection sqlite_conn;
                SQLiteCommand sqlite_cmd;
                Kolejka test_commands = new Kolejka(researchesSet.RowCount);

                sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
                sqlite_conn.Open();
                sqlite_cmd = sqlite_conn.CreateCommand();

                sqlite_cmd.CommandText = $"DELETE FROM Client WHERE research_id = {idToBackup};";
                var read = sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.Reset();


                sqlite_cmd.CommandText = $"DELETE FROM Client WHERE update_date NOT IN " +
     $"(SELECT MAX(update_date) FROM Client GROUP BY research_id);";

                sqlite_cmd.ExecuteNonQuery();

                sqlite_cmd.Reset();

                // RELOAD UI
                sqlite_cmd.CommandText = $"SELECT MAX(update_date),research_id,research_date,research_name,name " +
                    $"FROM Client GROUP BY research_id;";
                var read2 = sqlite_cmd.ExecuteReader();

                researchesSet.Rows.Clear();

                while (read2.Read())
                {
                    researchesSet.Rows.Add(new object[]
                    {
                    read2.GetValue(read2.GetOrdinal("research_id")),
                    read2.GetValue(read2.GetOrdinal("research_date")),
                    read2.GetValue(read2.GetOrdinal("research_name")),
                    read2.GetValue(read2.GetOrdinal("name"))
                    });
                }


                sqlite_conn.Close();
            }


        }
    }
}
