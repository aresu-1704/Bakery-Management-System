namespace BakeryManagementSystem.Views.Forms
{
    partial class frmQuenMatKhau
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblThongBaoGuiLai = new System.Windows.Forms.Label();
            this.txtOTP = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.btnGuiOTP = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrDemNguocGuiOTP = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.Controls.Add(this.lblThongBaoGuiLai);
            this.panel1.Controls.Add(this.txtOTP);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.lblThoiGian);
            this.panel1.Controls.Add(this.btnGuiOTP);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(212, 88);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 284);
            this.panel1.TabIndex = 1;
            // 
            // lblThongBaoGuiLai
            // 
            this.lblThongBaoGuiLai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBaoGuiLai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblThongBaoGuiLai.Location = new System.Drawing.Point(261, 220);
            this.lblThongBaoGuiLai.Name = "lblThongBaoGuiLai";
            this.lblThongBaoGuiLai.Size = new System.Drawing.Size(117, 18);
            this.lblThongBaoGuiLai.TabIndex = 16;
            this.lblThongBaoGuiLai.Text = "Gửi lại OTP sau";
            this.lblThongBaoGuiLai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblThongBaoGuiLai.Visible = false;
            // 
            // txtOTP
            // 
            this.txtOTP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOTP.ForeColor = System.Drawing.Color.Peru;
            this.txtOTP.Location = new System.Drawing.Point(61, 191);
            this.txtOTP.Name = "txtOTP";
            this.txtOTP.Size = new System.Drawing.Size(194, 26);
            this.txtOTP.TabIndex = 15;
            this.txtOTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOTP_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(111, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 31);
            this.label4.TabIndex = 14;
            this.label4.Text = "QUÊN MẬT KHẨU";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Peru;
            this.txtEmail.Location = new System.Drawing.Point(61, 154);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(317, 26);
            this.txtEmail.TabIndex = 1;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblThoiGian.Location = new System.Drawing.Point(3, 383);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(427, 17);
            this.lblThoiGian.TabIndex = 13;
            this.lblThoiGian.Text = "label4";
            this.lblThoiGian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGuiOTP
            // 
            this.btnGuiOTP.BackColor = System.Drawing.Color.SandyBrown;
            this.btnGuiOTP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiOTP.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnGuiOTP.FlatAppearance.BorderSize = 0;
            this.btnGuiOTP.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btnGuiOTP.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btnGuiOTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuiOTP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiOTP.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnGuiOTP.Location = new System.Drawing.Point(261, 191);
            this.btnGuiOTP.Name = "btnGuiOTP";
            this.btnGuiOTP.Size = new System.Drawing.Size(117, 26);
            this.btnGuiOTP.TabIndex = 3;
            this.btnGuiOTP.Text = "Gửi OTP";
            this.btnGuiOTP.UseVisualStyleBackColor = false;
            this.btnGuiOTP.Click += new System.EventHandler(this.btnGuiOTP_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Forte", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = global::BakeryManagementSystem.Properties.Resources.Bakery_Icon;
            this.label3.Location = new System.Drawing.Point(171, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 92);
            this.label3.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(58, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nhập địa chỉ Email";
            // 
            // tmrDemNguocGuiOTP
            // 
            this.tmrDemNguocGuiOTP.Interval = 1000;
            this.tmrDemNguocGuiOTP.Tick += new System.EventHandler(this.tmrDemNguocGuiOTP_Tick);
            // 
            // frmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::BakeryManagementSystem.Properties.Resources.Background;
            this.ClientSize = new System.Drawing.Size(860, 485);
            this.Controls.Add(this.panel1);
            this.IconOptions.Image = global::BakeryManagementSystem.Properties.Resources.Bakery_Icon;
            this.MaximizeBox = false;
            this.Name = "frmQuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quên mật khẩu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuenMatKhau_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Button btnGuiOTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOTP;
        private System.Windows.Forms.Timer tmrDemNguocGuiOTP;
        private System.Windows.Forms.Label lblThongBaoGuiLai;
    }
}