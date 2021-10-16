
namespace reception_app
{
    partial class AdminPanel
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
            this.researchesSet = new System.Windows.Forms.DataGridView();
            this.data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.research_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submitBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.researchesSet)).BeginInit();
            this.SuspendLayout();
            // 
            // researchesSet
            // 
            this.researchesSet.AllowUserToAddRows = false;
            this.researchesSet.AllowUserToDeleteRows = false;
            this.researchesSet.AllowUserToResizeColumns = false;
            this.researchesSet.ColumnHeadersHeight = 50;
            this.researchesSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.data,
            this.research_name,
            this.patient});
            this.researchesSet.Location = new System.Drawing.Point(0, 0);
            this.researchesSet.Name = "researchesSet";
            this.researchesSet.RowHeadersWidth = 10;
            this.researchesSet.RowTemplate.Height = 29;
            this.researchesSet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.researchesSet.Size = new System.Drawing.Size(610, 315);
            this.researchesSet.TabIndex = 2;
            this.researchesSet.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.researchesSet_CellContentClick);
            // 
            // data
            // 
            this.data.HeaderText = "Data";
            this.data.MinimumWidth = 6;
            this.data.Name = "data";
            this.data.Width = 200;
            // 
            // research_name
            // 
            this.research_name.HeaderText = "Nazwa Badania";
            this.research_name.MinimumWidth = 6;
            this.research_name.Name = "research_name";
            this.research_name.Width = 200;
            // 
            // patient
            // 
            this.patient.HeaderText = "Dane Pacjenta";
            this.patient.MinimumWidth = 6;
            this.patient.Name = "patient";
            this.patient.Width = 200;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(48, 360);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(142, 71);
            this.submitBtn.TabIndex = 3;
            this.submitBtn.Text = "Submit changes";
            this.submitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(378, 360);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(142, 71);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.researchesSet);
            this.Name = "AdminPanel";
            this.Size = new System.Drawing.Size(711, 479);
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.researchesSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView researchesSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn data;
        private System.Windows.Forms.DataGridViewTextBoxColumn research_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn patient;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}
