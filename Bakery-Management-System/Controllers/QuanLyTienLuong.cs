using BakeryManagementSystem.Models;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyTienLuong
    {
        private ChamCong chamCong = new ChamCong();
        
        public async Task<DataTable> LayDSChamCongAsync(string maNV, DateTime? ngayBatDau, DateTime? ngayKetThuc)
        {
            return await chamCong.LayDSChamCongAsync(int.Parse(maNV), ngayBatDau?.ToString("yyyy-MM-dd"), ngayKetThuc?.ToString("yyyy-MM-dd"));
        }

        public async Task CapNhatTinhTrangLuongAsync(DateTime ngayBatDau, DateTime ngayKetThuc, int maNV)
        {
            await chamCong.CapNhatTinhTrangLuongAsync(ngayBatDau.ToString("yyyy-MM-dd"), ngayKetThuc.ToString("yyyy-MM-dd"), maNV);
        }

        //Tính lương
        public double TinhLuong(GridView gridView)
        {
            if (gridView.DataSource != null)
            {
                double tienLuong = 0;
                for (int i = 0; i < gridView.RowCount; i++)
                {
                    if (gridView.GetRowCellValue(i, "Tình trạng lương").ToString() == "Chưa trả")
                    {
                        float luongNV = float.Parse(gridView.GetRowCellValue(i, "Mức lương").ToString());
                        TimeSpan gioVao = TimeSpan.Parse(gridView.GetRowCellValue(i, "Giờ vào").ToString());
                        TimeSpan gioTan = TimeSpan.Parse(gridView.GetRowCellValue(i, "Giờ tan").ToString());

                        int soPhutGioVao = gioVao.Minutes;
                        int soPhutGioTan = gioTan.Minutes;

                        int soGioLam = gioTan.Hours - gioVao.Hours;
                        int soPhutLam = soPhutGioVao + soPhutGioTan;

                        if (soPhutLam >= 60)
                        {
                            soGioLam += 1;
                            soPhutLam -= 60;
                        }

                        double tienLuongNgay = luongNV * soGioLam + ((luongNV/60) * soPhutLam);

                        int soPhutDiTre = int.Parse(gridView.GetRowCellValue(i, "Số phút đi trễ").ToString());

                        if(soPhutDiTre > 15)
                        {
                            tienLuongNgay = (tienLuongNgay * 90) / 100;
                        }

                        tienLuong += tienLuongNgay;
                    }
                }
                return tienLuong;
            }
            return 0;
        }
    }
}
