namespace BakeryManagementSystem.Views.Usercontrols
{
    partial class UclNutChonKe
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
            this.btnKe = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnKe
            // 
            this.btnKe.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKe.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnKe.Appearance.Options.UseFont = true;
            this.btnKe.Appearance.Options.UseForeColor = true;
            this.btnKe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKe.Location = new System.Drawing.Point(-2, -2);
            this.btnKe.Name = "btnKe";
            this.btnKe.Size = new System.Drawing.Size(214, 131);
            this.btnKe.TabIndex = 0;
            this.btnKe.Text = "Kệ";
            this.btnKe.Click += new System.EventHandler(this.btnBan_CheckedChanged);
            // 
            // UclNutChonKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.btnKe);
            this.Name = "UclNutChonKe";
            this.Size = new System.Drawing.Size(210, 127);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnKe;
    }
}
