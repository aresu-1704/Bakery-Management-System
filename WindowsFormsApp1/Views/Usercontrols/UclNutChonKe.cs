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
    public partial class UclNutChonKe : DevExpress.XtraEditors.XtraUserControl
    {
        private int maKe;
        private bool trangThai;

        public event Action<int> click;

        public UclNutChonKe(int maKe, bool trangThai)
        {
            InitializeComponent();
            this.maKe = maKe;
            this.trangThai = trangThai;
            btnKe.Text = "Bàn " + maKe.ToString();
            if (trangThai)
            {
                btnKe.ImageOptions.SvgImage = Properties.Resources.actions_removecircled;
            }
            else
            {
                btnKe.ImageOptions.SvgImage = Properties.Resources.actions_checkcircled;
            }
        }

        private void btnBan_CheckedChanged(object sender, EventArgs e)
        {
            click?.Invoke(this.maKe);
        }
    }
}
