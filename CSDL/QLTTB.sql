CREATE DATABASE QLTTB
GO

USE QLTTB
GO

-- Account
CREATE TABLE Account (
	Id INT IDENTITY PRIMARY KEY,
	Ten_dang_nhap NVARCHAR(50) UNIQUE NOT NULL ,
	Mat_khau NVARCHAR(1000) NOT NULL,
	Quyen_truy_cap INT NOT NULL
);

-- Thong tin nguoi dang nhap
CREATE TABLE Thong_tin_nguoi_dang_nhap (
	Id INT IDENTITY PRIMARY KEY,
	Ma_nql VARCHAR(50) UNIQUE NOT NULL,
	Ten NVARCHAR(50) NOT NULL,
	Ngay_sinh DATETIME NOT NULL,
	Gioi_tinh NVARCHAR(10) NOT NULL,
	Chuc_vu NVARCHAR(50) NOT NULL,
	Email VARCHAR(50),
	SDT VARCHAR(20) NOT NULL,
	Dia_chi NVARCHAR(100) NOT NULL,
	Phong_cong_tac NVARCHAR(10) NOT NULL,
	Account_Id INT UNIQUE NOT NULL,
    FOREIGN KEY (Account_Id) REFERENCES Account(Id)
);

-- Hang
CREATE TABLE Hang (
	Id INT IDENTITY PRIMARY KEY,
	Ma_hang VARCHAR(50) UNIQUE NOT NULL,
	Ten_hang NVARCHAR(50) NOT NULL,
	Lien_He_tong_dai VARCHAR(20) NOT NULL,
	Ghi_chu NVARCHAR(100)
);

-- Loai thiet bi
CREATE TABLE Loai_TB (
	Id INT IDENTITY PRIMARY KEY,
	Ma_loai VARCHAR(50) UNIQUE NOT NULL,
	Ten_loai NVARCHAR(50) NOT NULL,
	Ma_hang VARCHAR(50) NOT NULL,
	Ghi_chu NVARCHAR(100),
	FOREIGN KEY (Ma_hang) REFERENCES Hang(Ma_hang)
);

-- Can bo quan ly
CREATE TABLE Can_Bo_QL (
	Id INT IDENTITY PRIMARY KEY,
	Ma_cbql VARCHAR(50) UNIQUE NOT NULL,
	Ten NVARCHAR(50) NOT NULL,
	Ngay_sinh DATETIME NOT NULL,
	Gioi_tinh NVARCHAR(10) NOT NULL,
	Dia_chi NVARCHAR(100) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Chuc_vu NVARCHAR(50) NOT NULL,
	Ghi_chu NVARCHAR(100)
);


-- Phong ban
CREATE TABLE Phong_Ban (
	Id INT IDENTITY PRIMARY KEY,
	Ma_phong VARCHAR(50) UNIQUE NOT NULL,
	Ten_phong NVARCHAR(50) NOT NULL,
	Dia_chi NVARCHAR(100) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	So_dien_thoai  VARCHAR(10) NOT NULL,
	Ma_cbql VARCHAR(50) NOT NULL,
	Ghi_chu NVARCHAR(100),
	FOREIGN KEY (Ma_cbql) REFERENCES Can_Bo_QL(Ma_cbql)
);

-- Thiet bi
CREATE TABLE Thiet_Bi (
	Id INT IDENTITY PRIMARY KEY,
	Ma_tb VARCHAR(50) UNIQUE NOT NULL,
	Ten_tb NVARCHAR(50) NOT NULL,
	So_luong INT,
	Ngay_nhap DATETIME NOT NULL,
	Trang_thai NVARCHAR(50) NOT NULL,
	Ma_loai VARCHAR(50) NOT NULL,
	Ma_Phong_Ban VARCHAR(50) NOT NULL,
	Ghi_chu NVARCHAR(3000),
	FOREIGN KEY (Ma_loai) REFERENCES Loai_TB(Ma_loai),
	FOREIGN KEY (Ma_Phong_Ban) REFERENCES Phong_Ban(Ma_phong)
);

-- Thong ke
CREATE TABLE Thong_Ke_TB (
	Id INT IDENTITY PRIMARY KEY,
	Ma_tb VARCHAR(50) NOT NULL,
	Ten_tb NVARCHAR(50) NOT NULL,
	So_luong INT NOT NULL,
	Ngay_nhap DATETIME NOT NULL,
	Trang_thai NVARCHAR(50) NOT NULL,
	Ma_loai VARCHAR(50) NOT NULL,
	Ma_Phong_Ban VARCHAR(50) NOT NULL,
	Ghi_chu NVARCHAR(3000),
	Ngay_cap_nhat DATETIME NOT NULL,
	Ghi_chu_ng_cn NVARCHAR(3000),
	FOREIGN KEY (Ma_loai) REFERENCES Loai_TB(Ma_loai),
	FOREIGN KEY (Ma_Phong_Ban) REFERENCES Phong_Ban(Ma_phong)
);




----------
GO
----------


---------------------------
-- Cac ham thuat toan xu ly

-- Tim kiem tai khoan dang nhap
CREATE PROC USP_Login
@userName nvarchar(50), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM Account WHERE Ten_dang_nhap = @userName AND Mat_khau = @passWord
END
GO

-- Cap nhap lai thong tin tai khoan
CREATE PROC USP_UpdateAccount
@userName NVARCHAR(50), @passWord NVARCHAR(1000), @newpassWord NVARCHAR(1000) 
AS
BEGIN
	
	DECLARE @isRightPass INT = 0

	SELECT @isRightPass = COUNT(*) FROM Account WHERE Ten_dang_nhap = @userName AND Mat_khau = @passWord

	IF(@isRightPass = 1) 
	BEGIN
		UPDATE  Account SET Mat_khau = @newpassWord WHERE Ten_dang_nhap = @userName
	END
END
GO


-- Tim kiem


CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
GO


----------------------------
---Insert thong tin cac bang
----------------------------

-- Them tai khoan nguoi quan ly 
INSERT INTO Account(Ten_dang_nhap, Mat_khau, Quyen_truy_cap) VALUES (N'admin', '3623', 1)

INSERT INTO Account(Ten_dang_nhap, Mat_khau, Quyen_truy_cap) VALUES (N'customer', '12345', 0)

SELECT * FROM Account
GO


-- Them thong tin nguoi dang nhap
INSERT INTO Thong_tin_nguoi_dang_nhap (Ma_nql, Ten, Ngay_sinh, Gioi_tinh, Chuc_vu, Email, SDT, Dia_chi, Phong_cong_tac, Account_Id)
VALUES ('NQL01', N'Phung Van D', '2003-06-03', N'Nam', N'Quản lý', 'phungvan***@gmail.com', '034536***', N'**, **, TP TH', N'ATTT01', 1);

INSERT INTO Thong_tin_nguoi_dang_nhap (Ma_nql, Ten, Ngay_sinh, Gioi_tinh, Chuc_vu, Email, SDT, Dia_chi, Phong_cong_tac, Account_Id)
VALUES ('ND02', N'Nguyen Van A', '2023-05-01', N'Nam', N'Người Dùng', 'nguyenvan2923***@gmail.com', '03678***', N'**, **, TP HN', N'PH03', 2);

SELECT * FROM Thong_tin_nguoi_dang_nhap 
GO

-- Them thong tin Hang san xuat
INSERT INTO Hang (Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu)
VALUES ('Ap01', N'Apple', '19001234', N'Đến từ: Mỹ');

INSERT INTO Hang (Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu)
VALUES ('Ss02', N'Samsung', '19001235', N'Đến từ: Hàn Quốc');

INSERT INTO Hang (Ma_hang, Ten_hang, Lien_He_tong_dai, Ghi_chu)
VALUES ('Sy03', N'Sony', '19001236', N'Đến từ: Nhật Bản');

SELECT * FROM Hang
GO

-- Them thong tin Loại thiết bị
INSERT INTO Loai_TB (Ma_loai, Ten_loai, Ma_hang, Ghi_chu)
VALUES ('MTap01', N'MacBook', 'Ap01', N'Laptop, thông số, bảo hành');

INSERT INTO Loai_TB (Ma_loai, Ten_loai, Ma_hang, Ghi_chu)
VALUES ('MTss02', N'Samsung Galaxy Book Odyssey', 'Ss02', N'Laptop, thông số, bảo hành');

INSERT INTO Loai_TB (Ma_loai, Ten_loai, Ma_hang, Ghi_chu)
VALUES ('MCsn01', N'Sony ***', 'Sy03', N'Loại máy chiếu, thông số, bảo hành');

INSERT INTO Loai_TB (Ma_loai, Ten_loai, Ma_hang, Ghi_chu)
VALUES ('DTap01', N'IPhone', 'Ap01', N'Phone, thông số, bảo hành');

SELECT * FROM Loai_TB
GO

-- Them thong tin Can bo quan ly
INSERT INTO Can_Bo_QL (Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu)
VALUES ('CB001', N'Nguyễn Văn A', '2003-01-01', N'Nam', N'**, Quận Thanh Xuân, TP. HN', '0123456789', 'nva@hunre.edu.vn', N'Trưởng phòng', N'Chức vụ mới được bổ nhiệm');

INSERT INTO Can_Bo_QL (Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu)
VALUES ('CB002', N'Lê Văn B', '2003-01-02', N'Nam', N'**, Quận Bắc Từ Liêm, TP. HN', '0987654321', 'lvb@hunre.edu.vn', N'Phó phòng', N'Kiêm nhân viên kĩ thuật');

INSERT INTO Can_Bo_QL (Ma_cbql, Ten, Ngay_sinh, Gioi_tinh, Dia_chi, SDT, Email, Chuc_vu, Ghi_chu)
VALUES ('CB003', N'Lê Thi C', '1999-05-15', N'Nữ', N'**, Quận Nam Từ, TP. HN', '0987654310', 'ltc@hunre.edu.vn', N'Trưởng phòng', N'Kiêm kế toán');

SELECT * FROM Can_Bo_QL
GO

-- Them thong tin Phong ban
INSERT INTO Phong_Ban (Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu)
VALUES ('PB001', N'A203', N'Tòa A, Trường đại học Tài Nguyền và Môi Trường Hà Nội', 'phong_mayA203@hunre.edu.vn', '0901234567', 'CB001', N'Mở cửa: từ 8h-20h/7');

INSERT INTO Phong_Ban (Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu)
VALUES ('PB002', N'B101', N'Tòa B, Trường đại học Tài Nguyền và Môi Trường Hà Nội', 'phong_kho@hunre.edu.vn', '0901234568', 'CB002', N'Mở cửa: từ 8h-17h/7 ');

INSERT INTO Phong_Ban (Ma_phong, Ten_phong, Dia_chi, Email, So_dien_thoai, Ma_cbql, Ghi_chu)
VALUES ('PB003', N'C201', N'Tòa C, Trường đại học Tài Nguyền và Môi Trường Hà Nội', 'phong_muonTB_C201@hunre.edu.vn', '0901236868', 'CB003', N'Mở cửa: từ 8h-17h/7 ');

SELECT * FROM Phong_Ban
GO

-- Them thông tin thiet bi
INSERT INTO Thiet_Bi (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu)
VALUES ('MTmcP01', N'MacBook Pro', 10, '2022-01-01', N'Sẵn sàng', 'MTap01', 'PB003', N'Dành cho cán bộ nhà trường');

INSERT INTO Thiet_Bi (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu)
VALUES ('MTdbss02', N'Máy tính để bàn', 30, '2022-01-02', N'Đang sử dụng', 'MTss02', 'PB001', N'Cho mọi người sử dụng');

INSERT INTO Thiet_Bi (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu)
VALUES ('DT001', N'IPhone 14 Pro Max', 50, '2023-05-05', N'Đang cất ở kho', 'DTap01', 'PB002', N'Thiết bị dành tặng cho sv');

INSERT INTO Thiet_Bi (Ma_tb, Ten_tb, So_luong, Ngay_nhap, Trang_thai, Ma_loai, Ma_Phong_Ban, Ghi_chu)
VALUES ('MC013', N'May chiếu', 60, '2022-06-03', N'Sẵn sàng', 'MCsn01', 'PB003', N'Thiết bị cho mượn');

SELECT * FROM Thiet_Bi 
GO

UPDATE Thong_tin_nguoi_dang_nhap
SET Ten = N'Nguyen Van A', Email = 'nguyenvan2923***@hunre.edu.vn', SDT = '0123456789', Dia_chi = N'**,**, TP.HN'
WHERE Ma_nql = 'ND02';
