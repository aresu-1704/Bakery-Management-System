namespace BakeryManagementSystem.Views.Usercontrols
{
    partial class UclBan
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
            this.gbxDSBan = new DevExpress.XtraEditors.GroupControl();
            this.flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxHoaDon = new DevExpress.XtraEditors.GroupControl();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoHD = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDonBan = new DevExpress.XtraEditors.SimpleButton();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gbxDSBan)).BeginInit();
            this.gbxDSBan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHoaDon)).BeginInit();
            this.gbxHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDSBan
            // 
            this.gbxDSBan.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDSBan.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxDSBan.AppearanceCaption.Options.UseFont = true;
            this.gbxDSBan.AppearanceCaption.Options.UseForeColor = true;
            this.gbxDSBan.Controls.Add(this.flpDanhSachBan);
            this.gbxDSBan.Location = new System.Drawing.Point(3, 33);
            this.gbxDSBan.Name = "gbxDSBan";
            this.gbxDSBan.Size = new System.Drawing.Size(899, 962);
            this.gbxDSBan.TabIndex = 3;
            this.gbxDSBan.Text = "Danh sách bàn";
            // 
            // flpDanhSachBan
            // 
            this.flpDanhSachBan.AutoScroll = true;
            this.flpDanhSachBan.Location = new System.Drawing.Point(5, 37);
            this.flpDanhSachBan.Name = "flpDanhSachBan";
            this.flpDanhSachBan.Size = new System.Drawing.Size(888, 920);
            this.flpDanhSachBan.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label3.Location = new System.Drawing.Point(204, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 26);
            this.label3.TabIndex = 9;
            this.label3.Text = "Đang trống";
            // 
            // labelControl1
            // 
            this.labelControl1.ImageOptions.SvgImage = global::BakeryManagementSystem.Properties.Resources.actions_checkcircled1;
            this.labelControl1.Location = new System.Drawing.Point(175, 1);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 32);
            this.labelControl1.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.ImageOptions.SvgImage = global::BakeryManagementSystem.Properties.Resources.actions_removecircled1;
            this.labelControl2.Location = new System.Drawing.Point(2, 1);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(32, 32);
            this.labelControl2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(31, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Đang phục vụ";
            // 
            // gbxHoaDon
            // 
            this.gbxHoaDon.AppearanceCaption.BorderColor = System.Drawing.Color.Transparent;
            this.gbxHoaDon.AppearanceCaption.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxHoaDon.AppearanceCaption.ForeColor = System.Drawing.Color.SaddleBrown;
            this.gbxHoaDon.AppearanceCaption.Options.UseBorderColor = true;
            this.gbxHoaDon.AppearanceCaption.Options.UseFont = true;
            this.gbxHoaDon.AppearanceCaption.Options.UseForeColor = true;
            this.gbxHoaDon.Controls.Add(this.dgvHoaDon);
            this.gbxHoaDon.Location = new System.Drawing.Point(908, 33);
            this.gbxHoaDon.Name = "gbxHoaDon";
            this.gbxHoaDon.Size = new System.Drawing.Size(695, 866);
            this.gbxHoaDon.TabIndex = 13;
            this.gbxHoaDon.Text = "Hóa đơn";
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.GridColor = System.Drawing.Color.SaddleBrown;
            this.dgvHoaDon.Location = new System.Drawing.Point(0, 32);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.PeachPuff;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.SaddleBrown;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.RowTemplate.Height = 30;
            this.dgvHoaDon.RowTemplate.ReadOnly = true;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(695, 834);
            this.dgvHoaDon.TabIndex = 1;
            this.dgvHoaDon.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label2.Location = new System.Drawing.Point(903, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 26);
            this.label2.TabIndex = 14;
            this.label2.Text = "Mã hóa đơn: ";
            // 
            // lblSoHD
            // 
            this.lblSoHD.AutoSize = true;
            this.lblSoHD.BackColor = System.Drawing.Color.Transparent;
            this.lblSoHD.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoHD.ForeColor = System.Drawing.Color.Peru;
            this.lblSoHD.Location = new System.Drawing.Point(1038, 4);
            this.lblSoHD.Name = "lblSoHD";
            this.lblSoHD.Size = new System.Drawing.Size(0, 26);
            this.lblSoHD.TabIndex = 15;
            // 
            // lblLoai
            // 
            this.lblLoai.AutoSize = true;
            this.lblLoai.BackColor = System.Drawing.Color.Transparent;
            this.lblLoai.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.ForeColor = System.Drawing.Color.Peru;
            this.lblLoai.Location = new System.Drawing.Point(1217, 4);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(0, 26);
            this.lblLoai.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label5.Location = new System.Drawing.Point(1155, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 26);
            this.label5.TabIndex = 16;
            this.label5.Text = "Loại:";
            // 
            // lblBan
            // 
            this.lblBan.AutoSize = true;
            this.lblBan.BackColor = System.Drawing.Color.Transparent;
            this.lblBan.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBan.ForeColor = System.Drawing.Color.Peru;
            this.lblBan.Location = new System.Drawing.Point(1531, 4);
            this.lblBan.Name = "lblBan";
            this.lblBan.Size = new System.Drawing.Size(0, 26);
            this.lblBan.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label6.Location = new System.Drawing.Point(1469, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 26);
            this.label6.TabIndex = 18;
            this.label6.Text = "Bàn: ";
            // 
            // btnDonBan
            // 
            this.btnDonBan.Appearance.Font = new System.Drawing.Font("Palatino Linotype", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDonBan.Appearance.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnDonBan.Appearance.Options.UseFont = true;
            this.btnDonBan.Appearance.Options.UseForeColor = true;
            this.btnDonBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDonBan.Enabled = false;
            this.btnDonBan.ImageOptions.Image = global::BakeryManagementSystem.Properties.Resources.icons8_clear_48;
            this.btnDonBan.Location = new System.Drawing.Point(908, 905);
            this.btnDonBan.Name = "btnDonBan";
            this.btnDonBan.Size = new System.Drawing.Size(695, 85);
            this.btnDonBan.TabIndex = 20;
            this.btnDonBan.Text = "Xóa đơn hàng";
            this.btnDonBan.Click += new System.EventHandler(this.btnDonBan_Click);
            // 
            // Column7
            // 
            this.Column7.FillWeight = 150F;
            this.Column7.HeaderText = "Tên";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 50F;
            this.Column9.HeaderText = "Số lượng";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Thành tiền";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Column2.FillWeight = 50F;
            this.Column2.HeaderText = "Trạng thái";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 81;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "TrangThai";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // UclBan
            // 
            this.Appearance.BackColor = System.Drawing.Color.Linen;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDonBan);
            this.Controls.Add(this.lblBan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblLoai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblSoHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbxHoaDon);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbxDSBan);
            this.Name = "UclBan";
            this.Size = new System.Drawing.Size(1606, 998);
            ((System.ComponentModel.ISupportInitialize)(this.gbxDSBan)).EndInit();
            this.gbxDSBan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gbxHoaDon)).EndInit();
            this.gbxHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl gbxDSBan;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl gbxHoaDon;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoHD;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBan;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btnDonBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewImageColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
