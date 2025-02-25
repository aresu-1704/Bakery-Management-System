namespace BakeryManagementSystem.Views.Usercontrols
{
    partial class UclNutChonBan
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
            this.btnBan = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnBan
            // 
            this.btnBan.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBan.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnBan.Appearance.Options.UseFont = true;
            this.btnBan.Appearance.Options.UseForeColor = true;
            this.btnBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBan.Location = new System.Drawing.Point(-2, -2);
            this.btnBan.Name = "btnBan";
            this.btnBan.Size = new System.Drawing.Size(214, 131);
            this.btnBan.TabIndex = 0;
            this.btnBan.Text = "Bàn ";
            this.btnBan.Click += new System.EventHandler(this.btnBan_CheckedChanged);
            // 
            // UclNutChonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnBan);
            this.Name = "UclNutChonBan";
            this.Size = new System.Drawing.Size(210, 127);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnBan;
    }
}
