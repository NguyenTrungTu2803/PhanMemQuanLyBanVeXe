	CREATE DATABASE Acount
	GO
	USE Acount
	GO
	CREATE TABLE ACCOUNTDAILY
	(
		Id NVARCHAR(30) NOT NULL,
		username NVARCHAR(30) NOT NULL,
		Name NVARCHAR(30) NOT NULL,
		password NVARCHAR(30) NOT NULL,
		GioiTinh NVARCHAR(5),
		SDT NVARCHAR(12),
		IDLoaiND NVARCHAR(30) NOT NULL
	)
	GO

	Create Table LoaiNguoiDung
	(
		IDLoaiND NVARCHAR(30) not null,
		TenLoaiND NVARCHAR(30) not null
	)
	Go

	Create Table PhanQuyen
	(
		IdNhanVien NVARCHAR(30) not null,
		Xe int not null,
		TuyenXe int not null,
		ThoiDiem int not null,
		ChuyenXe int not null,
		BanVe int not null
	)
	Go

	Create Table Xe
	(
		So_Xe NVARCHAR(8) NOT NULL,
		Hieu_Xe NVARCHAR(50),
		Doi_Xe NVARCHAR(4),
		So_Cho_Ngoi INT
	)
	Go

	Create Table ChoNgoi
	(
		IdChuyen NVARCHAR(30) NOT NULL,
		So_Xe NVARCHAR(8) NOT NULL,
		TenChoNgoi NVARCHAR(10)NOT NULL
	)
	Go

	Create Table ChuyenXe
	(
		IdChuyen NVARCHAR(30) not null,
		IdTuyen NVARCHAR(30),
		NgayDi DATETIME,
		Gio NVARCHAR(10),
		So_Xe NVARCHAR(8)
	)
	Go
	Create Table TuyenXe
	(
		IdTuyen	NVARCHAR(30) not null,
		TenTuyen NVARCHAR(30) unique,
		DiaDiemDi NVARCHAR(30),
		DiaDiemDen NVARCHAR(30)
	)
	Go
	Create Table DiaDiem
	(
		IdDiaDiem Nvarchar(30) not null,
		TenDiaDiem nvarchar(30) not null
	)
	Go
	Create Table ChiTietTuyen
	(
		IdTuyen	NVARCHAR(30) not null,
		IdThoiDiem NVARCHAR(30) not null
	)
	Go
	Create Table ThoiDiem
	(
		IdThoiDiem NVARCHAR(30) not null,
		Ngay DATETIME not null,
		Gio NVARCHAR(10) not null,
	)
	Go

	Create Table BanVe
	(
		IdVe NVARCHAR(30) not null,
		IdChuyen NVARCHAR(30),
		TenHanhKhach NVARCHAR(30),
		SDTHanhKhach INT
	)
	Go
	-------------------------------Tạo Hàm--------------------------------------------------------
	----------------Tạo hàm tăng tự động cho IdThoiDiem-----------------------
	CREATE FUNCTION Addmaso(@makt char(2))
	RETURNS char(6)
	AS
	BEGIN 
		DECLARE @iMaso int 
  		DECLARE @vMaso varchar(9) 
  		IF @makt='TD' SET @iMaso= (SELECT MAX(RIGHT(IdThoiDiem, 4)) FROM ThoiDiem)  	
		IF (@iMaso IS NULL) SET @vMaso= @makt+ CONVERT(varchar(6),'0001')
		ELSE
		BEGIN
			SET @iMaso= @iMaso+1
	    		SET @vMaso= '000'+ CONVERT(varchar,@iMaso) 
	    		SET @vMaso= @makt+ RIGHT(@vMaso,4)
		END
	RETURN @vMaso 
	END
	go
---------------------------------------- Tạo khóa chính ---------------------------------------------
	Alter Table ACCOUNTDAILY
	Add constraint pk_ACCOUNTDAILY Primary Key (Id)

	Alter table PhanQuyen
	Add Constraint pk_PhanQuyen Primary Key(IdNhanVien, Xe, TuyenXe, ThoiDiem, ChuyenXe, BanVe)

	Alter table LoaiNguoiDung 
	Add Constraint pk_LoaiNguoiDung Primary Key(IDLoaiND)

	Alter table Xe 
	Add Constraint pk_Xe Primary Key(So_Xe)

	Alter Table ChoNgoi
	Add Constraint pk_ChoNgoi Primary Key(IdChuyen, So_Xe, TenChoNgoi)

	Alter Table ChuyenXe
	Add Constraint pk_ChuyenXe Primary Key(IdChuyen)

	Alter table ChiTietTuyen
	Add constraint pk_ChiTietTuyen primary key(IdTuyen, IdThoiDiem)

	Alter table TuyenXe 
	Add constraint pk_TuyenXe primary key(IdTuyen)

	Alter Table ThoiDiem
	Add Constraint pk_ThoiDiem Primary Key(IdThoiDiem)

	Alter table DiaDiem
	Add constraint pk_DiaDiem primary key(IdDiaDiem)

	Alter table BanVe 
	Add constraint pk_BanVe primary key(IdVe)

-------------------------------------------Tạo khóa ngoại --------------------------------------------
	Alter table ACCOUNTDAILY 
	Add constraint fk_ACCOUNTDAILY_LoaiNguoiDung foreign key(IDLoaiND) references LoaiNguoiDung(IDLoaiND)
	Go
																																			   
	Alter table PhanQuyen
	Add constraint fk_PhanQuyen_ACCOUNTDAILY foreign key(IdNhanVien) references ACCOUNTDAILY(Id)
	Go

	Alter Table ChoNgoi
	Add Constraint fk_ChoNgoi_Xe Foreign Key(So_Xe) References Xe(So_Xe)

	Alter Table ChoNgoi
	Add Constraint fk_ChoNgoi_ChuyenXe Foreign Key(IdChuyen) References ChuyenXe(IdChuyen)

	Alter table ChuyenXe 
	Add constraint fk_ChuyenXe_Xe foreign key(So_Xe) references Xe(So_Xe)

	Alter table ChuyenXe 
	Add constraint fk_ChuyenXe_TuyenXe foreign key(IdTuyen) references TuyenXe(IdTuyen)

	Alter table ChiTietTuyen 
	Add constraint fk_ChiTietTuyen_TuyenXe foreign key(IdTuyen) references TuyenXe(IdTuyen)

	Alter table ChiTietTuyen 
	Add constraint fk_ChiTietTuyen_ThoiDiem foreign key(IdThoiDiem) references ThoiDiem(IdThoiDiem)

	Alter table BanVe
	Add constraint fk_BanVe_ChuyenXe foreign key(IdChuyen) references ChuyenXe(IdChuyen)

----------------------------------- Thêm giá trị vào bảng -------------------------------------------
	Insert Into LoaiNguoiDung values('Admin',N'Administrator')
	Insert Into LoaiNguoiDung values('Quan_Ly',N'Quản Lý')
	Insert Into LoaiNguoiDung values('Nhan_Vien',N'Nhân Viên')

	INSERT INTO dbo.ACCOUNTDAILY VALUES (N'DH002', N'Hoang Thien', N'Nguyễn Hoàng Thiên', N'1234', N'Nam', N'0961980388', N'Quan_Ly')
	INSERT INTO dbo.ACCOUNTDAILY VALUES (N'DH003', N'Công Cường', N'Nguyễn Công Cường', N'4321', N'Nam', N'01663408024', N'Nhan_Vien')
	INSERT INTO dbo.ACCOUNTDAILY VALUES (N'DH001', N'Trung Tu', N'Nguyễn Trung Tú', N'123', N'Nam', N'0935361115', N'Admin')
	INSERT INTO dbo.ACCOUNTDAILY VALUES (N'DH004', N'Pha Lê', N'Nguyễn Thị Pha Lê', N'12345', N'Nữ', N'0369784521', N'Quan_Ly')

	----------------------Thêm vào bảng Xe--------------------------------------------------------
	INSERT INTO dbo.Xe VALUES ('55Y-7777', 'Ford Transit', '2010', '16')
	INSERT INTO dbo.Xe VALUES('52N-3333', 'Huyndai Country', '2008', '30')
	INSERT INTO dbo.Xe VALUES('50Y-3669', 'Toyota', '2009', '16')
	INSERT INTO dbo.Xe VALUES('53Y-7788', 'Ford Everest', '2009', '7')
	INSERT INTO dbo.Xe VALUES('50S-2934', 'Hyundai Country', '2017', '25')
	INSERT INTO dbo.Xe  VALUES('54H-1234', 'Hyundai Country', '2008', '30')
	INSERT INTO dbo.Xe  VALUES('50S-9999', 'Huyndai', '2003', '45')

	----------------------Thêm vào bảng Tuyến Xe-------------------------------------------------
	INSERT INTO dbo.TuyenXe VALUES ('001',N'Sài Gòn - Nha Trang', N'Sài Gòn', N'Nha Trang')
	INSERT INTO dbo.TuyenXe VALUES ('002',N'Sài Gòn - Đà Lạt', N'Sài Gòn', N'Đà Lạt')
	INSERT INTO dbo.TuyenXe VALUES ('003',N'Sài Gòn - Cần Thơ', N'Sài Gòn', N'Cần Thơ')
	INSERT INTO dbo.TuyenXe VALUES ('004',N'Sài Gòn - Tây Ninh', N'Sài Gòn', N'Tây Ninh')
	INSERT INTO dbo.TuyenXe VALUES ('005',N'Sài Gòn - Phan Thiết', N'Sài Gòn', N'Phan Thiết')
	INSERT INTO dbo.TuyenXe VALUES ('006',N'Sài Gòn - Kon Tum', N'Sài Gòn', N'Kon Tom')
	INSERT INTO dbo.TuyenXe VALUES ('007',N'Sài Gòn - Bình Thuận', N'Sài Gòn', N'Bình Thuận')
	INSERT INTO dbo.TuyenXe VALUES ('007',N'Sài Gòn - Kiên Giang', N'Sài Gòn', N'Kiên Giang')
	INSERT INTO dbo.TuyenXe VALUES ('008',N'Sài Gòn - Bạc Liêu', N'Sài Gòn', N'Bạc Liêu')
	INSERT INTO dbo.TuyenXe VALUES ('009',N'Sài Gòn - Quảng Ngãi', N'Sài Gòn', N'Quảng Ngãi')

------------------Goi ham tu dong tang ma thoi diem cho bang thoi diem-------------------------------------------
	ALTER TABLE ThoiDiem ADD CONSTRAINT def_ThoiDiem DEFAULT dbo.Addmaso('TD') FOR IdThoiDiem
	GO
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/12', '5h35')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/12', '8h')
	INSERT INTO ThoiDiem(Ngay, Gio)  VALUES('2018/01/12', '12h')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/13', '6h')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/13', '9h')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/13', '13h')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/13', '15h')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/14', '8h30')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/14', '10h')															
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/15', '11h15')
	INSERT INTO ThoiDiem(Ngay, Gio) VALUES('2018/01/14', '13h')
		
	INSERT INTO DiaDiem values('SG',N'Sài gòn')
	INSERT INTO DiaDiem values('DL',N'Đà lạt')
	INSERT INTO DiaDiem values('NT',N'Nha trang')
	INSERT INTO DiaDiem values('CT',N'Cần thơ')
	INSERT INTO DiaDiem values('BL',N'Bạc liêu')
	INSERT INTO DiaDiem values('TN',N'Tây ninh')
	INSERT INTO DiaDiem values('KT',N'Kom tum')
	INSERT INTO DiaDiem values('PT',N'Phan thiết')
	INSERT INTO DiaDiem values('VT',N'Vũng tàu')
	INSERT INTO DiaDiem values('KG',N'Kiên giang')
	INSERT INTO DiaDiem values('QN',N'Quảng Ngãi')

	Insert into ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values('001', '55Y-7777', '2018/01/12', '5h35')
	Insert into ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values('001', '53Y-7788', '2018/01/14', '8h30')
	Insert into ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values('005', '50S-2934', '2018/01/13', '15h')
	Insert into ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values('008', '52N-3333', '2018/01/14', '13h')
	Insert into ChuyenXe(IdTuyen, So_Xe, NgayDi, Gio) Values('008', '54H-1234', '2018/01/14', '6h')

	insert into ChiTietTuyen values('001','TD0001')
	insert into ChiTietTuyen values('001','TD0008')
	insert into ChiTietTuyen values('002', 'TD0002')
	insert into ChiTietTuyen values('003', 'TD0006')
	insert into ChiTietTuyen values('004','TD0004') 
	insert into ChiTietTuyen values('005','TD0007') 
	insert into ChiTietTuyen values('006','TD0006')
	insert into ChiTietTuyen values('007','TD0008')
	insert into ChiTietTuyen values('008','TD0011')
	insert into ChiTietTuyen values('009','TD0009')
	insert into ChiTietTuyen values('001','TD0010')
	insert into ChiTietTuyen values('002','TD0005')
	insert into ChiTietTuyen values('006','TD0007')
	insert into ChiTietTuyen values('005','TD0003')

-----------------------------------------------------------------------------------------------------------------------------------
	--Select * from ACCOUNTDAILY
	Select * from ThoiDiem
	--Delete from dbo.Xe Where So_Cho_Ngoi = 25; 
	--Select *from dbo.PhanQuyen
	--Select *from dbo.LoaiNguoiDung
	--Select IDLoaiND from LoaiNguoiDung
	--Select *from dbo.Xe
	--Select *from dbo.ChiTietTuyen
	--Select IdTuyen From TuyenXe
	--Select * From ChiTietTuyen
	--Select TenTuyen From TuyenXe
	--Delete ChiTietTuyen From TuyenXe, ThoiDiem Where ChiTietTuyen.IdTuyen = '002' and TuyenXe.IdTuyen = '002' and ThoiDiem.IdThoiDiem = 'TD0002' and ChiTietTuyen.IdThoiDiem = 'TD0002'
	--Select TuyenXe.IdTuyen, ChiTietTuyen.IdThoiDiem, ThoiDiem.Ngay, ThoiDiem.Gio, TuyenXe.TenTuyen From TuyenXe Join ChiTietTuyen on (TuyenXe.IdTuyen = ChiTietTuyen.IdTuyen) Join ThoiDiem on (ThoiDiem.IdThoiDiem = ChiTietTuyen.IdThoiDiem)