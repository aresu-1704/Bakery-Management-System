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

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmThongBao : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler choice;
        public frmThongBao(bool type, string tittle, string notice)
        {
            InitializeComponent();
            this.Text = tittle;
            lblNoiDung.Text = notice;
            setType(type);
        }

        private void setType(bool type)
        {
            btnCo.Visible = type;
            btnKhong.Visible = type;
            btnOk.Visible = !type;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCo_Click(object sender, EventArgs e)
        {
            choice?.Invoke(sender, EventArgs.Empty);
            this.Close();
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThongBao_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
        }
    }
}