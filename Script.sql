/*
Created		11/24/2021
Modified		12/4/2021
Project		
Model			
Company		
Author		
Version		
Database		MS SQL 2000 
*/


Create table [HUONGDANVIEN]
(
	[MAHDV] Char(10) NOT NULL,
	[TENHDV] Nvarchar(100) NULL,
	[PHAI] Bit NULL,
	[DIACHI] Nvarchar(100) NULL,
	[SDT] Numeric(13,0) NULL,
Primary Key ([MAHDV])
) 
go

Create table [KHACH]
(
	[MAKHACH] Char(10) NOT NULL,
	[TENKHACH] Nvarchar(100) NULL,
	[PHAI] Bit NULL,
	[DIACHI] Nvarchar(100) NULL,
	[CMND] Numeric(15,0) NULL,
	[SDT] Numeric(15,0) NULL,
Primary Key ([MAKHACH])
) 
go

Create table [KHACHSAN]
(
	[MAKS] Char(10) NOT NULL,
	[MATOUR] Char(10) NOT NULL, UNIQUE ([MATOUR]),
	[TENKS] Nvarchar(100) NULL,
	[DIACHI] Nvarchar(100) NULL,
Primary Key ([MAKS])
) 
go

Create table [TOUR]
(
	[MATOUR] Char(10) NOT NULL,
	[TENTOUR] Nchar(100) NULL,
	[NGAYBD] Datetime NULL,
	[NGAYKT] Datetime NULL,
	[GIA] Money NULL,
	[MAHDV] Char(10) NOT NULL,
	[CHITIETTOUR] Ntext NULL,
	[ANH] Nvarchar(1000) NULL,
Primary Key ([MATOUR])
) 
go

Create table [PHUONGTIEN]
(
	[MAPHUONGTIEN] Char(10) NOT NULL,
	[MATOUR] Char(10) NOT NULL, UNIQUE ([MATOUR]),
	[TENPHUONGTIEN] Nvarchar(100) NULL,
Primary Key ([MAPHUONGTIEN])
) 
go

Create table [DIEMTHAMQUAN]
(
	[MADD] Char(10) NOT NULL,
	[TENDD] Nvarchar(100) NULL,
	[DIACHI] Nvarchar(100) NULL,
	[MOTADIEMDEN] Nvarchar(1000) NULL,
	[ANH] Nvarchar(1000) NULL,
Primary Key ([MADD])
) 
go

Create table [DANGKY]
(
	[MATOUR] Char(10) NOT NULL,
	[MAKHACH] Char(10) NOT NULL,
Primary Key ([MATOUR],[MAKHACH])
) 
go

Create table [ADMIN]
(
	[ID] Char(10) NOT NULL,
	[TENDN] Char(20) NULL,
	[MK] Char(8) NULL,
	[LOAITK] Char(20) NULL,
	[HOTEN] Nvarchar(100) NULL,
	[TRANGTHAI] Char(10) NULL,
Primary Key ([ID])
) 
go

Create table [DANHMUCBLOG]
(
	[MADANHMUCBLOG] Char(10) NOT NULL,
	[TENDANHMUCBLOG] Nvarchar(100) NULL,
Primary Key ([MADANHMUCBLOG])
) 
go

Create table [DEN]
(
	[MATOUR] Char(10) NOT NULL,
	[MADD] Char(10) NOT NULL,
Primary Key ([MATOUR],[MADD])
) 
go

Create table [BLOG]
(
	[MABAIVIET] Char(10) NOT NULL,
	[TIEUDE] Nvarchar(1000) NULL,
	[ANH] Nvarchar(1000) NULL,
	[TOMTAT] Nvarchar(1000) NULL,
	[NOIDUNG] Ntext NULL,
	[NGAYKHOITAO] Datetime NULL,
	[MADANHMUCBLOG] Char(10) NOT NULL,
	[ID] Char(10) NOT NULL,
Primary Key ([MABAIVIET])
) 
go


Alter table [TOUR] add  foreign key([MAHDV]) references [HUONGDANVIEN] ([MAHDV])  on update no action on delete no action 
go
Alter table [DANGKY] add  foreign key([MAKHACH]) references [KHACH] ([MAKHACH])  on update no action on delete no action 
go
Alter table [DANGKY] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [DEN] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [PHUONGTIEN] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [KHACHSAN] add  foreign key([MATOUR]) references [TOUR] ([MATOUR])  on update no action on delete no action 
go
Alter table [DEN] add  foreign key([MADD]) references [DIEMTHAMQUAN] ([MADD])  on update no action on delete no action 
go
Alter table [BLOG] add  foreign key([ID]) references [ADMIN] ([ID])  on update no action on delete no action 
go
Alter table [BLOG] add  foreign key([MADANHMUCBLOG]) references [DANHMUCBLOG] ([MADANHMUCBLOG])  on update no action on delete no action 
go


Set quoted_identifier on
go


Set quoted_identifier off
go


