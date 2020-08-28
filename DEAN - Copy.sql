	CREATE DATABASE QUANLYVEXE
	GO
	USE QUANLYVEXE
	GO
	CREATE TABLE ACCOUNT
	(
		Username NVARCHAR(30) NOT NULL DEFAULT N'Ten',
		Email NVARCHAR(30) NOT NULL DEFAULT 0,
		password  NVARCHAR(30) NOT NULL DEFAULT 0 ,
		typ INT NOT NULL DEFAULT 0
	)
	INSERT INTO dbo.ACCOUNT
	VALUES (N'Trung Tu', N'tn3962045@gmail.com', N'123', 1 )
	SELECT * FROM dbo.ACCOUNT
	GO
	CREATE PROC USP_LOGIN  --load csdl lên để kiểm tra login
	@Username NVARCHAR(30), @password NVARCHAR(30)
	AS
	BEGIN
		SELECT * FROM dbo.ACCOUNT WHERE Username = @Username AND password = @password
	END
	GO
	CREATE PROC USP_thongtin  --load csdl lên để hienthi
	@Username NVARCHAR(30),@Email NVARCHAR(30), @password NVARCHAR(30), @typ  INT
	AS
	BEGIN
		SELECT * FROM dbo.ACCOUNT WHERE Username = @Username AND Email = @Email AND password = @password  AND typ = @typ
	END
	GO
