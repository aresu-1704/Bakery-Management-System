namespace BakeryManagementSystem.Views.Forms
{
    partial class frmThongBao
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBao));
            this.btnCo = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhong = new DevExpress.XtraEditors.SimpleButton();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.lblNoiDung = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCo
            // 
            this.btnCo.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCo.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnCo.Appearance.Options.UseFont = true;
            this.btnCo.Appearance.Options.UseForeColor = true;
            this.btnCo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCo.ImageOptions.Image")));
            this.btnCo.Location = new System.Drawing.Point(77, 93);
            this.btnCo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCo.Name = "btnCo";
            this.btnCo.Size = new System.Drawing.Size(81, 24);
            this.btnCo.TabIndex = 1;
            this.btnCo.Text = "Có";
            this.btnCo.Click += new System.EventHandler(this.btnCo_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhong.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnKhong.Appearance.Options.UseFont = true;
            this.btnKhong.Appearance.Options.UseForeColor = true;
            this.btnKhong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKhong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhong.ImageOptions.Image")));
            this.btnKhong.Location = new System.Drawing.Point(163, 93);
            this.btnKhong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(81, 24);
            this.btnKhong.TabIndex = 0;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnOk
            // 
            this.btnOk.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Appearance.Options.UseForeColor = true;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Location = new System.Drawing.Point(68, 93);
            this.btnOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(107, 24);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoiDung.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblNoiDung.Location = new System.Drawing.Point(2, 16);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(249, 74);
            this.lblNoiDung.TabIndex = 2;
            this.lblNoiDung.Text = "Nội dung thông báo";
            this.lblNoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 126);
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnCo);
            this.IconOptions.Image = global::BakeryManagementSystem.Properties.Resources.Bakery_Icon;
            this.MaximizeBox = false;
            this.Name = "frmThongBao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông báo";
            this.Load += new System.EventHandler(this.frmThongBao_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnCo;
        private DevExpress.XtraEditors.SimpleButton btnKhong;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private System.Windows.Forms.Label lblNoiDung;
    }
}