create database NEWDAY_MARKET
GO
USE NEWDAY_MARKET
GO

CREATE TABLE NHANVIEN(
	IDUSER INT not null,
	HOTEN nvarchar(50) not null,
	PHAI bit,
	DIACHI nvarchar(100),
	SDT char(20),
	NGAYSINH datetime,
	EMAIL nvarchar(50),
	CMND char(20),
	ISENABLED BIT,
	primary key (IDUSER)
)
GO
CREATE TABLE QUANLY(
	STT INT identity(1,1),
	IDUSER INT NOT NULL,
	primary key (STT)
)
GO
CREATE TABLE THUONG(
	STT INT identity(1,1),
	IDUSER INT NOT NULL,
	primary key (STT)
)


CREATE TABLE USER_ACCOUNT(
	IDUSER INT,
	TENDANGNHAP VARCHAR(50),
	MATKHAU VARCHAR(50),
	USER_TYPE BIT,
	IS_USING BIT,
	primary key (TENDANGNHAP)
)
GO

alter table USER_ACCOUNT add
	constraint FK_USER_ACCOUNT_QUANLY foreign key (IDUSER) references NHANVIEN (IDUSER)
GO

alter table THUONG add
	constraint FK_THUONG_NHANVIEN foreign key (IDUSER) references NHANVIEN (IDUSER)
GO

alter table QUANLY add
	constraint FK_QUANLY_NHANVIEN foreign key (IDUSER) references NHANVIEN (IDUSER)
GO

Create table SANPHAM(
	MASP VARCHAR(10) NOT NULL,
	TENSP NVARCHAR(50),
	MALOAI int,
	NSX DATETIME,	
	THOIHAN DATETIME,
	THUONGHIEU NVARCHAR(50),
	GIATIEN decimal(19,4),
	SLTONKHO REAL,
	SLBB REAL,
	TINHTRANG NVARCHAR(50),
	PRIMARY KEY (MASP)
)
GO
create table CHIETKHAU(
	STT int identity(1,1),
	MASP VARCHAR(10) NOT NULL,
	CK real,
	THOIGIANBD DATETIME,
	THOIGIANKT DATETIME,
	TENLOAI NVARCHAR(50),
	PRIMARY KEY (STT)
)
GO

CREATE TABLE LOAISANPHAM(
	MALOAI int identity(1,1),
	TENLOAI NVARCHAR(50) not null,
	MASP VARCHAR(10) not null,
	PRIMARY KEY(MALOAI)
)
GO

CREATE TABLE PHIEUNHAPHANG(
	STT int identity(1,1),
	MASP VARCHAR(10),
	SL int,
	primary key(STT)
)
GO

CREATE TABLE PHIEUXUATHANG(
	STT int identity(1,1),
	MASP VARCHAR(10),
	SL int,
	primary key(STT)
)
GO

CREATE TABLE HOADON(
	MAHD int identity(1,1),
	NGAYTT DATETIME,
	MAKHTT varchar(10),
	TONGTIEN decimal(19,4),
	primary key(MAHD)
)
GO

CREATE TABLE CHITIETHOADON(
	STT int identity(1,1),
	MAHD int,
	MASP VARCHAR(10) not null,
	SL int not null,
	DONGIA decimal(19,4),
	CHIETKHAU real,
	MAKHTT int,
	THANHTIEN decimal(19,4),
	primary key(STT)
)
GO

CREATE TABLE KHTT(
	MAKHTT int identity(1000,1),
	CMND char(20),
	SDT char(20),
	BAC int,
	THOIHAN DATETIME,
	TIENTL real,
	primary key(MAKHTT)
)

alter table CHIETKHAU add
	constraint FK_CHIETKHAU_SANPHAM foreign key (MASP) references SANPHAM (MASP)
GO
alter table SANPHAM add
	constraint FK_SANPHAM_LOAISANPHAM foreign key (MALOAI) references LOAISANPHAM (MALOAI)
GO
alter table PHIEUNHAPHANG add
	constraint FK_PHIEUNHAPHANG_SANPHAM foreign key (MASP) references SANPHAM (MASP)
GO
alter table PHIEUXUATHANG add
	constraint FK_PHIEUXUATHANG_SANPHAM foreign key (MASP) references SANPHAM (MASP)
GO
alter table CHITIETHOADON add
	constraint FK_CHITIETHOADON_HOADON foreign key (MAHD) references HOADON (MAHD)
GO
alter table CHITIETHOADON add
	constraint FK_CHITIETHOADON_SANPHAM foreign key (MASP) references SANPHAM (MASP)
GO
alter table CHITIETHOADON add
	constraint FK_CHITIETHOADON_KHTT foreign key (MAKHTT) references KHTT (MAKHTT)
GO




insert into NHANVIEN (IDUSER, HOTEN, PHAI, DIACHI, SDT, NGAYSINH, EMAIL, CMND, ISENABLED) values ('001', N'Nguyễn Văn A', 1, N'123', 0922323232, 1/9/2003, 'abc1@xyz.com', 022112222, 1)
insert into NHANVIEN (IDUSER, HOTEN, PHAI, DIACHI, SDT, NGAYSINH, EMAIL, CMND, ISENABLED) values ('002', N'Nguyễn Văn B', 0, N'456', 0844545454, 2/8/2003, 'abc2@xyz.com', 022112223, 1)
insert into NHANVIEN (IDUSER, HOTEN, PHAI, DIACHI, SDT, NGAYSINH, EMAIL, CMND, ISENABLED) values ('003', N'Nguyễn Văn C', 1, N'789', 0766161616, 3/7/2003, 'abc3@xyz.com', 022112224, 1)
insert into NHANVIEN (IDUSER, HOTEN, PHAI, DIACHI, SDT, NGAYSINH, EMAIL, CMND, ISENABLED) values ('004', N'Nguyễn Văn D', 0, N'012', 0399898989, 4/6/2003, 'abc4@xyz.com', 022112225, 1)
insert into NHANVIEN (IDUSER, HOTEN, PHAI, DIACHI, SDT, NGAYSINH, EMAIL, CMND, ISENABLED) values ('005', N'Nguyễn Văn M', 0, N'444', 0888288828, 5/6/2003, 'abc4@xyz.com', 022112226, 0)
GO

insert into QUANLY (IDUSER) values ('001')
insert into QUANLY (IDUSER) values ('002')
insert into THUONG (IDUSER) values ('003')
insert into THUONG (IDUSER) values ('004')
insert into THUONG (IDUSER) values ('005')
GO

insert into USER_ACCOUNT(IDUSER,TENDANGNHAP,MATKHAU,USER_TYPE,IS_USING) values ('001','ql1','123',1,'0')
GO
insert into USER_ACCOUNT(IDUSER,TENDANGNHAP,MATKHAU,USER_TYPE,IS_USING) values ('002','ql2','123',1,'0')
GO
insert into USER_ACCOUNT(IDUSER,TENDANGNHAP,MATKHAU,USER_TYPE,IS_USING) values ('003','nv1','123',0,'0')
GO
insert into USER_ACCOUNT(IDUSER,TENDANGNHAP,MATKHAU,USER_TYPE,IS_USING) values ('004','nv2','123',0,'0')
GO
insert into USER_ACCOUNT(IDUSER,TENDANGNHAP,MATKHAU,USER_TYPE,IS_USING) values ('005','nv3','123',0,'0')
GO

