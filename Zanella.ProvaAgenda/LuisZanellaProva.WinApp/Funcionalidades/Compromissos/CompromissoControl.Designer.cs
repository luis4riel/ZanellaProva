namespace LuisZanellaProva.WinApp.Funcionalidades.Compromissos
{
    partial class CompromissoControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxCompromisso = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxCompromisso
            // 
            this.listBoxCompromisso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCompromisso.FormattingEnabled = true;
            this.listBoxCompromisso.Location = new System.Drawing.Point(0, 0);
            this.listBoxCompromisso.Name = "listBoxCompromisso";
            this.listBoxCompromisso.Size = new System.Drawing.Size(150, 150);
            this.listBoxCompromisso.TabIndex = 0;
            // 
            // CompromissoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBoxCompromisso);
            this.Name = "CompromissoControl";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCompromisso;
    }
}
