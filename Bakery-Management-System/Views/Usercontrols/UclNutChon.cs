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
    public partial class UclNutChon : DevExpress.XtraEditors.XtraUserControl
    {
        private int maThongTin;
        private bool trangThai;
        public event Action<int> click;

        public UclNutChon(int thongTin, bool trangThai, string noiDung)
        {
            InitializeComponent();
            this.maThongTin = thongTin;
            this.trangThai = trangThai;
            btnBan.Text = noiDung + " " + thongTin.ToString();

            if (trangThai == false && string.Equals("Chưa xếp", noiDung))
            {
                btnBan.Text = noiDung;
                btnBan.Image = Properties.Resources.question_32x32;
            }
            else if (trangThai)
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
            click?.Invoke(this.maThongTin);
        }
    }
}
