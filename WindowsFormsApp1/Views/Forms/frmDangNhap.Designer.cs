using System.Resources;
namespace BakeryManagementSystem.Views.Forms
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pgpLoading = new DevExpress.XtraWaitForm.ProgressPanel();
            this.lblDangNhapThatBai = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.pgpDNThanhCong = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.lklQuenMK = new System.Windows.Forms.LinkLabel();
            this.ckcHienMK = new System.Windows.Forms.CheckBox();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.ckcGhiNho = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.thoiGian = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Linen;
            this.panel1.Controls.Add(this.pgpLoading);
            this.panel1.Controls.Add(this.lblDangNhapThatBai);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtTenDangNhap);
            this.panel1.Controls.Add(this.lblThoiGian);
            this.panel1.Controls.Add(this.pgpDNThanhCong);
            this.panel1.Controls.Add(this.btnDangKy);
            this.panel1.Controls.Add(this.txtMatKhau);
            this.panel1.Controls.Add(this.lklQuenMK);
            this.panel1.Controls.Add(this.ckcHienMK);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.ckcGhiNho);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(210, 33);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(433, 400);
            this.panel1.TabIndex = 0;
            // 
            // pgpLoading
            // 
            this.pgpLoading.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pgpLoading.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgpLoading.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.pgpLoading.Appearance.Options.UseBackColor = true;
            this.pgpLoading.Appearance.Options.UseFont = true;
            this.pgpLoading.Appearance.Options.UseForeColor = true;
            this.pgpLoading.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgpLoading.AppearanceCaption.ForeColor = System.Drawing.Color.Peru;
            this.pgpLoading.AppearanceCaption.Options.UseFont = true;
            this.pgpLoading.AppearanceCaption.Options.UseForeColor = true;
            this.pgpLoading.AppearanceDescription.ForeColor = System.Drawing.Color.Peru;
            this.pgpLoading.AppearanceDescription.Options.UseForeColor = true;
            this.pgpLoading.Caption = "Đăng nhập thành công";
            this.pgpLoading.Description = "Đang vào...";
            this.pgpLoading.Location = new System.Drawing.Point(27, 277);
            this.pgpLoading.Name = "pgpLoading";
            this.pgpLoading.Size = new System.Drawing.Size(31, 38);
            this.pgpLoading.TabIndex = 16;
            this.pgpLoading.Text = "pgpDangNhapThanhCong";
            this.pgpLoading.Visible = false;
            // 
            // lblDangNhapThatBai
            // 
            this.lblDangNhapThatBai.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangNhapThatBai.ForeColor = System.Drawing.Color.SaddleBrown;
            this.lblDangNhapThatBai.Location = new System.Drawing.Point(3, 318);
            this.lblDangNhapThatBai.Name = "lblDangNhapThatBai";
            this.lblDangNhapThatBai.Size = new System.Drawing.Size(427, 17);
            this.lblDangNhapThatBai.TabIndex = 15;
            this.lblDangNhapThatBai.Text = "label4";
            this.lblDangNhapThatBai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDangNhapThatBai.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sitka Small", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(146, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 31);
            this.label4.TabIndex = 14;
            this.label4.Text = "ĐĂNG NHẬP";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDangNhap.ForeColor = System.Drawing.Color.Peru;
            this.txtTenDangNhap.Location = new System.Drawing.Point(61, 147);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(317, 26);
            this.txtTenDangNhap.TabIndex = 1;
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
            // pgpDNThanhCong
            // 
            this.pgpDNThanhCong.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pgpDNThanhCong.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgpDNThanhCong.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.pgpDNThanhCong.Appearance.Options.UseBackColor = true;
            this.pgpDNThanhCong.Appearance.Options.UseFont = true;
            this.pgpDNThanhCong.Appearance.Options.UseForeColor = true;
            this.pgpDNThanhCong.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pgpDNThanhCong.AppearanceCaption.ForeColor = System.Drawing.Color.Peru;
            this.pgpDNThanhCong.AppearanceCaption.Options.UseFont = true;
            this.pgpDNThanhCong.AppearanceCaption.Options.UseForeColor = true;
            this.pgpDNThanhCong.AppearanceDescription.ForeColor = System.Drawing.Color.Peru;
            this.pgpDNThanhCong.AppearanceDescription.Options.UseForeColor = true;
            this.pgpDNThanhCong.Caption = "Đăng nhập thành công";
            this.pgpDNThanhCong.Description = "Đang vào...";
            this.pgpDNThanhCong.Location = new System.Drawing.Point(126, 348);
            this.pgpDNThanhCong.Name = "pgpDNThanhCong";
            this.pgpDNThanhCong.Size = new System.Drawing.Size(264, 38);
            this.pgpDNThanhCong.TabIndex = 12;
            this.pgpDNThanhCong.Text = "pgpDangNhapThanhCong";
            this.pgpDNThanhCong.Visible = false;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDangKy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangKy.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnDangKy.FlatAppearance.BorderSize = 0;
            this.btnDangKy.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btnDangKy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btnDangKy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangKy.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDangKy.Location = new System.Drawing.Point(234, 259);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(144, 34);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhau.ForeColor = System.Drawing.Color.Peru;
            this.txtMatKhau.Location = new System.Drawing.Point(61, 195);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(317, 26);
            this.txtMatKhau.TabIndex = 2;
            // 
            // lklQuenMK
            // 
            this.lklQuenMK.ActiveLinkColor = System.Drawing.Color.SandyBrown;
            this.lklQuenMK.AutoSize = true;
            this.lklQuenMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lklQuenMK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklQuenMK.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lklQuenMK.LinkColor = System.Drawing.Color.SaddleBrown;
            this.lklQuenMK.Location = new System.Drawing.Point(168, 296);
            this.lklQuenMK.Name = "lklQuenMK";
            this.lklQuenMK.Size = new System.Drawing.Size(102, 14);
            this.lklQuenMK.TabIndex = 10;
            this.lklQuenMK.TabStop = true;
            this.lklQuenMK.Text = "Quên mật khẩu ?";
            this.lklQuenMK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklQuenMK_LinkClicked);
            // 
            // ckcHienMK
            // 
            this.ckcHienMK.AutoSize = true;
            this.ckcHienMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckcHienMK.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcHienMK.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ckcHienMK.Location = new System.Drawing.Point(273, 225);
            this.ckcHienMK.Name = "ckcHienMK";
            this.ckcHienMK.Size = new System.Drawing.Size(105, 18);
            this.ckcHienMK.TabIndex = 9;
            this.ckcHienMK.TabStop = false;
            this.ckcHienMK.Text = "Hiện mật khẩu";
            this.ckcHienMK.UseVisualStyleBackColor = true;
            this.ckcHienMK.CheckedChanged += new System.EventHandler(this.ckbHienMK_CheckedChanged);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.SaddleBrown;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Peru;
            this.btnDangNhap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Peru;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDangNhap.Location = new System.Drawing.Point(61, 259);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(144, 34);
            this.btnDangNhap.TabIndex = 3;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // ckcGhiNho
            // 
            this.ckcGhiNho.AutoSize = true;
            this.ckcGhiNho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ckcGhiNho.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckcGhiNho.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ckcGhiNho.Location = new System.Drawing.Point(62, 225);
            this.ckcGhiNho.Name = "ckcGhiNho";
            this.ckcGhiNho.Size = new System.Drawing.Size(130, 18);
            this.ckcGhiNho.TabIndex = 3;
            this.ckcGhiNho.TabStop = false;
            this.ckcGhiNho.Text = "Ghi nhớ đăng nhập";
            this.ckcGhiNho.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Forte", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(175, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 92);
            this.label3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(58, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Mật khẩu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(58, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên đăng nhập";
            // 
            // thoiGian
            // 
            this.thoiGian.Enabled = true;
            this.thoiGian.Interval = 1000;
            this.thoiGian.Tick += new System.EventHandler(this.thoiGian_Tick);
            // 
            // frmDangNhap
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(854, 486);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmDangNhap.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "frmDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.Activated += new System.EventHandler(this.frmDangNhap_Activated);
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.CheckBox ckcGhiNho;
        private System.Windows.Forms.LinkLabel lklQuenMK;
        private System.Windows.Forms.CheckBox ckcHienMK;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Button btnDangKy;
        private DevExpress.XtraWaitForm.ProgressPanel pgpDNThanhCong;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Timer thoiGian;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDangNhapThatBai;
        private DevExpress.XtraWaitForm.ProgressPanel pgpLoading;
    }
}

