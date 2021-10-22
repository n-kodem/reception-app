using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reception_app
{
    public partial class BackupPanel : UserControl
    {
        public BackupPanel()
        {
            InitializeComponent();
        }

        private void backupDataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BackupPanel_Load(object sender, EventArgs e)
        {
            SubmitBtn.Enabled = false;
            backupSelector.DropDownStyle = ComboBoxStyle.DropDownList;

            var sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            var sqlite_cmd = sqlite_conn.CreateCommand();

            backupDataView.Rows.Clear();
            sqlite_cmd.CommandText = $"SELECT update_date, research_id, research_date, research_name, name FROM Client WHERE research_id = {AdminPanel.idToBackup} ORDER BY update_date DESC;";
            var read = sqlite_cmd.ExecuteReader();

            while (read.Read())
            {
                backupDataView.Rows.Add(new object[]
                {
                    read.GetValue(read.GetOrdinal("research_id")),
                    read.GetValue(read.GetOrdinal("update_date")),
                    read.GetValue(read.GetOrdinal("research_date")),
                    read.GetValue(read.GetOrdinal("research_name")),
                    read.GetValue(read.GetOrdinal("name"))
                });
            }

            sqlite_conn.Close();

            for (int j = 0; j < backupDataView.Rows.Count-1; j += 1)
            {
                backupSelector.Items.Add(backupDataView.Rows[j].Cells[1].Value);
            }
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            var sqlite_conn = new SQLiteConnection("DataSource=reception.db;Version=3;");
            sqlite_conn.Open();
            var sqlite_cmd = sqlite_conn.CreateCommand();

            sqlite_cmd.CommandText = $"INSERT INTO " +
                            $"Client(update_date,research_id,research_date,research_name,name) " +
                            $"VALUES(DATETIME('now'),{AdminPanel.idToBackup},'{backupDataView.Rows[(int)backupSelector.SelectedIndex].Cells[2].Value:yyyy-MM-dd HH:mm:ss}'," +
                            $"'{backupDataView.Rows[(int)backupSelector.SelectedIndex].Cells[3].Value}'," +
                            $"'{backupDataView.Rows[(int)backupSelector.SelectedIndex].Cells[4].Value}')";
            var read = sqlite_cmd.ExecuteNonQuery();

            

            sqlite_conn.Close();
            MessageBox.Show("Submitted");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (SubmitBtn.Enabled)
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
                    Form.ActiveForm.Controls.Add(new AdminPanel());
                };
            }
            else
            {
                foreach (Control ctrl in Form.ActiveForm.Controls)
                {
                    ctrl.Dispose();
                }
                Form.ActiveForm.Controls.Add(new AdminPanel());
            }
        }

        private void backupSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubmitBtn.Enabled = true;
        }
    }
}
