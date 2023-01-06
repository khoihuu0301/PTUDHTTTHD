--drop table MonHoc
create table MonHoc --xem, t?o, detail, xóa
(
	MaMH int identity(1,1),
	TenMH nvarchar(100),
	MoTa nvarchar(100),
	MucTieu nvarchar(100),
	active bit,
	CONSTRAINT [PK_MonHoc] PRIMARY KEY CLUSTERED 
	(
		[MaMH] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--drop table KhoaHoc
create table KhoaHoc --xem, xóa,
(
	MaKH int identity(1,1),
	MaMH int,
	MaNHD varchar(100),
	CachDanhGia nvarchar(20),
	NgayBatDau datetime,
	NgayKetThuc datetime,
	active bit,
	CONSTRAINT [PK_KhoaHoc] PRIMARY KEY CLUSTERED 
	(
		[MaKH] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

--drop table NguoiHuongDan
create table NguoiHuongDan
(
	MaNHD varchar(100),
	TenNHD nvarchar(50),
	ChucVu nvarchar(100),
	SDT_NHD char(10),
	DiaChi_NHD nvarchar(100),
	Email_NHD varchar(50),
	active bit
)

--drop table HocVien
create table HocVien
(
	MaHV varchar(100),
	TenHV nvarchar(100),
	SDT_HV char(10),
	DiaChi_HV nvarchar(100),
	Email_HV nvarchar(100),
	ChucVu nvarchar(100),
	active bit
)
--drop table LopHoc
create table LopHoc
(
	MaKH int,
	MaHV varchar(100),
	Diem float,
	TrangThai int,
	active bit
)

--drop table NguoiDung
create table NguoiDung
(	UserID int identity(1,1),
	TenDangNhap varchar(100),
	MatKhau varchar(100),
	UserRole int,
	active bit
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
	where kh.active = 1
end

create or alter procedure [dbo].[sp_CreateMonHoc] @tenmh nvarchar(100), @mota nvarchar(100), @muctieu nvarchar(100)
as
begin
	insert into MonHoc(TenMH, MoTa, MucTieu,active) values (@tenmh,@mota,@muctieu,1)
end

create or alter procedure [dbo].[sp_GetAllLopHoc]
as
begin
	select MaKH, lh.MaHV, TenHV, Diem, TrangThai from LopHoc lh WITH(nolock) join HocVien hv on lh.MaHV = hv.MaHV
	where lh.active = 1
end
