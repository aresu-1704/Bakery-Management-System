namespace BakeryManagementSystem.Views.Usercontrol
{
    partial class UclPhanCong
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
            this.gbxLichLam = new DevExpress.XtraEditors.GroupControl();
            this.gctLichLam = new DevExpress.XtraGrid.GridControl();
            this.dgvDSPhanCong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.gctNhanVien = new DevExpress.XtraGrid.GridControl();
            this.dgvDanhSachNV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnThem = new DevExpress.XtraEditors.SimpleButton();
            this.btnSua = new DevExpress.XtraEditors.SimpleButton();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaGroupBox = new DevExpress.XtraEditors.SimpleButton();
            this.gbxPhanCong = new DevExpress.XtraEditors.GroupControl();
            this.tedGioTanCa = new DevExpress.XtraEditors.TimeEdit();
            this.tedGioVaoCa = new DevExpress.XtraEditors.TimeEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNgayLam = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxLichLam)).BeginInit();
            this.gbxLichLam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctLichLam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxPhanCong)).BeginInit();
            this.gbxPhanCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tedGioTanCa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedGioVaoCa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNgayLam.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(0, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1606, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHÂN CÔNG CÔNG VIỆC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxLichLam
            // 
            this.gbxLichLam.Appearance.BackColor = System.Drawing.Color.Linen;
            this.gbxLichLam.Appearance.BackColor2 = System.Drawing.Color.Linen;
            this.gbxLichLam.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gbxLichLam.Appearance.Options.UseBackColor = true;
            this.gbxLichLam.Appearance.Options.UseBorderColor = true;
            this.gbxLichLam.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLichLam.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxLichLam.AppearanceCaption.Options.UseFont = true;
            this.gbxLichLam.AppearanceCaption.Options.UseForeColor = true;
            this.gbxLichLam.Controls.Add(this.gctLichLam);
            this.gbxLichLam.Enabled = false;
            this.gbxLichLam.Location = new System.Drawing.Point(11, 412);
            this.gbxLichLam.Name = "gbxLichLam";
            this.gbxLichLam.Size = new System.Drawing.Size(781, 535);
            this.gbxLichLam.TabIndex = 3;
            this.gbxLichLam.Text = "Lịch làm";
            // 
            // gctLichLam
            // 
            this.gctLichLam.Location = new System.Drawing.Point(0, 25);
            this.gctLichLam.MainView = this.dgvDSPhanCong;
            this.gctLichLam.Name = "gctLichLam";
            this.gctLichLam.Size = new System.Drawing.Size(781, 510);
            this.gctLichLam.TabIndex = 11;
            this.gctLichLam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDSPhanCong});
            // 
            // dgvDSPhanCong
            // 
            this.dgvDSPhanCong.Appearance.FocusedRow.BackColor = System.Drawing.Color.BurlyWood;
            this.dgvDSPhanCong.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSPhanCong.Appearance.FocusedRow.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDSPhanCong.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvDSPhanCong.Appearance.FocusedRow.Options.UseFont = true;
            this.dgvDSPhanCong.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvDSPhanCong.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSPhanCong.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDSPhanCong.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvDSPhanCong.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgvDSPhanCong.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDSPhanCong.Appearance.Row.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDSPhanCong.Appearance.Row.Options.UseFont = true;
            this.dgvDSPhanCong.Appearance.Row.Options.UseForeColor = true;
            this.dgvDSPhanCong.GridControl = this.gctLichLam;
            this.dgvDSPhanCong.GroupPanelText = "Thả cột vào đây để nhóm...";
            this.dgvDSPhanCong.Name = "dgvDSPhanCong";
            this.dgvDSPhanCong.OptionsBehavior.AutoSelectAllInEditor = false;
            this.dgvDSPhanCong.OptionsBehavior.Editable = false;
            this.dgvDSPhanCong.OptionsBehavior.ReadOnly = true;
            this.dgvDSPhanCong.OptionsFind.FindFilterColumns = "Thứ";
            this.dgvDSPhanCong.OptionsFind.FindNullPrompt = "Tìm kiếm theo thứ...";
            this.dgvDSPhanCong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvDSPhanCong.OptionsSelection.EnableAppearanceHideSelection = false;
            this.dgvDSPhanCong.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvDSPhanCong_RowClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label4.Location = new System.Drawing.Point(68, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 28);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tên nhân viên:";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Enabled = false;
            this.txtTenNV.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenNV.ForeColor = System.Drawing.Color.Peru;
            this.txtTenNV.Location = new System.Drawing.Point(73, 110);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(603, 30);
            this.txtTenNV.TabIndex = 6;
            this.txtTenNV.TabStop = false;
            // 
            // gctNhanVien
            // 
            this.gctNhanVien.Location = new System.Drawing.Point(798, 105);
            this.gctNhanVien.MainView = this.dgvDanhSachNV;
            this.gctNhanVien.Name = "gctNhanVien";
            this.gctNhanVien.Size = new System.Drawing.Size(805, 890);
            this.gctNhanVien.TabIndex = 4;
            this.gctNhanVien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDanhSachNV});
            // 
            // dgvDanhSachNV
            // 
            this.dgvDanhSachNV.Appearance.FocusedRow.BackColor = System.Drawing.Color.BurlyWood;
            this.dgvDanhSachNV.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachNV.Appearance.FocusedRow.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDanhSachNV.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvDanhSachNV.Appearance.FocusedRow.Options.UseFont = true;
            this.dgvDanhSachNV.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvDanhSachNV.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachNV.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDanhSachNV.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvDanhSachNV.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgvDanhSachNV.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDanhSachNV.Appearance.Row.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvDanhSachNV.Appearance.Row.Options.UseFont = true;
            this.dgvDanhSachNV.Appearance.Row.Options.UseForeColor = true;
            this.dgvDanhSachNV.GridControl = this.gctNhanVien;
            this.dgvDanhSachNV.GroupPanelText = "Thả cột vào đây để nhóm...";
            this.dgvDanhSachNV.Name = "dgvDanhSachNV";
            this.dgvDanhSachNV.OptionsBehavior.AutoSelectAllInEditor = false;
            this.dgvDanhSachNV.OptionsBehavior.Editable = false;
            this.dgvDanhSachNV.OptionsBehavior.ReadOnly = true;
            this.dgvDanhSachNV.OptionsFind.FindFilterColumns = "HoVaTen";
            this.dgvDanhSachNV.OptionsFind.FindNullPrompt = "Tìm kiếm theo tên...";
            this.dgvDanhSachNV.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvDanhSachNV.OptionsSelection.EnableAppearanceHideSelection = false;
            this.dgvDanhSachNV.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.dgvDanhSachCV_RowClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.Enabled = false;
            this.btnXoa.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.trash_32x32;
            this.btnXoa.Location = new System.Drawing.Point(166, 953);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(152, 42);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.Enabled = false;
            this.btnLuu.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.save_32x32;
            this.btnLuu.Location = new System.Drawing.Point(482, 953);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(152, 42);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThem
            // 
            this.btnThem.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThem.Appearance.Options.UseFont = true;
            this.btnThem.Appearance.Options.UseForeColor = true;
            this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThem.Enabled = false;
            this.btnThem.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.add_32x32;
            this.btnThem.Location = new System.Drawing.Point(324, 953);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(152, 42);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSua.Appearance.Options.UseFont = true;
            this.btnSua.Appearance.Options.UseForeColor = true;
            this.btnSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSua.Enabled = false;
            this.btnSua.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.editname_32x32;
            this.btnSua.Location = new System.Drawing.Point(11, 953);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(149, 42);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.cancel_32x321;
            this.btnThoat.Location = new System.Drawing.Point(640, 953);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(152, 42);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoaGroupBox
            // 
            this.btnXoaGroupBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaGroupBox.Enabled = false;
            this.btnXoaGroupBox.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.close_32x32;
            this.btnXoaGroupBox.Location = new System.Drawing.Point(11, 55);
            this.btnXoaGroupBox.Name = "btnXoaGroupBox";
            this.btnXoaGroupBox.Size = new System.Drawing.Size(41, 42);
            this.btnXoaGroupBox.TabIndex = 6;
            this.btnXoaGroupBox.TabStop = false;
            this.btnXoaGroupBox.Click += new System.EventHandler(this.btnXoaGroupBox_Click);
            // 
            // gbxPhanCong
            // 
            this.gbxPhanCong.Appearance.BackColor = System.Drawing.Color.Linen;
            this.gbxPhanCong.Appearance.BackColor2 = System.Drawing.Color.Linen;
            this.gbxPhanCong.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gbxPhanCong.Appearance.Options.UseBackColor = true;
            this.gbxPhanCong.Appearance.Options.UseBorderColor = true;
            this.gbxPhanCong.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPhanCong.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxPhanCong.AppearanceCaption.Options.UseFont = true;
            this.gbxPhanCong.AppearanceCaption.Options.UseForeColor = true;
            this.gbxPhanCong.Controls.Add(this.tedGioTanCa);
            this.gbxPhanCong.Controls.Add(this.tedGioVaoCa);
            this.gbxPhanCong.Controls.Add(this.label7);
            this.gbxPhanCong.Controls.Add(this.label6);
            this.gbxPhanCong.Controls.Add(this.label5);
            this.gbxPhanCong.Controls.Add(this.label3);
            this.gbxPhanCong.Controls.Add(this.cmbNgayLam);
            this.gbxPhanCong.Controls.Add(this.label4);
            this.gbxPhanCong.Controls.Add(this.txtTenNV);
            this.gbxPhanCong.Enabled = false;
            this.gbxPhanCong.Location = new System.Drawing.Point(11, 103);
            this.gbxPhanCong.Name = "gbxPhanCong";
            this.gbxPhanCong.Size = new System.Drawing.Size(781, 303);
            this.gbxPhanCong.TabIndex = 10;
            this.gbxPhanCong.Text = "Phân công";
            // 
            // tedGioTanCa
            // 
            this.tedGioTanCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tedGioTanCa.EditValue = new System.DateTime(2024, 10, 21, 0, 0, 0, 0);
            this.tedGioTanCa.Location = new System.Drawing.Point(521, 205);
            this.tedGioTanCa.Name = "tedGioTanCa";
            this.tedGioTanCa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tedGioTanCa.Properties.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.tedGioTanCa.Properties.Appearance.Options.UseFont = true;
            this.tedGioTanCa.Properties.Appearance.Options.UseForeColor = true;
            this.tedGioTanCa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tedGioTanCa.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.tedGioTanCa.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedGioTanCa.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.tedGioTanCa.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedGioTanCa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tedGioTanCa.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.tedGioTanCa.Size = new System.Drawing.Size(155, 30);
            this.tedGioTanCa.TabIndex = 18;
            // 
            // tedGioVaoCa
            // 
            this.tedGioVaoCa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tedGioVaoCa.EditValue = new System.DateTime(2024, 10, 21, 0, 0, 0, 0);
            this.tedGioVaoCa.Location = new System.Drawing.Point(328, 205);
            this.tedGioVaoCa.Name = "tedGioVaoCa";
            this.tedGioVaoCa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tedGioVaoCa.Properties.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.tedGioVaoCa.Properties.Appearance.Options.UseFont = true;
            this.tedGioVaoCa.Properties.Appearance.Options.UseForeColor = true;
            this.tedGioVaoCa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tedGioVaoCa.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.tedGioVaoCa.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedGioVaoCa.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.tedGioVaoCa.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.tedGioVaoCa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.tedGioVaoCa.Properties.TimeEditStyle = DevExpress.XtraEditors.Repository.TimeEditStyle.TouchUI;
            this.tedGioVaoCa.Size = new System.Drawing.Size(155, 30);
            this.tedGioVaoCa.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label7.Location = new System.Drawing.Point(516, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 28);
            this.label7.TabIndex = 15;
            this.label7.Text = "Giờ tan ca";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(490, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label5.Location = new System.Drawing.Point(323, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 28);
            this.label5.TabIndex = 12;
            this.label5.Text = "Giờ vào ca";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(68, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "Ngày";
            // 
            // cmbNgayLam
            // 
            this.cmbNgayLam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbNgayLam.Location = new System.Drawing.Point(73, 205);
            this.cmbNgayLam.Name = "cmbNgayLam";
            this.cmbNgayLam.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgayLam.Properties.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.cmbNgayLam.Properties.Appearance.Options.UseFont = true;
            this.cmbNgayLam.Properties.Appearance.Options.UseForeColor = true;
            this.cmbNgayLam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgayLam.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.Peru;
            this.cmbNgayLam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cmbNgayLam.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.cmbNgayLam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbNgayLam.Properties.Items.AddRange(new object[] {
            "Thứ 2",
            "Thứ 3",
            "Thứ 4",
            "Thứ 5",
            "Thứ 6",
            "Thứ 7",
            "Chủ nhật"});
            this.cmbNgayLam.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbNgayLam.Size = new System.Drawing.Size(155, 30);
            this.cmbNgayLam.TabIndex = 10;
            this.cmbNgayLam.TabStop = false;
            // 
            // UclLichLamViec
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxPhanCong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.gctNhanVien);
            this.Controls.Add(this.gbxLichLam);
            this.Controls.Add(this.btnXoaGroupBox);
            this.Controls.Add(this.label1);
            this.Name = "UclLichLamViec";
            this.Size = new System.Drawing.Size(1606, 998);
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxLichLam)).EndInit();
            this.gbxLichLam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctLichLam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxPhanCong)).EndInit();
            this.gbxPhanCong.ResumeLayout(false);
            this.gbxPhanCong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tedGioTanCa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tedGioVaoCa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNgayLam.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl gbxLichLam;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraGrid.GridControl gctNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDanhSachNV;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.SimpleButton btnSua;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnXoaGroupBox;
        private DevExpress.XtraEditors.GroupControl gbxPhanCong;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbNgayLam;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TimeEdit tedGioTanCa;
        private DevExpress.XtraEditors.TimeEdit tedGioVaoCa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraGrid.GridControl gctLichLam;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSPhanCong;
    }
}
