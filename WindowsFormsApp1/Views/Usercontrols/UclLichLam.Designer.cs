namespace BakeryManagementSystem.Views.Usercontrols
{
    partial class UclLichLam
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
            this.gbxLichLam = new DevExpress.XtraEditors.GroupControl();
            this.gctLichLam = new DevExpress.XtraGrid.GridControl();
            this.dgvDSPhanCong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTenNhanVien = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTenChucVu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gbxLichLam)).BeginInit();
            this.gbxLichLam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gctLichLam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPhanCong)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxLichLam
            // 
            this.gbxLichLam.Appearance.BackColor = System.Drawing.Color.Linen;
            this.gbxLichLam.Appearance.BackColor2 = System.Drawing.Color.Linen;
            this.gbxLichLam.Appearance.BorderColor = System.Drawing.Color.Transparent;
            this.gbxLichLam.Appearance.Options.UseBackColor = true;
            this.gbxLichLam.Appearance.Options.UseBorderColor = true;
            this.gbxLichLam.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxLichLam.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxLichLam.AppearanceCaption.Options.UseFont = true;
            this.gbxLichLam.AppearanceCaption.Options.UseForeColor = true;
            this.gbxLichLam.Controls.Add(this.gctLichLam);
            this.gbxLichLam.Location = new System.Drawing.Point(3, 152);
            this.gbxLichLam.Name = "gbxLichLam";
            this.gbxLichLam.Size = new System.Drawing.Size(1600, 843);
            this.gbxLichLam.TabIndex = 4;
            this.gbxLichLam.Text = "Lịch làm";
            // 
            // gctLichLam
            // 
            this.gctLichLam.Location = new System.Drawing.Point(0, 50);
            this.gctLichLam.MainView = this.dgvDSPhanCong;
            this.gctLichLam.Name = "gctLichLam";
            this.gctLichLam.Size = new System.Drawing.Size(1603, 793);
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
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1606, 68);
            this.label1.TabIndex = 5;
            this.label1.Text = "LỊCH LÀM VIỆC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(3, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 44);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tên nhân viên: ";
            // 
            // lblTenNhanVien
            // 
            this.lblTenNhanVien.AutoSize = true;
            this.lblTenNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lblTenNhanVien.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenNhanVien.ForeColor = System.Drawing.Color.Peru;
            this.lblTenNhanVien.Location = new System.Drawing.Point(255, 105);
            this.lblTenNhanVien.Name = "lblTenNhanVien";
            this.lblTenNhanVien.Size = new System.Drawing.Size(246, 44);
            this.lblTenNhanVien.TabIndex = 30;
            this.lblTenNhanVien.Text = "Tên nhân viên: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(666, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 44);
            this.label3.TabIndex = 31;
            this.label3.Text = "Chức vụ: ";
            // 
            // lblTenChucVu
            // 
            this.lblTenChucVu.AutoSize = true;
            this.lblTenChucVu.BackColor = System.Drawing.Color.Transparent;
            this.lblTenChucVu.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenChucVu.ForeColor = System.Drawing.Color.Peru;
            this.lblTenChucVu.Location = new System.Drawing.Point(831, 105);
            this.lblTenChucVu.Name = "lblTenChucVu";
            this.lblTenChucVu.Size = new System.Drawing.Size(246, 44);
            this.lblTenChucVu.TabIndex = 32;
            this.lblTenChucVu.Text = "Tên nhân viên: ";
            // 
            // UclLichLam
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTenChucVu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTenNhanVien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxLichLam);
            this.Name = "UclLichLam";
            this.Size = new System.Drawing.Size(1606, 998);
            this.Load += new System.EventHandler(this.UclLichLam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gbxLichLam)).EndInit();
            this.gbxLichLam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gctLichLam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPhanCong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbxLichLam;
        private DevExpress.XtraGrid.GridControl gctLichLam;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDSPhanCong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTenNhanVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTenChucVu;
    }
}
