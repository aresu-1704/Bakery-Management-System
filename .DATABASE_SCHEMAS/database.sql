USE [QuanLyTiemBanh]
GO
/****** Object:  Table [dbo].[Ban]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ban](
	[MaBan] [int] IDENTITY(1,1) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[MaHoaDon] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChamCong]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChamCong](
	[SoChamCong] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NOT NULL,
	[Ngay] [date] NOT NULL,
	[TinhTrangTraLuong] [bit] NULL,
	[SoPhutDiTre] [int] NULL,
	[MucLuong] [float] NOT NULL,
	[MaPC] [int] NOT NULL,
	[Giovao] [time](0) NULL,
	[GioTan] [time](7) NULL,
	[GioVaoThuc] [time](7) NULL,
PRIMARY KEY CLUSTERED 
(
	[SoChamCong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonTheoYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonTheoYeuCau](
	[MaHoaDon] [int] NOT NULL,
	[MaHH] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[GiaMua] [float] NULL,
	[PhuPhi] [float] NULL,
	[YeuCau] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHH] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaTien] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaCV] [int] IDENTITY(1,1) NOT NULL,
	[TenCV] [nvarchar](50) NULL,
	[MucLuong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaCV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonCheBienTheoYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonCheBienTheoYeuCau](
	[MaHH] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[MaHH] [int] IDENTITY(1,1) NOT NULL,
	[TenHH] [nvarchar](255) NULL,
	[GiaTien] [float] NOT NULL,
	[SanCo] [int] NOT NULL,
	[HinhAnh] [varbinary](max) NULL,
	[TrangThai] [bit] NOT NULL,
	[MaDotKhuyenMai] [int] NULL,
	[DanhMuc] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] NOT NULL,
	[ThoiGian] [datetime] NULL,
	[LoaiHoaDon] [bit] NULL,
	[MaKH] [int] NULL,
	[MaNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](10) NOT NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[SoDienThoai] [varchar](10) NULL,
	[GioiTinh] [bit] NOT NULL,
	[LoaiKH] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhoNguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhoNguyenLieu](
	[MaKhuVuc] [int] IDENTITY(1,1) NOT NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKhuVuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaDotKhuyenMai] [int] IDENTITY(1,1) NOT NULL,
	[TenKM] [nvarchar](50) NULL,
	[NgayBatDau] [date] NOT NULL,
	[NgayKetThuc] [date] NOT NULL,
	[ChietKhau] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDotKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguyenLieu](
	[MaNL] [int] IDENTITY(1,1) NOT NULL,
	[TenNL] [nvarchar](50) NOT NULL,
	[DonViTinh] [nvarchar](15) NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[MaNCC] [int] NOT NULL,
	[HSD] [date] NULL,
	[SoLuong] [float] NULL,
	[SoLuongNhap] [float] NULL,
	[TongTien] [float] NULL,
	[MaPhieu] [int] NULL,
	[MaKhuVuc] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaBep]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaBep](
	[MaHH] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[TrangThai] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHH] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[MaNCC] [int] IDENTITY(1,1) NOT NULL,
	[TenNCC] [nvarchar](50) NOT NULL,
	[Email] [varchar](50) NULL,
	[SoDienThoai] [varchar](10) NOT NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TrangThai] [bit] NOT NULL,
	[HinhAnh] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNV] [int] IDENTITY(1,1) NOT NULL,
	[TenDangNhap] [varchar](25) NULL,
	[Ho] [nvarchar](50) NULL,
	[Ten] [nvarchar](20) NULL,
	[SoDienThoai] [varchar](10) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NOT NULL,
	[QuocTich] [nvarchar](50) NOT NULL,
	[QueQuan] [nvarchar](50) NULL,
	[NgayThue] [date] NOT NULL,
	[TrangThai] [bit] NOT NULL,
	[MaCV] [int] NULL,
	[CCCD] [varchar](30) NULL,
	[HinhAnh] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaPC] [int] IDENTITY(1,1) NOT NULL,
	[MaNV] [int] NULL,
	[Ngay] [int] NULL,
	[GioVaoCa] [time](7) NOT NULL,
	[GioTanCa] [time](7) NOT NULL,
 CONSTRAINT [PK_PhanCong_8323] PRIMARY KEY CLUSTERED 
(
	[MaPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhapHang]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhapHang](
	[MaPhieu] [int] NOT NULL,
	[ThoiGian] [date] NULL,
	[MaNV] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[TenDangNhap] [varchar](25) NOT NULL,
	[MatKhau] [varbinary](256) NULL,
	[Muoi] [varbinary](16) NULL,
	[TrangThai] [bit] NULL,
	[SoLanDangNhap] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TenDangNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Ban] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[ChamCong] ADD  CONSTRAINT [DF_TinhTrangTraLuong]  DEFAULT ((0)) FOR [TinhTrangTraLuong]
GO
ALTER TABLE [dbo].[ChamCong] ADD  DEFAULT ((0)) FOR [SoPhutDiTre]
GO
ALTER TABLE [dbo].[ChamCong] ADD  DEFAULT ((0)) FOR [MucLuong]
GO
ALTER TABLE [dbo].[ChiTietDonTheoYeuCau] ADD  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((1)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[ChiTietHoaDon] ADD  DEFAULT ((0)) FOR [GiaTien]
GO
ALTER TABLE [dbo].[ChucVu] ADD  DEFAULT ((0)) FOR [MucLuong]
GO
ALTER TABLE [dbo].[DonCheBienTheoYeuCau] ADD  CONSTRAINT [dff_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[HangHoa] ADD  DEFAULT ((0)) FOR [GiaTien]
GO
ALTER TABLE [dbo].[HangHoa] ADD  DEFAULT ((0)) FOR [SanCo]
GO
ALTER TABLE [dbo].[HangHoa] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[HangHoa] ADD  DEFAULT ((0)) FOR [DanhMuc]
GO
ALTER TABLE [dbo].[HoaDon] ADD  DEFAULT ((0)) FOR [LoaiHoaDon]
GO
ALTER TABLE [dbo].[KhachHang] ADD  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[KhoNguyenLieu] ADD  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[KhuyenMai] ADD  DEFAULT ((0)) FOR [ChietKhau]
GO
ALTER TABLE [dbo].[NguyenLieu] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NguyenLieu] ADD  DEFAULT ((0)) FOR [SoLuong]
GO
ALTER TABLE [dbo].[NguyenLieu] ADD  DEFAULT ((0)) FOR [SoLuongNhap]
GO
ALTER TABLE [dbo].[NguyenLieu] ADD  DEFAULT ((0)) FOR [TongTien]
GO
ALTER TABLE [dbo].[NhaBep] ADD  CONSTRAINT [df_TrangThai]  DEFAULT ((0)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhaCungCap] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [GioiTinh]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[TaiKhoan] ADD  DEFAULT ((0)) FOR [SoLanDangNhap]
GO
ALTER TABLE [dbo].[Ban]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChamCong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[ChiTietDonTheoYeuCau]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
GO
ALTER TABLE [dbo].[ChiTietDonTheoYeuCau]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHH])
REFERENCES [dbo].[HangHoa] ([MaHH])
GO
ALTER TABLE [dbo].[DonCheBienTheoYeuCau]  WITH CHECK ADD FOREIGN KEY([MaHoaDon], [MaHH])
REFERENCES [dbo].[ChiTietDonTheoYeuCau] ([MaHoaDon], [MaHH])
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD FOREIGN KEY([MaDotKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([MaDotKhuyenMai])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD FOREIGN KEY([MaKhuVuc])
REFERENCES [dbo].[KhoNguyenLieu] ([MaKhuVuc])
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD FOREIGN KEY([MaNCC])
REFERENCES [dbo].[NhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[NguyenLieu]  WITH CHECK ADD FOREIGN KEY([MaPhieu])
REFERENCES [dbo].[PhieuNhapHang] ([MaPhieu])
GO
ALTER TABLE [dbo].[NhaBep]  WITH CHECK ADD FOREIGN KEY([MaHH], [MaHoaDon])
REFERENCES [dbo].[ChiTietHoaDon] ([MaHH], [MaHoaDon])
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_MaCV_597836] FOREIGN KEY([MaCV])
REFERENCES [dbo].[ChucVu] ([MaCV])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_MaCV_597836]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_TaiKhoan] FOREIGN KEY([TenDangNhap])
REFERENCES [dbo].[TaiKhoan] ([TenDangNhap])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_TaiKhoan]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[PhieuNhapHang]  WITH CHECK ADD FOREIGN KEY([MaNV])
REFERENCES [dbo].[NhanVien] ([MaNV])
GO
ALTER TABLE [dbo].[DonCheBienTheoYeuCau]  WITH CHECK ADD  CONSTRAINT [chek_TrangThai] CHECK  (([TrangThai]>=(0) AND [TrangThai]<=(3)))
GO
ALTER TABLE [dbo].[DonCheBienTheoYeuCau] CHECK CONSTRAINT [chek_TrangThai]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD CHECK  (([LoaiKH]=(2) OR [LoaiKH]=(1) OR [LoaiKH]=(0)))
GO
ALTER TABLE [dbo].[KhuyenMai]  WITH CHECK ADD  CONSTRAINT [KiemTraKM] CHECK  (([NgayKetThuc]>=[NgayBatDau]))
GO
ALTER TABLE [dbo].[KhuyenMai] CHECK CONSTRAINT [KiemTraKM]
GO
ALTER TABLE [dbo].[NhaBep]  WITH CHECK ADD  CONSTRAINT [chk_TrangThai] CHECK  (([TrangThai]>=(0) AND [TrangThai]<=(3)))
GO
ALTER TABLE [dbo].[NhaBep] CHECK CONSTRAINT [chk_TrangThai]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [chk_age] CHECK  (([NgaySinh]<=dateadd(year,(-18),CONVERT([date],getdate()))))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [chk_age]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [CK_NhanVienDu18TuoiDenNgayThue] CHECK  ((datediff(year,[NgaySinh],[NgayThue])>=(18) OR datediff(year,[NgaySinh],[NgayThue])=(18) AND [NgayThue]>=dateadd(year,(18),[NgaySinh])))
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [CK_NhanVienDu18TuoiDenNgayThue]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [CK__PhanCong__Ngay__0A9D95DB] CHECK  (([Ngay]>=(1) AND [Ngay]<=(7)))
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [CK__PhanCong__Ngay__0A9D95DB]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [CK_GioVaoCa_GioTanCa] CHECK  (([GioVaoCa]<[GioTanCa] OR [GioVaoCa]='00:00:00' AND [GioTanCa]='00:00:00'))
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [CK_GioVaoCa_GioTanCa]
GO
/****** Object:  StoredProcedure [dbo].[sp_BanLai]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_BanLai] @MaHH int
as
update HangHoa
set TrangThai = 1
where MaHH = @MaHH
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CapNhatChucVu] @TenCV nvarchar(50), @MucLuong float, @MaCV int
as
	UPDATE ChucVu
	SET TenCV = @TenCV, MucLuong = @MucLuong
	WHERE MaCV = @MaCV
				
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatDangNhap]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatDangNhap] @TenDangNhap nvarchar(25)
as
	 update TaiKhoan
	 set SoLanDangNhap = 0
	 where TenDangNhap = @TenDangNhap
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatDonBan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CapNhatDonBan] @MaBan int
as
	update Ban
	set MaHoaDon = null, TrangThai = 0
	where MaBan = @MaBan
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatDonBep]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CapNhatDonBep] @MaHoaDon int, @MaHH int, @TrangThai int
as
	UPDATE NhaBep
	SET TrangThai = @TrangThai
	Where MaHoaDon = @MaHoaDon AND MaHH = @MaHH

	Delete NhaBep
	where TrangThai = 3
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatDonBepYC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatDonBepYC] @MaHoaDon int, @MaHH int, @TrangThai int
as
	UPDATE DonCheBienTheoYeuCau
	SET TrangThai = @TrangThai
	Where MaHoaDon = @MaHoaDon AND MaHH = @MaHH

	Delete DonCheBienTheoYeuCau
	where TrangThai = 3
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatKhachHang]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatKhachHang]
    @MaKH INT,
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(10),
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(10) = NULL,
    @GioiTinh BIT,
	@LoaiKH INT
AS
BEGIN
    UPDATE KhachHang
    SET 
        Ho = @Ho,
        Ten = @Ten,
        NgaySinh = @NgaySinh,
        DiaChi = @DiaChi,
        SoDienThoai = @SoDienThoai,
        GioiTinh = @GioiTinh,
		LoaiKH = @LoaiKH
    WHERE MaKH = @MaKH;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatKM]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatKM] 
    @MaKM INT, 
    @TenKM NVARCHAR(50), 
    @NgayBatDau DATE, 
    @NgayKetThuc DATE, 
    @ChietKhau float
AS
BEGIN
    -- Kiểm tra nếu @MaKM tồn tại trong bảng KhuyenMai
    IF EXISTS (SELECT 1 FROM KhuyenMai WHERE MaDotKhuyenMai = @MaKM)
    BEGIN
        -- Cập nhật thông tin khuyến mãi
        UPDATE KhuyenMai
        SET 
            TenKM = @TenKM,
            NgayBatDau = @NgayBatDau,
            NgayKetThuc = @NgayKetThuc,
            ChietKhau = @ChietKhau
        WHERE 
            MaDotKhuyenMai = @MaKM;
        
        PRINT 'Cập nhật thành công.';
    END
    ELSE
    BEGIN
        PRINT 'Không tìm thấy khuyến mãi với mã này.';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatLayNguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatLayNguyenLieu]
    @MaNL INT,
    @SoLuong float
AS
BEGIN
    DECLARE @CurrentSoLuong float;

    -- Lấy số lượng hiện tại của nguyên liệu
    SELECT @CurrentSoLuong = SoLuong
    FROM NguyenLieu
    WHERE MaNL = @MaNL;

    -- Kiểm tra nếu số lượng cần trừ lớn hơn số lượng hiện tại thì báo lỗi
    IF @SoLuong > @CurrentSoLuong
    BEGIN
        RAISERROR('Số lượng yêu cầu lớn hơn số lượng hiện có. Cập nhật không thành công.', 16, 1);
        RETURN;
    END

    -- Thực hiện trừ số lượng
    UPDATE NguyenLieu
    SET SoLuong = SoLuong - @SoLuong
    WHERE MaNL = @MaNL;

	IF (@CurrentSoLuong - @SoLuong = 0)
    BEGIN
        UPDATE NguyenLieu
        SET TrangThai = 0
        WHERE MaNL = @MaNL;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatLichLam]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatLichLam] @MaPC int, @Ngay int, @GioVaoCa time, @GioTanCa time
as
	update PhanCong
	set Ngay = @Ngay, GioVaoCa = @GioVaoCa, GioTanCa = @GioTanCa
	where MaPC = @MaPC
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatMatKhau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sp_CapNhatMatKhau] 
    @MatKhauMoi VARBINARY(256), 
    @TenDangNhap VARCHAR(25),
	@Muoi Varbinary(16)
AS
BEGIN
    DECLARE @MatKhauCu VARBINARY(256);

    -- Lấy mật khẩu cũ của tài khoản
    SELECT @MatKhauCu = MatKhau
    FROM TaiKhoan
    WHERE TenDangNhap = @TenDangNhap;

    -- Kiểm tra nếu mật khẩu mới trùng với mật khẩu cũ
    IF (@MatKhauCu = @MatKhauMoi)
    BEGIN
        RAISERROR (N'Mật khẩu mới không được trùng với mật khẩu cũ.', 16, 1);
        RETURN;
    END

    -- Cập nhật mật khẩu
    UPDATE TaiKhoan
    SET MatKhau = @MatKhauMoi, TrangThai = 1, Muoi = @Muoi
    WHERE TenDangNhap = @TenDangNhap;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatNCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatNCC] 
    @MaNCC INT, 
    @TenNCC NVARCHAR(50), 
    @DiaChi NVARCHAR(255), 
    @Email VARCHAR(50), 
    @SoDienThoai VARCHAR(10), 
    @HinhAnh VARBINARY(MAX)
AS
BEGIN
    -- Update the NhaCungCap table
    UPDATE NhaCungCap
    SET 
        TenNCC = @TenNCC, 
        DiaChi = @DiaChi, 
        Email = @Email, 
        SoDienThoai = @SoDienThoai, 
        HinhAnh = @HinhAnh
    WHERE 
        MaNCC = @MaNCC

END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatNhanVien]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatNhanVien]
    @MaNV INT,
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(20),
    @SoDienThoai VARCHAR(10),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(255),
    @NgaySinh DATE,
    @GioiTinh BIT,
    @QueQuan NVARCHAR(50),
    @CCCD VARCHAR(30),
    @QuocTich NVARCHAR(50),
    @NgayThue DATE,
    @MaCV INT,
    @HinhAnh VARBINARY(MAX)
AS
BEGIN
IF(@MaCV != -1)
BEGIN
    UPDATE NhanVien
    SET
        Ho = @Ho,
        Ten = @Ten,
        SoDienThoai = @SoDienThoai,
        Email = @Email,
        DiaChi = @DiaChi,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        QueQuan = @QueQuan,
        CCCD = @CCCD,
        QuocTich = @QuocTich,
        NgayThue = @NgayThue,
        MaCV = @MaCV,
        HinhAnh = @HinhAnh
    WHERE MaNV = @MaNV;
END
ELSE
BEGIN
UPDATE NhanVien
    SET
        Ho = @Ho,
        Ten = @Ten,
        SoDienThoai = @SoDienThoai,
        Email = @Email,
        DiaChi = @DiaChi,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        QueQuan = @QueQuan,
        CCCD = @CCCD,
        QuocTich = @QuocTich,
        NgayThue = @NgayThue,
        HinhAnh = @HinhAnh
    WHERE MaNV = @MaNV;

	DELETE
	FROM PhanCong
	WHERE MaNV = @MaNV
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSoLanDangNhapSai]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREate proc [dbo].[sp_CapNhatSoLanDangNhapSai] @TenDangNhap varchar(25)
as
begin
	update TaiKhoan
	set SoLanDangNhap = SoLanDangNhap + 1
	where TenDangNhap = @TenDangNhap

	Declare @SoLanDangNhap int

	select @SoLanDangNhap = SoLanDangNhap
	from TaiKhoan
	where TenDangNhap = @TenDangNhap

	if (@SoLanDangNhap = 5)
	begin
		update TaiKhoan
		set TrangThai = 0
		where TenDangNhap = @TenDangNhap
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatSoLuongSanCo]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_CapNhatSoLuongSanCo] @MaHH int, @SoLuong int
as
	update HangHoa
	set SanCo = SanCo - @SoLuong
	where MaHH = @MaHH
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTaiKhoan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_CapNhatTaiKhoan] @TenDangNhap nvarchar(25), @MatKhau VARBINARY(256), @Muoi VARBINARY(16)
AS
	IF Exists (select 1 FROM TaiKhoan where TenDangNhap = @TenDangNhap and TrangThai = 0)
	BEGIN
		UPDATE TaiKhoan
		SET MatKhau = @MatKhau, Muoi = @Muoi, TrangThai = 1, SoLanDangNhap = 0
		WHERE TenDangNhap = @TenDangNhap
	END
	ELSE
	BEGIN
		UPDATE TaiKhoan
		SET TrangThai = 0
		WHERE TenDangNhap = @TenDangNhap
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangBan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CapNhatTinhTrangBan]
    @MaBan INT,
    @MaHoaDon INT
AS
BEGIN
    -- Cập nhật bảng Ban và set TrangThai = 1
    UPDATE Ban
    SET TrangThai = 1, MaHoaDon = @MaHoaDon
    WHERE MaBan = @MaBan

    -- Kiểm tra xem có bản ghi nào được cập nhật không
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'Không tìm thấy bàn hoặc hóa đơn phù hợp để cập nhật.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTinhTrangLuong]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_CapNhatTinhTrangLuong] @NgayBatDau date, @NgayKetThuc date, @MaNV int
as
	create index idx_MaNV on ChamCong(MaNV)
	update ChamCong
	set TinhTrangTraLuong = 1
	where Ngay between @NgayBatDau and @NgayKetThuc and MaNV = @MaNV
	drop index idx_MaNV on ChamCong
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatTTSanPham]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_CapNhatTTSanPham] @MaHH int, @TenHH nvarchar(255), @GiaTien float, @SanCo int, @HinhAnh varbinary(MAX), @MaKM int, @DanhMuc Bit
as
	if @MaKM = 0
	begin
		update HangHoa 
		set
			TenHH = @TenHH,
			GiaTien = @GiaTien,
			SanCo = @SanCo,
			HinhAnh = @HinhAnh,
			DanhMuc = @DanhMuc
		where MaHH = @MaHH
	end
	else
	begin
		update HangHoa 
		set
			TenHH = @TenHH,
			GiaTien = @GiaTien,
			SanCo = @SanCo,
			HinhAnh = @HinhAnh,
			MaDotKhuyenMai = @MaKM,
			DanhMuc = @DanhMuc
		where MaHH = @MaHH
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_CapNhatViTriNguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_CapNhatViTriNguyenLieu] @MaKhuVuc int, @MaNL int
as
	update NguyenLieu
	set MaKhuVuc = @MaKhuVuc
	where MaNL = @MaNL
GO
/****** Object:  StoredProcedure [dbo].[sp_ChamCongVaoCa]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_ChamCongVaoCa] @MaNV INT, @MaPC INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Lấy mức lương của nhân viên
    DECLARE @MucLuong FLOAT;
    SELECT @MucLuong = C.MucLuong
    FROM NhanVien N
    INNER JOIN ChucVu C ON N.MaCV = C.MaCV
    WHERE N.MaNV = @MaNV;

    -- Lấy giờ hiện tại
    DECLARE @GioVao TIME(0) = CAST(GETDATE() AS TIME(0));

    -- Lấy giờ vào ca của nhân viên trong bảng PhanCong
    DECLARE @GioVaoCa TIME(0), @GioTanCa TIME(0);
    SELECT @GioVaoCa = GioVaoCa, @GioTanCa = GioTanCa
    FROM PhanCong
    WHERE MaNV = @MaNV AND MaPC = @MaPC;

    -- Kiểm tra đi sớm và đi trễ
    DECLARE @SoPhutDiSom INT = DATEDIFF(MINUTE, @GioVao, @GioVaoCa);
    DECLARE @SoPhutDiTre INT = DATEDIFF(MINUTE, @GioVaoCa, @GioVao);

    -- Nếu đi sớm hơn 30 phút, không cho điểm danh
    IF @SoPhutDiSom > 30
    BEGIN
        RAISERROR ('Nhân viên điểm danh quá sớm, không thể chấm công!', 16, 1);
        RETURN;
    END

    -- Nếu đi trễ hơn 30 phút, không cho điểm danh
    IF @SoPhutDiTre > 30
    BEGIN
        RAISERROR ('Nhân viên đi trễ hơn 30 phút, không thể chấm công!', 16, 1);
        RETURN;
    END

    -- Nếu đi sớm nhưng trong khoảng cho phép, đặt số phút đi trễ về 0
    IF @SoPhutDiTre < 0 SET @SoPhutDiTre = 0;

    -- Chấm công
    INSERT INTO ChamCong (MaNV, MaPC, Ngay, GioVao, GioVaoThuc, GioTan, SoPhutDiTre, MucLuong)
    VALUES (@MaNV, @MaPC, CAST(GETDATE() AS DATE), @GioVaoCa, @GioVao, @GioTanCa, @SoPhutDiTre, @MucLuong);
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_DoiTrangThaiKe]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DoiTrangThaiKe] 
    @MaKe INT
AS
BEGIN
    UPDATE KhoNguyenLieu
    SET TrangThai = CASE WHEN TrangThai = 1 THEN 0 ELSE 1 END
    WHERE MaKhuVuc = @MaKe;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HuyDiemDanh]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_HuyDiemDanh] @MaNV int, @MaPC int
	as
		delete from ChamCong
		where MaNV = @MaNV and @MaPC = MaPC and Ngay = CAST(GETDATE() AS DATE)
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraSoLanDangNhap]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREate proc [dbo].[sp_KiemTraSoLanDangNhap] @TenDangNhap varchar(25)
as
begin
	select SoLanDangNhap
	from TaiKhoan
	where TenDangNhap = @TenDangNhap
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayChiTietHoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayChiTietHoaDon] @MaHD int
as 
	if exists (select 1 from ChiTietHoaDon where MaHoaDon = @MaHD)
	begin		
	 select TenHH, SoLuong, C.GiaTien, Ho + ' ' + Ten as TenNV
	 from HoaDon H inner join ChiTietHoaDon C on H.MaHoaDon = C.MaHoaDon
	 inner join HangHoa HH on HH.MaHH = C.MaHH
	 inner join NhanVien N on H.MaNV = N.MaNV
	 where H.MaHoaDon = @MaHD
	end
	else
	begin
		select TenHH, SoLuong, C.GiaMua + PhuPhi as GiaMua, Ho + ' ' + Ten as TenNV, YeuCau, PhuPhi
		from HoaDon H inner join ChiTietDonTheoYeuCau C on H.MaHoaDon = C.MaHoaDon
		inner join HangHoa HH on HH.MaHH = C.MaHH
		inner join NhanVien N on H.MaNV = N.MaNV
		where H.MaHoaDon = @MaHD
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayChiTietPhieuNhap]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayChiTietPhieuNhap] 
    @MaNL INT
AS
BEGIN
    SELECT P.MaPhieu, MaNL, TenNL, SoLuongNhap, DonViTinh, MaNCC, ThoiGian, 
           NV.Ho + ' ' + NV.Ten AS TenNV, TongTien
    FROM PhieuNhapHang P 
    LEFT JOIN NguyenLieu NL ON P.MaPhieu = NL.MaPhieu
    INNER JOIN NhanVien NV ON P.MaNV = NV.MaNV
    WHERE EXISTS (SELECT 1
				FROM PhieuNhapHang P2 INNER JOIN NguyenLieu NL2 on P2.MaPhieu = NL2.MaPhieu
				WHERE P2.MaPhieu = P.MaPhieu and NL2.MaNL = @MaNL)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	create proc [dbo].[sp_LayChucVu]
	as
		select *
		from ChucVu
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachBan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDanhSachBan]
as
	select * from Ban where TrangThai = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachChucVu]
as
select C.MaCV AS N'Mã chức vụ', TenCV AS N'Tên chức vụ', MucLuong AS N'Mức lương', Count(N.MaCV) AS 'Số lượng nhân viên'
from ChucVu C left join NhanVien N on C.MaCV = N.MaCV
group by C.MaCV,TenCV, MucLuong
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachKeNL]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayDanhSachKeNL]
as
	select MaKhuVuc, TrangThai
	from KhoNguyenLieu
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachNCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE proc [dbo].[sp_LayDanhSachNCC]
  as
	select N.MaNCC, TenNCC, N.TrangThai, HinhAnh, count(MaNL) as SoLanCungCap
	from NhaCungCap N left join NguyenLieu L on N.MaNCC = L.MaNCC
	group by N.MaNCC, N.TenNCC, N.TrangThai, HinhAnh
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachNL]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayDanhSachNL] @MaKhuVuc int
as
begin
	if(@MaKhuVuc = 0)
	begin
		select MaNL, TenNL, SoLuong, DonViTinh, HSD, TrangThai, MaKhuVuc
		from NguyenLieu 
		where MaKhuVuc is null
	end
	else
	begin
		select MaNL, TenNL, SoLuong, DonViTinh, HSD, TrangThai, MaKhuVuc
		from NguyenLieu 
		where MaKhuVuc = @MaKhuVuc
	end
end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachNV]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDanhSachNV]
as
	select MaNV, Ho + ' ' + Ten as HoVaTen, SoDienThoai, Email, DiaChi, NgaySinh, Case GioiTinh
	when 0 then N'Nữ' when 1 then 'Nam' end as GioiTinh, QuocTich, QueQuan, NgayThue, TrangThai, TenCV, CCCD, HinhAnh
	from NhanVien N left join ChucVu C on N.MaCV = C.MaCV
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDanhSachTaiKhoan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayDanhSachTaiKhoan]
AS
	SELECT T.TenDangNhap, T.TrangThai, Ho + ' ' + Ten as 'HoTen'
	FROM TaiKhoan T INNER JOIN NhanVien N ON N.TenDangNhap = T.TenDangNhap
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDonBep]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDonBep]
as
	select MaHoaDon, NB.MaHH, TenHH, NB.TrangThai, SoLuong from NhaBep NB inner join HangHoa H on H.MaHH = NB.MaHH
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDonBepDaHoanThanh]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDonBepDaHoanThanh]
as
	SELECT N.MaHoaDon, N.MaHH, TenHH, LoaiHoaDon, MaBan, C.SoLuong
	FROM NhaBep N INNER JOIN ChiTietHoaDon C ON N.MaHH = C.MaHH AND N.MaHoaDon = C.MaHoaDon
	INNER JOIN HangHoa H ON H.MaHH = N.MaHH
	INNER JOIN HoaDon HD ON HD.MaHoaDon = C.MaHoaDon
	INNER JOIN BAN B ON C.MaHoaDon = B.MaHoaDon
	WHERE N.TrangThai = 2
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDonBepYCDaHoanThanh]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDonBepYCDaHoanThanh]
as
	SELECT N.MaHoaDon, N.MaHH, TenHH, LoaiHoaDon, MaBan, C.SoLuong
	FROM DonCheBienTheoYeuCau N INNER JOIN ChiTietDonTheoYeuCau C ON N.MaHH = C.MaHH AND N.MaHoaDon = C.MaHoaDon
	INNER JOIN HangHoa H ON H.MaHH = N.MaHH
	INNER JOIN HoaDon HD ON HD.MaHoaDon = C.MaHoaDon
	INNER JOIN BAN B ON C.MaHoaDon = B.MaHoaDon
	WHERE N.TrangThai = 2
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDonBepYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDonBepYeuCau]
as
	select NB.MaHoaDon, NB.MaHH, TenHH, NB.TrangThai, C.SoLuong, YeuCau
	from DonCheBienTheoYeuCau NB inner join HangHoa H on H.MaHH = NB.MaHH
	inner join ChiTietDonTheoYeuCau C on C.MaHoaDon = NB.MaHoaDon and NB.MaHH = C.MaHH
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDSKhachHang]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDSKhachHang]
as
	select K.MaKH, Ho + ' ' + Ten as HoVaTen, SoDienThoai, LoaiKH, count(H.MaKH) as SoLanMua
	from KhachHang K left join HoaDon H on K.MaKH = H.MaKH
	group by K.MaKH, Ho + ' ' + Ten, SoDienThoai, LoaiKH

GO
/****** Object:  StoredProcedure [dbo].[sp_LayDSNguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayDSNguyenLieu]
as
	select N.MaNL, TenNL, N.SoLuong, DonViTinh, N.TrangThai, TenNCC
	from NguyenLieu N
	inner join NhaCungCap NCC on N.MaNCC = NCC.MaNCC

	 -- Update TrangThai to 0 if HSD was yesterday
    UPDATE NguyenLieu
    SET TrangThai = 0
    WHERE HSD = DATEADD(day, -1, CAST(GETDATE() AS DATE))
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDSSPDangKM]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayDSSPDangKM] @MaKM int
as
	select HinhAnh, MaHH, TenHH
	from HangHoa
	where MaDotKhuyenMai = @MaKM
GO
/****** Object:  StoredProcedure [dbo].[sp_layDSToanBoBan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_layDSToanBoBan]
as
	select * from Ban
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDSTraLuongNV]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_LayDSTraLuongNV] 
as
	 select MaNV, Ho + ' ' + Ten AS HoVaTen, case TrangThai when 1 Then N'Còn làm' when 0 then N'Đã nghỉ' end as TrangThai
	 from NhanVien N
GO
/****** Object:  StoredProcedure [dbo].[sp_LayKH]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayKH] @MaKH int 
as
	select MaKH,Ho, Ten, Ho + ' ' + Ten as TenKH, DiaChi, SoDienThoai, GioiTinh, NgaySinh from KhachHang
	where MaKH = @MaKH
GO
/****** Object:  StoredProcedure [dbo].[sp_LayLichChamCong]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayLichChamCong] @MaNV int, @NgayBatDau Date, @NgayKetThuc Date
as
	select Ho + ' ' + Ten AS N'Họ và tên', TinhTrangTraLuong as N'Tình trạng trả lương', Ngay as N'Ngày', GioVao as N'Giờ vào', GioTan as N'Giờ tan', SoPhutDiTre As N'Số phút đi trễ', MucLuong As N'Mức lương'
	from ChamCong C INNER JOIN NhanVien N ON N.MaNV = C.MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_LayLichLam]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayLichLam] @MaNV int
as
	create index idx_MaNV_PC on PhanCong(MaNV asc);
	select MaPC, N.Ho + ' ' + N.Ten as HoVaTen, Case Ngay
	WHEN 1 THEN N'Chủ nhật'
            WHEN 2 THEN N'Thứ 2'
            WHEN 3 THEN N'Thứ 3'
            WHEN 4 THEN N'Thứ 4'
            WHEN 5 THEN N'Thứ 5'
            WHEN 6 THEN N'Thứ 6'
            WHEN 7 THEN N'Thứ 7' end as Ngay, GioVaoCa, GioTanCa
	from PhanCong P inner join NhanVien N on N.MaNV = P.MaNV
	where P.MaNV = isnull(@MaNV, P.MaNV)
	drop index idx_MaNV_PC on PhanCong
GO
/****** Object:  StoredProcedure [dbo].[sp_LayLichLamHomNay]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_LayLichLamHomNay]
AS
BEGIN
    SELECT 
		P.MaPC,
		P.MaNV,
        N.Ho + ' ' + N.Ten AS HoTen,
        P.GioVaoCa,
        P.GioTanCa,
		C.GioVaoThuc,
        TrangThai = CASE 
            WHEN EXISTS (
                SELECT 1 
                FROM ChamCong C 
                WHERE C.MaNV = P.MaNV 
                  AND C.MaPC = P.MaPC 
                  AND CAST(C.Ngay AS DATE) = CAST(GETDATE() AS DATE)
            ) THEN 1
            ELSE 0
        END
    FROM PhanCong P
    INNER JOIN NhanVien N ON P.MaNV = N.MaNV
	LEFT JOIN ChamCong C ON C.MaNV = N.MaNV AND C.MaPC = P.MaPC
	WHERE P.Ngay = DATEPART(WEEKDAY, GETDATE()) 
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_LayNCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_LayNCC] @MaNCC int
as
	select * from NhaCungCap where MaNCC = @MaNCC
GO
/****** Object:  StoredProcedure [dbo].[sp_LayNguyenLieuTungCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE proc [dbo].[sp_LayNguyenLieuTungCC] @MaNCC int
	as
		select N.MaNL, TenNL, ThoiGian
		from NguyenLieu N inner join PhieuNhapHang P on N.MaPhieu = P.MaPhieu
		where N.MaNCC = @MaNCC
GO
/****** Object:  StoredProcedure [dbo].[sp_LayNhanVien]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_LayNhanVien] @MaNV int
as
	select MaNV, TenDangNhap, Ho, Ten , SoDienThoai, Email, DiaChi, NgaySinh, Case GioiTinh
	when 0 then N'Nữ' when 1 then 'Nam' end as GioiTinh, QuocTich, QueQuan, NgayThue, TrangThai, TenCV, N.MaCV, CCCD, HinhAnh
	from NhanVien N left join ChucVu C on N.MaCV = C.MaCV
	where MaNV = @MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_LaySPBinhThuong]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[sp_LaySPBinhThuong] 
as
	select MaHH, TenHH, GiaTien, SanCo, HinhAnh, TrangThai, ChietKhau, TenKM
	from HangHoa H left join KhuyenMai K on H.MaDotKhuyenMai = K.MaDotKhuyenMai
	where DanhMuc = 0
GO
/****** Object:  StoredProcedure [dbo].[sp_LaySPTheoYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[sp_LaySPTheoYeuCau]
as
	select MaHH, TenHH, GiaTien, SanCo, HinhAnh, TrangThai, ChietKhau, TenKM
	from HangHoa H left join KhuyenMai K on H.MaDotKhuyenMai = K.MaDotKhuyenMai
	where DanhMuc = 1
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTaiKhoan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE proc [dbo].[sp_LayTaiKhoan] @TenDangNhap varchar(25)
	as
		select T.TenDangNhap, MatKhau, MaNV, TenCV, Muoi, T.TrangThai
		from TaiKhoan T left join NhanVien N on T.TenDangNhap = N.TenDangNhap
		left join ChucVu C on N.MaCV = C.MaCV
		where T.TenDangNhap = @TenDangNhap
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinHoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_LayThongTinHoaDon] @MaKH int
as 
	create index idx_MaKH on HoaDon(MaKH)
	select H.MaHoaDon, ThoiGian, LoaiHoaDon, Sum(GiaTien) as TongTien
	from HoaDon H inner join ChiTietHoaDon C on H.MaHoaDon = C.MaHoaDon
	where MaKH = @MaKH
	group by H.MaHoaDon, ThoiGian, LoaiHoaDon
	drop index idx_MaKH on HoaDon
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinHoaDonBan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayThongTinHoaDonBan] @MaBan int
as
	declare @MaHoaDon int
	select @MaHoaDon = MaHoaDon
	from Ban
	where MaBan = @MaBan
	if exists(select 1 from ChiTietHoaDon where MaHoaDon = @MaHoaDon)
	begin
		select B.MaBan, B.MaHoaDon, LoaiHoaDon, TenHH, C.SoLuong, C.GiaTien, NB.TrangThai
		from Ban B
		inner join HoaDon H on B.MaHoaDon = H.MaHoaDon
		inner join ChiTietHoaDon C on B.MaHoaDon = C.MaHoaDon
		inner join HangHoa HH on C.MaHH = HH.MaHH
		left join NhaBep NB on NB.MaHoaDon = C.MaHoaDon and C.MaHH = NB.MaHH
		where B.MaBan = @MaBan
	end
	else
	begin
		select B.MaBan, B.MaHoaDon, LoaiHoaDon, TenHH, C.SoLuong, C.GiaMua
		from Ban B
		inner join HoaDon H on B.MaHoaDon = H.MaHoaDon
		inner join ChiTietDonTheoYeuCau C on B.MaHoaDon = C.MaHoaDon
		inner join HangHoa HH on C.MaHH = HH.MaHH
		left join DonCheBienTheoYeuCau NB on NB.MaHoaDon = C.MaHoaDon and C.MaHH = NB.MaHH
		where B.MaHoaDon = @MaHoaDon
	end
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinKM]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayThongTinKM]
AS
BEGIN
    -- Xóa các bản ghi có NgayKetThuc là ngày hôm qua
    DELETE FROM KhuyenMai
    WHERE NgayKetThuc = CONVERT(DATE, GETDATE() - 1)

    -- Truy vấn lấy thông tin các khuyến mãi còn lại
    SELECT MaDotKhuyenMai AS N'Mã', TenKM AS N'Tên khuyến mãi', NgayBatDau AS N'Ngày bắt đầu', NgayKetThuc AS N'Ngày kết thúc', ChietKhau AS N'Chiết khấu'
    FROM KhuyenMai
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayThongTinSP]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayThongTinSP]
as
	select MaHH, TenHH, GiaTien, SanCo, HinhAnh, TrangThai, ChietKhau, TenKM, DanhMuc
	from HangHoa H left join KhuyenMai K on H.MaDotKhuyenMai = K.MaDotKhuyenMai
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTTChiDinhSanPham]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_LayTTChiDinhSanPham] @MaHH int
as
	select MaHH, TenHH, GiaTien, SanCo, HinhAnh, TrangThai, TenKM, DanhMuc
	from HangHoa H left join KhuyenMai K on H.MaDotKhuyenMai = K.MaDotKhuyenMai
	where MaHH = @MaHH
GO
/****** Object:  StoredProcedure [dbo].[sp_LayTTKMChiDinh]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_LayTTKMChiDinh] @MaKM int
as
	SELECT TenKM AS N'Tên khuyến mãi', NgayBatDau AS N'Ngày bắt đầu', NgayKetThuc AS N'Ngày kết thúc', ChietKhau AS N'Chiết khấu'
    FROM KhuyenMai
	where MaDotKhuyenMai = @MaKM
GO
/****** Object:  StoredProcedure [dbo].[sp_TaoTaiKhoan]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TaoTaiKhoan] @TenDangNhap varchar(25), @MatKhau varbinary(256), @MaNV int, @Muoi Varbinary(16)
as
	insert into TaiKhoan(TenDangNhap, MatKhau, Muoi) values (@TenDangNhap, @MatKhau, @Muoi)
	update NhanVien
	set TenDangNhap = @TenDangNhap
	where MaNV = @MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemChucVu] @TenCV nvarchar(50), @MucLuong float
as
	Insert into ChucVu(TenCV, MucLuong) Values (@TenCV, @MucLuong)
				
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemHoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemHoaDon]
    @MaHoaDon INT,
    @ThoiGian DATETIME = NULL,
    @MaNV INT,
    @LoaiHoaDon BIT,
    @MaKH INT = NULL
AS
BEGIN
    IF @ThoiGian IS NULL
        SET @ThoiGian = GETDATE();
   
    INSERT INTO HoaDon (MaHoaDon, ThoiGian, MaNV, LoaiHoaDon, MaKH)
    VALUES (@MaHoaDon, @ThoiGian, @MaNV, @LoaiHoaDon, @MaKH);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKe]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_ThemKe]
as
	Insert into KhoNguyenLieu(TrangThai)
	Values (0)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKhachHang]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemKhachHang]
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(10),
    @NgaySinh DATE = NULL,
    @DiaChi NVARCHAR(255) = NULL,
    @SoDienThoai VARCHAR(10) = NULL,
    @GioiTinh BIT,
	@LoaiKH INT
AS
BEGIN
    INSERT INTO KhachHang (Ho, Ten, NgaySinh, DiaChi, SoDienThoai, GioiTinh, LoaiKH)
    VALUES (@Ho, @Ten, @NgaySinh, @DiaChi, @SoDienThoai, @GioiTinh, @LoaiKH);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemKhuyenMai]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemKhuyenMai]
    @TenKM NVARCHAR(50),
    @NgayBatDau DATE,
    @NgayKetThuc DATE,
    @ChietKhau FLOAT
AS
BEGIN
    -- Bắt đầu một transaction
    BEGIN TRANSACTION

    BEGIN TRY
        -- Thực hiện câu lệnh INSERT
        INSERT INTO KhuyenMai (TenKM, NgayBatDau, NgayKetThuc, ChietKhau)
        VALUES (@TenKM, @NgayBatDau, @NgayKetThuc, @ChietKhau)

        -- Xác nhận transaction
        COMMIT TRANSACTION
        PRINT 'Insert thành công!'
    END TRY
    BEGIN CATCH
        -- Nếu có lỗi, rollback transaction
        ROLLBACK TRANSACTION
        PRINT 'Lỗi khi thực hiện insert!'
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemLichLam]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE proc [dbo].[sp_ThemLichLam] @MaNV int, @Ngay int, @GioVaoCa time, @GioTanCa time
	as
		Insert into PhanCong(MaNV, Ngay, GioTanCa, GioVaoCa) 
		Values (@MaNV, @Ngay, @GioTanCa, @GioVaoCa)
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ThemNCC] 
    @TenNCC NVARCHAR(50), 
    @DiaChi NVARCHAR(255), 
    @Email VARCHAR(50), 
    @SoDienThoai VARCHAR(10), 
    @HinhAnh VARBINARY(MAX)
AS
BEGIN
    -- Insert data into the NhaCungCap table
    INSERT INTO NhaCungCap (TenNCC, DiaChi, Email, SoDienThoai, HinhAnh, TrangThai)
    VALUES (@TenNCC, @DiaChi, @Email, @SoDienThoai, @HinhAnh, 1)
    
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNguyenLieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemNguyenLieu]
    @TenNL NVARCHAR(50),
    @DonViTinh NVARCHAR(15),
    @TrangThai BIT,
    @MaNCC INT,
	@SoLuong FLOAT,
    @HSD DATE,
	@SoLuongNhap float,
	@MaPhieu int,
	@TongTien float
AS
BEGIN
    INSERT INTO NguyenLieu (TenNL, DonViTinh, TrangThai, MaNCC, HSD, SoLuong, SoLuongNhap, MaPhieu, TongTien)
    VALUES (@TenNL, @DonViTinh, @TrangThai, @MaNCC, @HSD, @SoLuong, @SoLuongNhap, @MaPhieu, @TongTien);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemNhanVien]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemNhanVien]
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(20),
    @SoDienThoai VARCHAR(10),
    @Email NVARCHAR(50),
    @DiaChi NVARCHAR(255),
    @NgaySinh DATE,
    @GioiTinh BIT,
    @QueQuan NVARCHAR(50),
    @CCCD VARCHAR(30),
    @QuocTich NVARCHAR(50),
    @NgayThue DATE,
    @MaCV INT = NULL,
	@TrangThai bit = 1,
    @HinhAnh VARBINARY(MAX)
AS
BEGIN
    -- Thêm nhân viên mới vào bảng NhanVien
	If(@MaCV = -1)
	begin
    INSERT INTO NhanVien
    (
        Ho, 
        Ten, 
        SoDienThoai, 
        Email, 
        DiaChi, 
        NgaySinh, 
        GioiTinh, 
        QueQuan, 
        CCCD, 
        QuocTich, 
        NgayThue, 
        HinhAnh,
		TrangThai
    )
    VALUES
    (
        @Ho, 
        @Ten, 
        @SoDienThoai, 
        @Email, 
        @DiaChi, 
        @NgaySinh, 
        @GioiTinh, 
        @QueQuan, 
        @CCCD, 
        @QuocTich, 
        @NgayThue, 
        @HinhAnh,
		@TrangThai
    );
	end
	else
	begin
	 INSERT INTO NhanVien
    (
        Ho, 
        Ten, 
        SoDienThoai, 
        Email, 
        DiaChi, 
        NgaySinh, 
        GioiTinh, 
        QueQuan, 
        CCCD, 
        QuocTich, 
        NgayThue, 
        MaCV, 
        HinhAnh,
		TrangThai
    )
    VALUES
    (
        @Ho, 
        @Ten, 
        @SoDienThoai, 
        @Email, 
        @DiaChi, 
        @NgaySinh, 
        @GioiTinh, 
        @QueQuan, 
        @CCCD, 
        @QuocTich, 
        @NgayThue, 
        @MaCV, 
        @HinhAnh,
		@TrangThai

    );
	end
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemPhieuNhap]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemPhieuNhap] 
    @MaPhieu INT, 
    @MaNV INT
AS
BEGIN
    INSERT INTO PhieuNhapHang (MaPhieu, MaNV, ThoiGian)
    VALUES (@MaPhieu, @MaNV, GETDATE()); -- GETDATE() để lấy ngày giờ hiện tại
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemSP]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemSP]
    @TenHH NVARCHAR(50),
    @SanCo INT,
    @HinhAnh VARBINARY(MAX),
    @GiaTien FLOAT,
    @MaKM INT,
	@DanhMuc BIT
AS
BEGIN
	IF @MaKM = 0
	BEGIN
		INSERT INTO HangHoa (TenHH, SanCo, HinhAnh, GiaTien, DanhMuc)
		VALUES (@TenHH, @SanCo, @HinhAnh, @GiaTien, @DanhMuc);
	END
	ELSE
	BEGIN
		INSERT INTO HangHoa (TenHH, SanCo, HinhAnh, GiaTien, MaDotKhuyenMai, DanhMuc)
		VALUES (@TenHH, @SanCo, @HinhAnh, @GiaTien, @MaKM, @DanhMuc);
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemVaoBep]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemVaoBep]
    @MaHH INT,
    @MaHD INT,
    @SoLuong INT
AS
BEGIN
    -- Kiểm tra nếu bản ghi đã tồn tại
    IF NOT EXISTS (
        SELECT 1 FROM NhaBep 
        WHERE MaHH = @MaHH AND MaHoaDon = @MaHD
    )
    BEGIN
        -- Thêm mới vào bảng NhaBep với TrangThai mặc định là 0
        INSERT INTO NhaBep (MaHH, MaHoaDon, SoLuong, TrangThai)
        VALUES (@MaHH, @MaHD, @SoLuong, 0);
    END
    ELSE
    BEGIN
        PRINT 'Bản ghi đã tồn tại trong NhaBep';
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ThemVaoBepTheoYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemVaoBepTheoYeuCau]
    @MaHH INT,
    @MaHD INT,
    @SoLuong INT
AS
BEGIN
    -- Kiểm tra nếu bản ghi đã tồn tại
    IF NOT EXISTS (
        SELECT 1 FROM NhaBep 
        WHERE MaHH = @MaHH AND MaHoaDon = @MaHD
    )
    BEGIN
        -- Thêm mới vào bảng NhaBep với TrangThai mặc định là 0
        INSERT INTO DonCheBienTheoYeuCau (MaHH, MaHoaDon, SoLuong, TrangThai)
        VALUES (@MaHH, @MaHD, @SoLuong, 0);
    END
    ELSE
    BEGIN
        PRINT 'Bản ghi đã tồn tại trong NhaBep';
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_ThemVaoHoaDon]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemVaoHoaDon]
    @MaHD INT,
    @MaHH INT,
    @SoLuong INT,
    @GiaTien FLOAT
AS
BEGIN
    -- Kiểm tra xem hóa đơn có tồn tại hay không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE MaHoaDon = @MaHD)
    BEGIN
        -- Chèn dữ liệu vào bảng ChiTietHoaDon
        INSERT INTO ChiTietHoaDon (MaHoaDon, MaHH, SoLuong, GiaTien)
        VALUES (@MaHD, @MaHH, @SoLuong, @GiaTien);
        
        -- Trả về thông báo thành công
        SELECT 'Thêm thành công vào hóa đơn' AS Message;
    END
    ELSE
    BEGIN
        -- Trả về thông báo hóa đơn không tồn tại
        SELECT 'Hóa đơn không tồn tại' AS Message;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemVaoHoaDonTheoYeuCau]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThemVaoHoaDonTheoYeuCau]
    @MaHD INT,
    @MaHH INT,
    @SoLuong INT,
    @GiaTien FLOAT,
	@YeuCau NVARCHAR(MAX),
	@PhuThu FLOAT
AS
BEGIN
    -- Kiểm tra xem hóa đơn có tồn tại hay không
    IF EXISTS (SELECT 1 FROM HoaDon WHERE MaHoaDon = @MaHD)
    BEGIN
        -- Chèn dữ liệu vào bảng ChiTietHoaDon
        INSERT INTO ChiTietDonTheoYeuCau (MaHoaDon, MaHH, SoLuong, GiaMua, YeuCau, PhuPhi)
        VALUES (@MaHD, @MaHH, @SoLuong, @GiaTien, @YeuCau, @PhuThu);
        
        -- Trả về thông báo thành công
        SELECT 'Thêm thành công vào hóa đơn' AS Message;
    END
    ELSE
    BEGIN
        -- Trả về thông báo hóa đơn không tồn tại
        SELECT 'Hóa đơn không tồn tại' AS Message;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TimEmail]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_TimEmail] @Email nvarchar(50)
as
	CREATE INDEX idx_Temp on NhanVien(Email)
	select TenDangNhap
	from NhanVien
	Where Email = @Email
	Drop index idx_Temp on NhanVien
GO
/****** Object:  StoredProcedure [dbo].[sp_TinhTongTienPhieu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_TinhTongTienPhieu] @MaPhieu int
as
	select MaPhieu, Sum(TongTien) as TongTien
	from NguyenLieu
	where MaPhieu = @MaPhieu
	group by MaPhieu
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaChucVu]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaChucVu] @MaCV int
as
	create index idx_MaCV_7363 on NhanVien(MaCV)
	update NhanVien
	set MaCV = NULL
	where MaCV = @MaCV

	delete ChucVu
	where MaCV = @MaCV
	drop index idx_MaCV_7363 on NhanVien
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKe]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaKe] @MaKhuVuc int
as
	update NguyenLieu
	set MaKhuVuc = null
	where MaKhuVuc = @MaKhuVuc

	delete KhoNguyenLieu
	where MaKhuVuc = @MaKhuVuc
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaKM]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaKM] @MaKM int
as
	DELETE from KhuyenMai where MaDotKhuyenMai = @MaKM
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaLichLam]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaLichLam] @MaPC int
as
	delete PhanCong
	Where MaPC = @MaPC
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNCC]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_XoaNCC] @MaNCC int
as 
	update NhaCungCap
	set TrangThai = 0
	where MaNCC = @MaNCC
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaNhanVien]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaNhanVien] @MaNV int
as
	declare @TenDangNhap varchar(25)
	select @TenDangNhap = TenDangNhap
	from NhanVien
	where MaNV = @MaNV
	delete from TaiKhoan
	where TenDangNhap = @TenDangNhap
	update NhanVien set TrangThai = 0, MaCV = NULL where MaNV = @MaNV
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaSP]    Script Date: 5/1/2025 6:34:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_XoaSP] @MaHH int
as
update HangHoa
set TrangThai = 0, MaDotKhuyenMai = null
where MaHH = @MaHH
GO
