
namespace reception_app
{
    partial class ResCreator
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
            this.components = new System.ComponentModel.Container();
            this.nameInp = new System.Windows.Forms.TextBox();
            this.researchInp = new System.Windows.Forms.TextBox();
            this.dateInp = new System.Windows.Forms.DateTimePicker();
            this.submitBtn = new System.Windows.Forms.Button();
            this.dayShower = new System.Windows.Forms.Label();
            this.tenMinTimer = new System.Windows.Forms.Timer(this.components);
            this.hourLab = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameInp
            // 
            this.nameInp.Location = new System.Drawing.Point(56, 54);
            this.nameInp.Name = "nameInp";
            this.nameInp.Size = new System.Drawing.Size(277, 27);
            this.nameInp.TabIndex = 0;
            // 
            // researchInp
            // 
            this.researchInp.Location = new System.Drawing.Point(56, 110);
            this.researchInp.Name = "researchInp";
            this.researchInp.Size = new System.Drawing.Size(277, 27);
            this.researchInp.TabIndex = 1;
            // 
            // dateInp
            // 
            this.dateInp.Location = new System.Drawing.Point(56, 166);
            this.dateInp.Name = "dateInp";
            this.dateInp.Size = new System.Drawing.Size(277, 27);
            this.dateInp.TabIndex = 5;
            // 
            // submitBtn
            // 
            this.submitBtn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.submitBtn.Location = new System.Drawing.Point(259, 353);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(139, 59);
            this.submitBtn.TabIndex = 6;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // dayShower
            // 
            this.dayShower.Location = new System.Drawing.Point(259, 248);
            this.dayShower.Name = "dayShower";
            this.dayShower.Size = new System.Drawing.Size(196, 22);
            this.dayShower.TabIndex = 7;
            this.dayShower.Text = "Today is:";
            // 
            // tenMinTimer
            // 
            this.tenMinTimer.Interval = 60000;
            this.tenMinTimer.Tick += new System.EventHandler(this.tenMinTimer_Tick);
            // 
            // hourLab
            // 
            this.hourLab.Location = new System.Drawing.Point(259, 283);
            this.hourLab.Name = "hourLab";
            this.hourLab.Size = new System.Drawing.Size(196, 25);
            this.hourLab.TabIndex = 8;
            this.hourLab.Text = "Time:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cancelBtn.Location = new System.Drawing.Point(44, 353);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(137, 59);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ResCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.hourLab);
            this.Controls.Add(this.dayShower);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.dateInp);
            this.Controls.Add(this.researchInp);
            this.Controls.Add(this.nameInp);
            this.Name = "ResCreator";
            this.Size = new System.Drawing.Size(458, 448);
            this.Load += new System.EventHandler(this.ResCreator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        

        #endregion
        private System.Windows.Forms.TextBox nameInp;
        private System.Windows.Forms.TextBox researchInp;
        private System.Windows.Forms.DateTimePicker dateInp;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.Label dayShower;
        private System.Windows.Forms.Timer tenMinTimer;
        private System.Windows.Forms.Label hourLab;
        private System.Windows.Forms.Button cancelBtn;
    }
}
