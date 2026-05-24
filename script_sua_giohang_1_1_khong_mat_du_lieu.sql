USE QuanLyBanVeKhuDuLich;
GO

-- [SCRIPT SUA - 01] Bat dau transaction de dam bao an toan du lieu
SET XACT_ABORT ON;
BEGIN TRAN;

BEGIN TRY
    -- [SCRIPT SUA - 02] Neu 1 nguoi dung co nhieu gio hang, giu lai gio hang cu nhat (MaGioHang nho nhat)
    ;WITH GioHangXepHang AS
    (
        SELECT
            MaGioHang,
            MaNguoiDung,
            ROW_NUMBER() OVER (PARTITION BY MaNguoiDung ORDER BY MaGioHang) AS ThuTuGioHang,
            MIN(MaGioHang) OVER (PARTITION BY MaNguoiDung) AS MaGioHangGiuLai
        FROM GioHang
    ),
    GioHangTrung AS
    (
        SELECT
            MaGioHang AS MaGioHangCu,
            MaGioHangGiuLai
        FROM GioHangXepHang
        WHERE ThuTuGioHang > 1
    )
    -- [SCRIPT SUA - 03] Chuyen toan bo ChiTietGioHang sang gio hang giu lai (khong mat du lieu)
    UPDATE ct
    SET ct.MaGioHang = gt.MaGioHangGiuLai
    FROM ChiTietGioHang ct
    INNER JOIN GioHangTrung gt ON ct.MaGioHang = gt.MaGioHangCu;

    -- [SCRIPT SUA - 04] Xoa cac GioHang bi trung sau khi da chuyen ChiTietGioHang
    ;WITH GioHangCanXoa AS
    (
        SELECT
            MaGioHang,
            ROW_NUMBER() OVER (PARTITION BY MaNguoiDung ORDER BY MaGioHang) AS ThuTuGioHang
        FROM GioHang
    )
    DELETE gh
    FROM GioHang gh
    INNER JOIN GioHangCanXoa gx ON gh.MaGioHang = gx.MaGioHang
    WHERE gx.ThuTuGioHang > 1;

    -- [SCRIPT SUA - 05] Them rang buoc UNIQUE cho MaNguoiDung (quan he 1-1: NguoiDung <-> GioHang)
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE [type] = 'UQ'
          AND [name] = N'UQ_GioHang_MaNguoiDung'
          AND parent_object_id = OBJECT_ID(N'dbo.GioHang')
    )
    BEGIN
        ALTER TABLE dbo.GioHang
        ADD CONSTRAINT UQ_GioHang_MaNguoiDung UNIQUE (MaNguoiDung);
    END;

    -- [SCRIPT SUA - 06] (Khuyen nghi) Chan du lieu so luong ve am cho du lieu moi
    -- Neu hien tai da co du lieu am thi bo qua buoc nay de khong lam loi script.
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.check_constraints
        WHERE [name] = N'CK_Ve_SoLuong_KhongAm'
          AND parent_object_id = OBJECT_ID(N'dbo.Ve')
    )
    AND NOT EXISTS (SELECT 1 FROM dbo.Ve WHERE SoLuong < 0)
    BEGIN
        ALTER TABLE dbo.Ve
        ADD CONSTRAINT CK_Ve_SoLuong_KhongAm CHECK (SoLuong >= 0);
    END;

    COMMIT TRAN;
    PRINT N'[SCRIPT SUA] Da cap nhat quan he 1-1 NguoiDung-GioHang thanh cong.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRAN;

    THROW;
END CATCH;
GO
