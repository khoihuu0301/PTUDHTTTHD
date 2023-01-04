create table MonHoc
(
	MaMH int,
	TenMH nvarchar(100),
	MoTa nvarchar(100),
	MucTieu nvarchar(100)
)

create table KhoaHoc
(
	MaKH int,
	MaMH int,
	MaNHD varchar(100),
	CachDanhGia nvarchar(20),
	NgayBatDau datetime,
	NgayKetThuc datetime,
	active bit,
)

create table NguoiHuongDan
(
	MaNHD varchar(100),
	TenNHD nvarchar(50),
	ChucVu nvarchar(100),
	SDT_NHD char(10),
	DiaChi_NHD nvarchar(100),
	Email_NHD varchar(50)
)

create table HocVien
(
	MaHV varchar(100),
	TenHV nvarchar(100),
	SDT_HV char(10),
	DiaChi_HV nvarchar(100),
	Email_HV nvarchar(100)
)

create table LopHoc
(
	MaKH int,
	MaHV varchar(100),
	Diem float,
	TrangThai int,
)

create table NguoiDung
(	UserID int identity(1,1),
	TenDangNhap varchar(100),
	MatKhau varchar(100),
	UserRole int
)

create or alter procedure [dbo].[sp_DeactiveKhoaHoc] @id int
as
begin
	update khoahoc set active=0 where makh=@id
end

create or alter procedure [dbo].[sp_GetAllKhoaHoc]
as
begin
	select MaKH, kh.MaMH, mh.TenMH, nhd.TenNHD, CachDanhGia, NgayBatDau, NgayKetThuc from KhoaHoc kh WITH(nolock) join MonHoc mh on kh.MaMH = mh.MaMH join NguoiHuongDan nhd on nhd.MaNHD = kh.MaNHD
	where active = 1
end
