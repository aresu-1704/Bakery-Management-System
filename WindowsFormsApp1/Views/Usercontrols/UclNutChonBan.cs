using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclNutChonBan : DevExpress.XtraEditors.XtraUserControl
    {
        private int maBan;
        private bool trangThai;
        public event Action<int> click;
        public UclNutChonBan(int maBan, bool trangThai)
        {
            InitializeComponent();
            this.maBan = maBan;
            this.trangThai = trangThai;
            btnBan.Text = "Bàn " + maBan.ToString();
            if (trangThai)
            {
                btnBan.ImageOptions.SvgImage = Properties.Resources.actions_removecircled;
            }
            else
            {
                btnBan.ImageOptions.SvgImage = Properties.Resources.actions_checkcircled;
            }
        }

        private void btnBan_CheckedChanged(object sender, EventArgs e)
        {
            click?.Invoke(this.maBan);
        }
    }
}
