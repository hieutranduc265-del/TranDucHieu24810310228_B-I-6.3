CREATE DATABASE HRMDB;
GO
USE HRMDB;
GO

-- 1. Bảng Phòng Ban
CREATE TABLE PhongBan (
    MaPB INT IDENTITY(1,1) PRIMARY KEY,
    TenPB NVARCHAR(100) NOT NULL,
    Mota NVARCHAR(255)
);

-- 2. Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATETIME,
    CCCD VARCHAR(20) UNIQUE,
    MaPB INT FOREIGN KEY REFERENCES PhongBan(MaPB),
    LuongCoBan DECIMAL(18,2) CHECK (LuongCoBan > 0),
    HeSoLuong FLOAT DEFAULT 1.0
);

-- 3. Bảng Chấm Công (Hàng tháng)
CREATE TABLE BangChamCong (
    MaCong INT IDENTITY(1,1) PRIMARY KEY,
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    ThangNam VARCHAR(7), -- Định dạng: "11/2026"
    SoNgayCong FLOAT CHECK (SoNgayCong <= 31),
    SoGioOT FLOAT DEFAULT 0
);

-- 4. Bảng Lương Chi Tiết
CREATE TABLE BangLuong (
    MaLuong INT IDENTITY(1,1),
    MaNV INT FOREIGN KEY REFERENCES NhanVien(MaNV),
    ThangNam VARCHAR(7),
    ThucLinh DECIMAL(18,2),
    PRIMARY KEY (MaNV, ThangNam)
);
GO

INSERT INTO PhongBan (TenPB, Mota) VALUES (N'Phòng Kỹ Thuật', N'IT & Software'), (N'Phòng Kinh Doanh', N'Sales');
INSERT INTO NhanVien (HoTen, NgaySinh, CCCD, MaPB, LuongCoBan, HeSoLuong) 
VALUES 
(N'Nguyễn Văn A', '2000-05-12', '001200012345', 1, 8000000, 1.2),
(N'Trần Thị B', '2001-08-20', '001200054321', 2, 6000000, 1.0);
GO