namespace BakeryManagementSystem.Views.Usercontrols
{
    partial class UclQuanLyTaiKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLichPhanCong = new System.Windows.Forms.DataGridView();
            this.gbxHoaDon = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label2 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichPhanCong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHoaDon)).BeginInit();
            this.gbxHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1606, 68);
            this.label1.TabIndex = 5;
            this.label1.Text = "QUẢN LÝ TÀI KHOẢN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvLichPhanCong
            // 
            this.dgvLichPhanCong.AllowUserToAddRows = false;
            this.dgvLichPhanCong.AllowUserToDeleteRows = false;
            this.dgvLichPhanCong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichPhanCong.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLichPhanCong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLichPhanCong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLichPhanCong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column8,
            this.Column10,
            this.Column11});
            this.dgvLichPhanCong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvLichPhanCong.EnableHeadersVisualStyles = false;
            this.dgvLichPhanCong.GridColor = System.Drawing.Color.SaddleBrown;
            this.dgvLichPhanCong.Location = new System.Drawing.Point(0, 32);
            this.dgvLichPhanCong.MultiSelect = false;
            this.dgvLichPhanCong.Name = "dgvLichPhanCong";
            this.dgvLichPhanCong.ReadOnly = true;
            this.dgvLichPhanCong.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvLichPhanCong.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLichPhanCong.RowTemplate.Height = 50;
            this.dgvLichPhanCong.RowTemplate.ReadOnly = true;
            this.dgvLichPhanCong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichPhanCong.Size = new System.Drawing.Size(1600, 882);
            this.dgvLichPhanCong.TabIndex = 1;
            this.dgvLichPhanCong.TabStop = false;
            this.dgvLichPhanCong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLichPhanCong_CellClick);
            this.dgvLichPhanCong.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichPhanCong_CellMouseMove);
            // 
            // gbxHoaDon
            // 
            this.gbxHoaDon.AppearanceCaption.BorderColor = System.Drawing.Color.Transparent;
            this.gbxHoaDon.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxHoaDon.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxHoaDon.AppearanceCaption.Options.UseBorderColor = true;
            this.gbxHoaDon.AppearanceCaption.Options.UseFont = true;
            this.gbxHoaDon.AppearanceCaption.Options.UseForeColor = true;
            this.gbxHoaDon.Controls.Add(this.dgvLichPhanCong);
            this.gbxHoaDon.Location = new System.Drawing.Point(3, 120);
            this.gbxHoaDon.Name = "gbxHoaDon";
            this.gbxHoaDon.Size = new System.Drawing.Size(1600, 875);
            this.gbxHoaDon.TabIndex = 6;
            this.gbxHoaDon.Text = "Danh sách điểm danh";
            // 
            // labelControl2
            // 
            this.labelControl2.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.icons8_lock_32;
            this.labelControl2.Location = new System.Drawing.Point(3, 87);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 32);
            this.labelControl2.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(31, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 26);
            this.label2.TabIndex = 15;
            this.label2.Text = "Đang bị khóa";
            // 
            // labelControl1
            // 
            this.labelControl1.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.icons8_unlock_32;
            this.labelControl1.Location = new System.Drawing.Point(171, 87);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 32);
            this.labelControl1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(199, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 26);
            this.label3.TabIndex = 13;
            this.label3.Text = "Đang hoạt động";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 50F;
            this.dataGridViewImageColumn1.HeaderText = "Điểm danh";
            this.dataGridViewImageColumn1.Image = global::BakeryManagementSystem.Properties.Resources.icons8_check_dollar_48;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Width = 133;
            // 
            // Column7
            // 
            this.Column7.FillWeight = 150F;
            this.Column7.HeaderText = "Nhân viên";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Tên đăng nhập";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Trạng thái tài khoản";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column11
            // 
            this.Column11.FillWeight = 50F;
            this.Column11.HeaderText = "Mở khóa/Khóa";
            this.Column11.Image = global::BakeryManagementSystem.Properties.Resources.icons8_account_48;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // UclQuanLyTaiKhoan
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.gbxHoaDon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label3);
            this.Name = "UclQuanLyTaiKhoan";
            this.Size = new System.Drawing.Size(1606, 998);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichPhanCong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHoaDon)).EndInit();
            this.gbxHoaDon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLichPhanCong;
        private DevExpress.XtraEditors.GroupControl gbxHoaDon;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewImageColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Column11;
    }
}
