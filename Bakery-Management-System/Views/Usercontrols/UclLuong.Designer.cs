namespace BakeryManagementSystem.Views.Usercontrol
{
    partial class UclLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UclLuong));
            this.label1 = new System.Windows.Forms.Label();
            this.gbxChamCong = new DevExpress.XtraEditors.GroupControl();
            this.gctLichChamCong = new DevExpress.XtraGrid.GridControl();
            this.dgvLSChamCong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gctNhanVien = new DevExpress.XtraGrid.GridControl();
            this.dgvDanhSachNV = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoaGroupBox = new DevExpress.XtraEditors.SimpleButton();
            this.dptNgayBatDau = new DevExpress.XtraEditors.DateEdit();
            this.dptNgayKetThuc = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ckbTatCa = new DevExpress.XtraEditors.CheckEdit();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnTraLuong = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtTongLuong = new System.Windows.Forms.TextBox();
            this.ckbChuaTra = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxChamCong)).BeginInit();
            this.gbxChamCong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctLichChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSChamCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayBatDau.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayBatDau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayKetThuc.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayKetThuc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTatCa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbChuaTra.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1606, 68);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ PHÁT LƯƠNG\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbxChamCong
            // 
            this.gbxChamCong.Appearance.BackColor = System.Drawing.Color.Linen;
            this.gbxChamCong.Appearance.BackColor2 = System.Drawing.Color.Linen;
            this.gbxChamCong.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gbxChamCong.Appearance.Options.UseBackColor = true;
            this.gbxChamCong.Appearance.Options.UseBorderColor = true;
            this.gbxChamCong.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxChamCong.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxChamCong.AppearanceCaption.Options.UseFont = true;
            this.gbxChamCong.AppearanceCaption.Options.UseForeColor = true;
            this.gbxChamCong.Controls.Add(this.gctLichChamCong);
            this.gbxChamCong.Enabled = false;
            this.gbxChamCong.Location = new System.Drawing.Point(11, 103);
            this.gbxChamCong.Name = "gbxChamCong";
            this.gbxChamCong.Size = new System.Drawing.Size(781, 748);
            this.gbxChamCong.TabIndex = 3;
            this.gbxChamCong.Text = "Lịch sử chấm công";
            // 
            // gctLichChamCong
            // 
            this.gctLichChamCong.Location = new System.Drawing.Point(0, 25);
            this.gctLichChamCong.MainView = this.dgvLSChamCong;
            this.gctLichChamCong.Name = "gctLichChamCong";
            this.gctLichChamCong.Size = new System.Drawing.Size(781, 723);
            this.gctLichChamCong.TabIndex = 11;
            this.gctLichChamCong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvLSChamCong});
            // 
            // dgvLSChamCong
            // 
            this.dgvLSChamCong.Appearance.FocusedRow.BackColor = System.Drawing.Color.BurlyWood;
            this.dgvLSChamCong.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLSChamCong.Appearance.FocusedRow.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvLSChamCong.Appearance.FocusedRow.Options.UseBackColor = true;
            this.dgvLSChamCong.Appearance.FocusedRow.Options.UseFont = true;
            this.dgvLSChamCong.Appearance.FocusedRow.Options.UseForeColor = true;
            this.dgvLSChamCong.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLSChamCong.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvLSChamCong.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvLSChamCong.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.dgvLSChamCong.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLSChamCong.Appearance.Row.ForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvLSChamCong.Appearance.Row.Options.UseFont = true;
            this.dgvLSChamCong.Appearance.Row.Options.UseForeColor = true;
            this.dgvLSChamCong.GridControl = this.gctLichChamCong;
            this.dgvLSChamCong.GroupPanelText = "Thả cột vào đây để nhóm...";
            this.dgvLSChamCong.Name = "dgvLSChamCong";
            this.dgvLSChamCong.OptionsBehavior.AutoSelectAllInEditor = false;
            this.dgvLSChamCong.OptionsBehavior.Editable = false;
            this.dgvLSChamCong.OptionsBehavior.ReadOnly = true;
            this.dgvLSChamCong.OptionsFind.AllowFindPanel = false;
            this.dgvLSChamCong.OptionsFind.FindFilterColumns = "Tên chức vụ";
            this.dgvLSChamCong.OptionsFind.FindNullPrompt = "Tìm kiếm theo tên...";
            this.dgvLSChamCong.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dgvLSChamCong.OptionsSelection.EnableAppearanceHideSelection = false;
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
            // dptNgayBatDau
            // 
            this.dptNgayBatDau.EditValue = new System.DateTime(2024, 10, 1, 0, 0, 0, 0);
            this.dptNgayBatDau.Enabled = false;
            this.dptNgayBatDau.Location = new System.Drawing.Point(94, 857);
            this.dptNgayBatDau.Name = "dptNgayBatDau";
            this.dptNgayBatDau.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptNgayBatDau.Properties.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.dptNgayBatDau.Properties.Appearance.Options.UseFont = true;
            this.dptNgayBatDau.Properties.Appearance.Options.UseForeColor = true;
            this.dptNgayBatDau.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptNgayBatDau.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptNgayBatDau.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dptNgayBatDau.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dptNgayBatDau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptNgayBatDau.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dptNgayBatDau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptNgayBatDau.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dptNgayBatDau.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dptNgayBatDau.Size = new System.Drawing.Size(183, 30);
            this.dptNgayBatDau.TabIndex = 7;
            this.dptNgayBatDau.EditValueChanged += new System.EventHandler(this.dptNgayBatDau_EditValueChanged);
            // 
            // dptNgayKetThuc
            // 
            this.dptNgayKetThuc.EditValue = new System.DateTime(2024, 10, 2, 0, 0, 0, 0);
            this.dptNgayKetThuc.Enabled = false;
            this.dptNgayKetThuc.Location = new System.Drawing.Point(378, 857);
            this.dptNgayKetThuc.Name = "dptNgayKetThuc";
            this.dptNgayKetThuc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptNgayKetThuc.Properties.Appearance.ForeColor = System.Drawing.Color.Peru;
            this.dptNgayKetThuc.Properties.Appearance.Options.UseFont = true;
            this.dptNgayKetThuc.Properties.Appearance.Options.UseForeColor = true;
            this.dptNgayKetThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptNgayKetThuc.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dptNgayKetThuc.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.dptNgayKetThuc.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dptNgayKetThuc.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptNgayKetThuc.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dptNgayKetThuc.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dptNgayKetThuc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.dptNgayKetThuc.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dptNgayKetThuc.Size = new System.Drawing.Size(183, 30);
            this.dptNgayKetThuc.TabIndex = 8;
            this.dptNgayKetThuc.EditValueChanged += new System.EventHandler(this.dptNgayKetThuc_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(282, 860);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 23);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Đến ngày";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(11, 860);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(77, 23);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Từ ngày";
            // 
            // ckbTatCa
            // 
            this.ckbTatCa.Enabled = false;
            this.ckbTatCa.Location = new System.Drawing.Point(695, 858);
            this.ckbTatCa.Name = "ckbTatCa";
            this.ckbTatCa.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbTatCa.Properties.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ckbTatCa.Properties.Appearance.Options.UseFont = true;
            this.ckbTatCa.Properties.Appearance.Options.UseForeColor = true;
            this.ckbTatCa.Properties.Caption = "Tất cả";
            this.ckbTatCa.Size = new System.Drawing.Size(97, 29);
            this.ckbTatCa.TabIndex = 11;
            this.ckbTatCa.TabStop = false;
            this.ckbTatCa.CheckedChanged += new System.EventHandler(this.ckbTatCa_CheckedChanged);
            // 
            // btnThoat
            // 
            this.btnThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnThoat.Appearance.Options.UseFont = true;
            this.btnThoat.Appearance.Options.UseForeColor = true;
            this.btnThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(453, 942);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(339, 44);
            this.btnThoat.TabIndex = 12;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnTraLuong
            // 
            this.btnTraLuong.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraLuong.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnTraLuong.Appearance.Options.UseFont = true;
            this.btnTraLuong.Appearance.Options.UseForeColor = true;
            this.btnTraLuong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTraLuong.Enabled = false;
            this.btnTraLuong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraLuong.ImageOptions.Image")));
            this.btnTraLuong.Location = new System.Drawing.Point(453, 892);
            this.btnTraLuong.Name = "btnTraLuong";
            this.btnTraLuong.Size = new System.Drawing.Size(339, 44);
            this.btnTraLuong.TabIndex = 13;
            this.btnTraLuong.Text = "Tạo phiếu phát lương";
            this.btnTraLuong.Click += new System.EventHandler(this.btnTraLuong_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(11, 911);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(146, 25);
            this.labelControl3.TabIndex = 14;
            this.labelControl3.Text = "TỔNG LƯƠNG";
            // 
            // txtTongLuong
            // 
            this.txtTongLuong.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongLuong.ForeColor = System.Drawing.Color.SaddleBrown;
            this.txtTongLuong.Location = new System.Drawing.Point(11, 942);
            this.txtTongLuong.Name = "txtTongLuong";
            this.txtTongLuong.ReadOnly = true;
            this.txtTongLuong.Size = new System.Drawing.Size(404, 40);
            this.txtTongLuong.TabIndex = 15;
            this.txtTongLuong.TabStop = false;
            // 
            // ckbChuaTra
            // 
            this.ckbChuaTra.Enabled = false;
            this.ckbChuaTra.Location = new System.Drawing.Point(567, 858);
            this.ckbChuaTra.Name = "ckbChuaTra";
            this.ckbChuaTra.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbChuaTra.Properties.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.ckbChuaTra.Properties.Appearance.Options.UseFont = true;
            this.ckbChuaTra.Properties.Appearance.Options.UseForeColor = true;
            this.ckbChuaTra.Properties.Caption = "Chưa trả";
            this.ckbChuaTra.Size = new System.Drawing.Size(111, 29);
            this.ckbChuaTra.TabIndex = 16;
            this.ckbChuaTra.TabStop = false;
            this.ckbChuaTra.CheckedChanged += new System.EventHandler(this.ckbChuaTra_CheckedChanged);
            // 
            // UclLuong
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckbChuaTra);
            this.Controls.Add(this.txtTongLuong);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnTraLuong);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.ckbTatCa);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.dptNgayKetThuc);
            this.Controls.Add(this.dptNgayBatDau);
            this.Controls.Add(this.gctNhanVien);
            this.Controls.Add(this.gbxChamCong);
            this.Controls.Add(this.btnXoaGroupBox);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "UclLuong";
            this.Size = new System.Drawing.Size(1606, 998);
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxChamCong)).EndInit();
            this.gbxChamCong.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctLichChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSChamCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gctNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayBatDau.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayBatDau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayKetThuc.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dptNgayKetThuc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbTatCa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbChuaTra.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl gbxChamCong;
        private DevExpress.XtraGrid.GridControl gctNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDanhSachNV;
        private DevExpress.XtraEditors.SimpleButton btnXoaGroupBox;
        private DevExpress.XtraGrid.GridControl gctLichChamCong;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvLSChamCong;
        private DevExpress.XtraEditors.DateEdit dptNgayBatDau;
        private DevExpress.XtraEditors.DateEdit dptNgayKetThuc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckEdit ckbTatCa;
        private DevExpress.XtraEditors.SimpleButton btnThoat;
        private DevExpress.XtraEditors.SimpleButton btnTraLuong;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox txtTongLuong;
        private DevExpress.XtraEditors.CheckEdit ckbChuaTra;
    }
}
