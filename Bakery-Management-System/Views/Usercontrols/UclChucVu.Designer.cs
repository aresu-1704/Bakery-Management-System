namespace BakeryManagementSystem.Views.Usercontrol
{
    partial class UclChucVu
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
            this.label1 = new System.Windows.Forms.Label();
            this.gbxChucVu = new DevExpress.XtraEditors.GroupControl();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMucLuong = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenChucVu = new System.Windows.Forms.TextBox();
            this.gctChucVu = new DevExpress.XtraGrid.GridControl();
            this.dgvDanhSachCV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaGroupBox = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gbxChucVu)).BeginInit();
            this.gbxChucVu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachCV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1600, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ CHỨC VỤ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxChucVu
            // 
            this.gbxChucVu.Appearance.BackColor = System.Drawing.Color.Linen;
            this.gbxChucVu.Appearance.BackColor2 = System.Drawing.Color.Linen;
            this.gbxChucVu.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gbxChucVu.Appearance.Options.UseBackColor = true;
            this.gbxChucVu.Appearance.Options.UseBorderColor = true;
            this.gbxChucVu.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxChucVu.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxChucVu.AppearanceCaption.Options.UseFont = true;
            this.gbxChucVu.AppearanceCaption.Options.UseForeColor = true;
            this.gbxChucVu.Controls.Add(this.label2);
            this.gbxChucVu.Controls.Add(this.txtMucLuong);
            this.gbxChucVu.Controls.Add(this.label4);
            this.gbxChucVu.Controls.Add(this.txtTenChucVu);
            this.gbxChucVu.Enabled = false;
            this.gbxChucVu.Location = new System.Drawing.Point(213, 91);
            this.gbxChucVu.Name = "gbxChucVu";
            this.gbxChucVu.Size = new System.Drawing.Size(1178, 252);
            this.gbxChucVu.TabIndex = 3;
            this.gbxChucVu.Text = "Thông tin chức vụ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(106, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 39);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mức lương (VNĐ / 1 giờ )";
            // 
            // txtMucLuong
            // 
            this.txtMucLuong.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMucLuong.ForeColor = System.Drawing.Color.Peru;
            this.txtMucLuong.Location = new System.Drawing.Point(111, 178);
            this.txtMucLuong.Name = "txtMucLuong";
            this.txtMucLuong.Size = new System.Drawing.Size(962, 30);
            this.txtMucLuong.TabIndex = 8;
            this.txtMucLuong.TabStop = false;
            this.txtMucLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMucLuong_KeyDown);
            this.txtMucLuong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMucLuong_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(106, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên chức vụ";
            // 
            // txtTenChucVu
            // 
            this.txtTenChucVu.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenChucVu.ForeColor = System.Drawing.Color.Peru;
            this.txtTenChucVu.Location = new System.Drawing.Point(111, 88);
            this.txtTenChucVu.Name = "txtTenChucVu";
            this.txtTenChucVu.Size = new System.Drawing.Size(962, 30);
            this.txtTenChucVu.TabIndex = 6;
            this.txtTenChucVu.TabStop = false;
            this.txtTenChucVu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenChucVu_KeyDown);
            this.txtTenChucVu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTenChucVu_KeyPress);
            // 
            // gctChucVu
            // 
            this.gctChucVu.Location = new System.Drawing.Point(3, 397);
            this.gctChucVu.MainView = this.dgvDanhSachCV;
            this.gctChucVu.Name = "gctChucVu";
            this.gctChucVu.Size = new System.Drawing.Size(1600, 598);
            this.gctChucVu.TabIndex = 4;
            this.gctChucVu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDanhSachCV});
            // 
            // dgvDanhSachCV
            // 
            this.dgvDanhSachCV.Appearance.FocusedRow.BackColor = System.Drawing.Color.BurlyWood;
            this.dgvDanhSachCV.Appearance.FocusedRow.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDanhSachCV.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvDanhSachCV.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvDanhSachCV.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachCV.Appearance.Row.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDanhSachCV.Appearance.Row.Options.UseFont = true;
            this.dgvDanhSachCV.Appearance.Row.Options.UseForeColor = true;
            this.dgvDanhSachCV.GridControl = this.gctChucVu;
            this.dgvDanhSachCV.GroupPanelText = "Thả cột vào đây để nhóm...";
            this.dgvDanhSachCV.Name = "dgvDanhSachCV";
            this.dgvDanhSachCV.OptionsBehavior.AutoSelectAllInEditor = false;
            this.dgvDanhSachCV.OptionsBehavior.Editable = false;
            this.dgvDanhSachCV.OptionsBehavior.ReadOnly = true;
            this.dgvDanhSachCV.OptionsFind.FindFilterColumns = "TenCV";
            this.dgvDanhSachCV.OptionsFind.FindNullPrompt = "Tìm kiếm theo tên...";
            this.dgvDanhSachCV.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvDanhSachCV.OptionsSelection.EnableAppearanceHideSelection = false;
            this.dgvDanhSachCV.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvDanhSachCV_RowClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Enabled = false;
            this.btnXoa.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.trash_32x32;
            this.btnXoa.Location = new System.Drawing.Point(450, 349);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(231, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Enabled = false;
            this.btnLuu.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.save_32x32;
            this.btnLuu.Location = new System.Drawing.Point(924, 349);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(231, 42);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.add_32x32;
            this.btnThem.Location = new System.Drawing.Point(687, 349);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(231, 42);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Appearance.Options.UseForeColor = true;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Enabled = false;
            this.btnSua.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.editname_32x32;
            this.btnSua.Location = new System.Drawing.Point(213, 349);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(231, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.cancel_32x321;
            this.btnThoat.Location = new System.Drawing.Point(1161, 349);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(231, 42);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoaGroupBox
            // 
            this.btnXoaGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaGroupBox.Enabled = false;
            this.btnXoaGroupBox.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.close_32x32;
            this.btnXoaGroupBox.Location = new System.Drawing.Point(1397, 91);
            this.btnXoaGroupBox.Name = "btnXoaGroupBox";
            this.btnXoaGroupBox.Size = new System.Drawing.Size(41, 42);
            this.btnXoaGroupBox.TabIndex = 6;
            this.btnXoaGroupBox.TabStop = false;
            this.btnXoaGroupBox.Click += new System.EventHandler(this.btnXoaGroupBox_Click);
            // 
            // UclChucVu
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnXoaGroupBox);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.gctChucVu);
            this.Controls.Add(this.gbxChucVu);
            this.Controls.Add(this.label1);
            this.Name = "UclChucVu";
            this.Size = new System.Drawing.Size(1606, 998);
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxChucVu)).EndInit();
            this.gbxChucVu.ResumeLayout(false);
            this.gbxChucVu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachCV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl gbxChucVu;
        private System.Windows.Forms.TextBox txtTenChucVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMucLuong;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gctChucVu;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDanhSachCV;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoaGroupBox;
    }
}
