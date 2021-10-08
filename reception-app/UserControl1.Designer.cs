
namespace reception_app
{
    partial class UserControl1
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
            System.Windows.Forms.Button resCreator;
            this.adminPanel = new System.Windows.Forms.Button();
            resCreator = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resCreator
            // 
            resCreator.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            resCreator.Location = new System.Drawing.Point(74, 170);
            resCreator.Name = "resCreator";
            resCreator.Size = new System.Drawing.Size(203, 106);
            resCreator.TabIndex = 0;
            resCreator.Text = "Create reservation";
            resCreator.UseVisualStyleBackColor = true;
            resCreator.Click += new System.EventHandler(this.resCreator_Click);
            // 
            // adminPanel
            // 
            this.adminPanel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.adminPanel.Location = new System.Drawing.Point(361, 170);
            this.adminPanel.Name = "adminPanel";
            this.adminPanel.Size = new System.Drawing.Size(188, 106);
            this.adminPanel.TabIndex = 1;
            this.adminPanel.Text = "Panel";
            this.adminPanel.UseVisualStyleBackColor = true;
            this.adminPanel.Click += new System.EventHandler(this.adminPanel_Click);
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.adminPanel);
            this.Controls.Add(resCreator);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(641, 481);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button resCreator;
        private System.Windows.Forms.Button adminPanel;
    }
}
