
namespace reception_app
{
    partial class BackupPanel
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.backupDataView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backup_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.research_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.research_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backupSelector = new System.Windows.Forms.ComboBox();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.backupDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // backupDataView
            // 
            this.backupDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.backupDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.backup_date,
            this.research_date,
            this.research_name,
            this.name});
            this.backupDataView.Location = new System.Drawing.Point(40, 3);
            this.backupDataView.Name = "backupDataView";
            this.backupDataView.RowHeadersWidth = 51;
            this.backupDataView.RowTemplate.Height = 29;
            this.backupDataView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.backupDataView.Size = new System.Drawing.Size(574, 327);
            this.backupDataView.TabIndex = 0;
            this.backupDataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.backupDataView_CellContentClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // backup_date
            // 
            this.backup_date.HeaderText = "Data Backupu";
            this.backup_date.MinimumWidth = 6;
            this.backup_date.Name = "backup_date";
            this.backup_date.ReadOnly = true;
            this.backup_date.Width = 125;
            // 
            // research_date
            // 
            this.research_date.HeaderText = "Data Badania";
            this.research_date.MinimumWidth = 6;
            this.research_date.Name = "research_date";
            this.research_date.ReadOnly = true;
            this.research_date.Width = 125;
            // 
            // research_name
            // 
            this.research_name.HeaderText = "Nazwa Badania";
            this.research_name.MinimumWidth = 6;
            this.research_name.Name = "research_name";
            this.research_name.ReadOnly = true;
            this.research_name.Width = 125;
            // 
            // name
            // 
            this.name.HeaderText = "Dane Pacjenta";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // backupSelector
            // 
            this.backupSelector.FormattingEnabled = true;
            this.backupSelector.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.backupSelector.Location = new System.Drawing.Point(56, 373);
            this.backupSelector.Name = "backupSelector";
            this.backupSelector.Size = new System.Drawing.Size(151, 28);
            this.backupSelector.TabIndex = 1;
            this.backupSelector.SelectedIndexChanged += new System.EventHandler(this.backupSelector_SelectedIndexChanged);
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.Location = new System.Drawing.Point(318, 373);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(94, 29);
            this.SubmitBtn.TabIndex = 2;
            this.SubmitBtn.Text = "Submit";
            this.SubmitBtn.UseVisualStyleBackColor = true;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(520, 373);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // BackupPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.SubmitBtn);
            this.Controls.Add(this.backupSelector);
            this.Controls.Add(this.backupDataView);
            this.Name = "BackupPanel";
            this.Size = new System.Drawing.Size(673, 448);
            this.Load += new System.EventHandler(this.BackupPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.backupDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView backupDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn backup_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn research_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn research_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.ComboBox backupSelector;
        private System.Windows.Forms.Button SubmitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}
