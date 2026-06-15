using doanbanve.Data;
using doanbanve.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace doanbanve.DAO
{
    public class HoaDonDAO
    {
        public async Task<List<DonHangDaThanhToan>> LayDanhSachDaThanhToan(int maNguoiDung)
        {
            using var db = DuLieuContext.TaoMoi();
            return await db.HoaDon
                .AsNoTracking()
                .Where(x => x.MaNguoiDung == maNguoiDung && x.TrangThai == "DaThanhToan")
                .OrderByDescending(x => x.NgayLap)
                .Select(x => new DonHangDaThanhToan
                {
                    MaHoaDon = x.MaHoaDon,
                    NgayLap = x.NgayLap,
                    TongTien = x.TongTien,
                    TienGiam = x.TienGiam,
                    ThanhTien = x.TongTien - x.TienGiam,
                    ThanhToan = x.ThanhToan
                })
                .ToListAsync();
        }

        public async Task<List<ThongKeDoanhThuNgay>> LayThongKeDoanhThuTheoNgay(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = ApDungBoLocNgay(
                db.HoaDon
                    .AsNoTracking()
                    .Where(x => x.TrangThai == "DaThanhToan"),
                tuNgay,
                denNgay);

            return await truyVan
                .GroupBy(x => x.NgayLap.Date)
                .Select(g => new ThongKeDoanhThuNgay
                {
                    Ngay = g.Key,
                    TongThanhTien = g.Sum(x => x.TongTien - x.TienGiam)
                })
                .OrderBy(x => x.Ngay)
                .ToListAsync();
        }

        public async Task<List<ThongKeDoanhThuNgay>> LayThongKeDoanhThuTheoThang(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = ApDungBoLocNgay(
                db.HoaDon
                    .AsNoTracking()
                    .Where(x => x.TrangThai == "DaThanhToan"),
                tuNgay,
                denNgay);

            var duLieuTheoThang = await truyVan
                .GroupBy(x => new { x.NgayLap.Year, x.NgayLap.Month })
                .Select(g => new
                {
                    g.Key.Year,
                    g.Key.Month,
                    TongThanhTien = g.Sum(x => x.TongTien - x.TienGiam)
                })
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ToListAsync();

            return duLieuTheoThang
                .Select(x => new ThongKeDoanhThuNgay
                {
                    Ngay = new DateTime(x.Year, x.Month, 1),
                    TongThanhTien = x.TongThanhTien
                })
                .ToList();
        }

        public async Task<List<ThongTinHoaDon>> LayDanhSachHoaDonQuanLy()
        {
            using var db = DuLieuContext.TaoMoi();
            return await (
                from hoaDon in db.HoaDon.AsNoTracking()
                join nguoiDung in db.NguoiDung.AsNoTracking() on hoaDon.MaNguoiDung equals nguoiDung.MaNguoiDung
                orderby hoaDon.NgayLap descending
                select new ThongTinHoaDon
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    NgayLap = hoaDon.NgayLap,
                    TongTien = hoaDon.TongTien,
                    TienGiam = hoaDon.TienGiam,
                    ThanhTien = hoaDon.TongTien - hoaDon.TienGiam,
                    ThanhToan = hoaDon.ThanhToan,
                    TrangThai = hoaDon.TrangThai,
                    HoTenNguoiDat = nguoiDung.HoTen
                }).ToListAsync();
        }

        public async Task<int> ThemHoaDon(int maNguoiDung, decimal tongTien, int? maVoucher, decimal tienGiam, string thanhToan)
        {
            using var db = DuLieuContext.TaoMoi();
            var hoaDon = new HoaDonDuLieu
            {
                MaNguoiDung = maNguoiDung,
                NgayLap = DateTime.Now,
                TongTien = tongTien,
                MaVoucher = maVoucher,
                TienGiam = tienGiam,
                ThanhToan = thanhToan,
                TrangThai = "DaThanhToan"
            };

            db.HoaDon.Add(hoaDon);
            await db.SaveChangesAsync();
            return hoaDon.MaHoaDon;
        }

        public async Task<int> LuuHoaDonVaKiemTraSoLuongTheoNgay(int maNguoiDung, List<MucGioHang> danhSachMuc, int? maVoucher, decimal tienGiam, string thanhToan)
        {
            if (danhSachMuc == null || danhSachMuc.Count == 0)
            {
                throw new InvalidOperationException("Giỏ hàng đang trống.");
            }

            using var db = DuLieuContext.TaoMoi();
            using var giaoDich = await db.Database.BeginTransactionAsync(IsolationLevel.Serializable);

            try
            {
                await KiemTraSoLuongVeTheoNgay(db, danhSachMuc);
                if (maVoucher.HasValue)
                {
                    var homNay = DateTime.Today;
                    var soDongCapNhatVoucher = await db.Voucher
                        .Where(x => x.MaVoucher == maVoucher.Value &&
                                    x.TrangThai &&
                                    x.SoLuong > 0 &&
                                    x.NgayBatDau <= homNay &&
                                    x.NgayKetThuc >= homNay)
                        .ExecuteUpdateAsync(setters => setters
                            .SetProperty(x => x.SoLuong, x => x.SoLuong - 1));

                    if (soDongCapNhatVoucher == 0)
                    {
                        throw new InvalidOperationException("Voucher không còn lượt sử dụng hoặc đã hết hạn.");
                    }
                }

                var tongTien = danhSachMuc.Sum(m => m.TinhTongTien());
                var hoaDon = new HoaDonDuLieu
                {
                    MaNguoiDung = maNguoiDung,
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    MaVoucher = maVoucher,
                    TienGiam = tienGiam,
                    ThanhToan = thanhToan,
                    TrangThai = "DaThanhToan"
                };

                db.HoaDon.Add(hoaDon);
                await db.SaveChangesAsync();

                var danhSachChiTiet = danhSachMuc.Select(muc => new ChiTietHoaDonDuLieu
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    MaVe = muc.Ve.MaVe,
                    NgaySuDung = muc.NgaySuDung.Date,
                    SoLuongNguoiLon = muc.SoLuongNguoiLon,
                    SoLuongTreEm = muc.SoLuongTreEm,
                    SoLuongNguoiCaoTuoi = muc.SoLuongNguoiCaoTuoi,
                    DonGiaNguoiLon = muc.Ve.GiaNguoiLon,
                    DonGiaTreEm = muc.Ve.GiaTreEm,
                    DonGiaNguoiCaoTuoi = muc.Ve.GiaNguoiCaoTuoi,
                    ThanhTien = muc.TinhTongTien()
                }).ToList();

                db.ChiTietHoaDon.AddRange(danhSachChiTiet);
                await db.SaveChangesAsync();

                await giaoDich.CommitAsync();
                return hoaDon.MaHoaDon;
            }
            catch
            {
                await giaoDich.RollbackAsync();
                throw;
            }
        }

        private static async Task KiemTraSoLuongVeTheoNgay(DuLieuContext db, List<MucGioHang> danhSachMuc)
        {
            var soLuongTheoVeNgay = danhSachMuc
                .GroupBy(x => new { x.Ve.MaVe, NgaySuDung = x.NgaySuDung.Date })
                .Select(g => new
                {
                    g.Key.MaVe,
                    g.Key.NgaySuDung,
                    SoLuongCanBan = g.Sum(m => m.TinhTongSoLuong())
                })
                .Where(x => x.SoLuongCanBan > 0)
                .ToList();

            foreach (var mucCanBan in soLuongTheoVeNgay)
            {
                var ve = await db.Ve
                    .AsNoTracking()
                    .Where(x => x.MaVe == mucCanBan.MaVe && x.TrangThai)
                    .Select(x => new { x.TenVe, SucChuaMoiNgay = x.SoLuong })
                    .FirstOrDefaultAsync();

                if (ve == null)
                {
                    throw new InvalidOperationException("Vé không tồn tại hoặc đã ngừng bán.");
                }

                var soLuongDaBan = await (
                    from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                    join hoaDon in db.HoaDon.AsNoTracking() on chiTiet.MaHoaDon equals hoaDon.MaHoaDon
                    where chiTiet.MaVe == mucCanBan.MaVe &&
                          chiTiet.NgaySuDung == mucCanBan.NgaySuDung &&
                          hoaDon.TrangThai == "DaThanhToan"
                    select (int?)(chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi)
                ).SumAsync() ?? 0;

                var soLuongConLai = Math.Max(0, ve.SucChuaMoiNgay - soLuongDaBan);
                if (mucCanBan.SoLuongCanBan > soLuongConLai)
                {
                    throw new InvalidOperationException(
                        $"Vé '{ve.TenVe}' ngày {mucCanBan.NgaySuDung:dd/MM/yyyy} chỉ còn {soLuongConLai} vé.");
                }
            }
        }

        public async Task ThemChiTietHoaDon(int maHoaDon, MucGioHang muc)
        {
            using var db = DuLieuContext.TaoMoi();
            var chiTiet = new ChiTietHoaDonDuLieu
            {
                MaHoaDon = maHoaDon,
                MaVe = muc.Ve.MaVe,
                NgaySuDung = muc.NgaySuDung.Date,
                SoLuongNguoiLon = muc.SoLuongNguoiLon,
                SoLuongTreEm = muc.SoLuongTreEm,
                SoLuongNguoiCaoTuoi = muc.SoLuongNguoiCaoTuoi,
                DonGiaNguoiLon = muc.Ve.GiaNguoiLon,
                DonGiaTreEm = muc.Ve.GiaTreEm,
                DonGiaNguoiCaoTuoi = muc.Ve.GiaNguoiCaoTuoi,
                ThanhTien = muc.TinhTongTien()
            };

            db.ChiTietHoaDon.Add(chiTiet);
            await db.SaveChangesAsync();
        }

        public async Task<List<MucGioHang>> LayChiTietHoaDon(int maHoaDon)
        {
            using var db = DuLieuContext.TaoMoi();
            return await (
                from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                join ve in db.Ve.AsNoTracking() on chiTiet.MaVe equals ve.MaVe
                where chiTiet.MaHoaDon == maHoaDon
                select new MucGioHang
                {
                    Ve = new Ve
                    {
                        MaVe = chiTiet.MaVe,
                        TenVe = ve.TenVe,
                        GiaNguoiLon = chiTiet.DonGiaNguoiLon,
                        GiaTreEm = chiTiet.DonGiaTreEm,
                        GiaNguoiCaoTuoi = chiTiet.DonGiaNguoiCaoTuoi,
                        ThongTinVe = ve.ThongTinVe,
                        AnhVe = ve.AnhVe
                    },
                    NgaySuDung = chiTiet.NgaySuDung,
                    SoLuongNguoiLon = chiTiet.SoLuongNguoiLon,
                    SoLuongTreEm = chiTiet.SoLuongTreEm,
                    SoLuongNguoiCaoTuoi = chiTiet.SoLuongNguoiCaoTuoi
                }).ToListAsync();
        }

        public async Task<ThongTinHoaDon?> LayThongTinHoaDon(int maHoaDon)
        {
            using var db = DuLieuContext.TaoMoi();
            return await (
                from hoaDon in db.HoaDon.AsNoTracking()
                join nguoiDung in db.NguoiDung.AsNoTracking() on hoaDon.MaNguoiDung equals nguoiDung.MaNguoiDung
                where hoaDon.MaHoaDon == maHoaDon
                select new ThongTinHoaDon
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    NgayLap = hoaDon.NgayLap,
                    TongTien = hoaDon.TongTien,
                    TienGiam = hoaDon.TienGiam,
                    ThanhTien = hoaDon.TongTien - hoaDon.TienGiam,
                    ThanhToan = hoaDon.ThanhToan,
                    TrangThai = hoaDon.TrangThai,
                    HoTenNguoiDat = nguoiDung.HoTen
                }).FirstOrDefaultAsync();
        }

        public async Task<ThongKeDuLieu> LayThongKeDuLieu(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = ApDungBoLocNgay(
                db.HoaDon
                    .AsNoTracking()
                    .Where(x => x.TrangThai == "DaThanhToan"),
                tuNgay,
                denNgay);

            var tongHoaDon = await truyVan.CountAsync();
            var tongTien = await truyVan.SumAsync(x => (decimal?)x.TongTien) ?? 0;
            var tongTienGiam = await truyVan.SumAsync(x => (decimal?)x.TienGiam) ?? 0;
            var tongThanhTien = await truyVan.SumAsync(x => (decimal?)(x.TongTien - x.TienGiam)) ?? 0;

            return new ThongKeDuLieu
            {
                TongHoaDon = tongHoaDon,
                TongTien = tongTien,
                TongTienGiam = tongTienGiam,
                TongThanhTien = tongThanhTien
            };
        }

        public async Task<int> LayTongVeDaBan(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                          join hoaDon in db.HoaDon.AsNoTracking() on chiTiet.MaHoaDon equals hoaDon.MaHoaDon
                          where hoaDon.TrangThai == "DaThanhToan"
                          select new
                          {
                              hoaDon.NgayLap,
                              TongSoLuong = chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi
                          };

            if (tuNgay.HasValue)
            {
                truyVan = truyVan.Where(x => x.NgayLap >= tuNgay.Value);
            }

            if (denNgay.HasValue)
            {
                var mocDenNgay = denNgay.Value.Date.AddDays(1);
                truyVan = truyVan.Where(x => x.NgayLap < mocDenNgay);
            }

            return await truyVan.SumAsync(x => (int?)x.TongSoLuong) ?? 0;
        }

        public async Task<List<ThongKeTheoLoaiVe>> LayThongKeTheoLoaiVe(DateTime? tuNgay, DateTime? denNgay)
        {
            using var db = DuLieuContext.TaoMoi();
            var truyVan = from chiTiet in db.ChiTietHoaDon.AsNoTracking()
                          join ve in db.Ve.AsNoTracking() on chiTiet.MaVe equals ve.MaVe
                          join loaiVe in db.LoaiVe.AsNoTracking() on ve.MaLoaiVe equals loaiVe.MaLoaiVe
                          join hoaDon in db.HoaDon.AsNoTracking() on chiTiet.MaHoaDon equals hoaDon.MaHoaDon
                          where hoaDon.TrangThai == "DaThanhToan"
                          select new
                          {
                              loaiVe.MaLoaiVe,
                              loaiVe.TenLoaiVe,
                              hoaDon.NgayLap,
                              SoVeDaBan = chiTiet.SoLuongNguoiLon + chiTiet.SoLuongTreEm + chiTiet.SoLuongNguoiCaoTuoi,
                              chiTiet.ThanhTien
                          };

            if (tuNgay.HasValue)
            {
                truyVan = truyVan.Where(x => x.NgayLap >= tuNgay.Value);
            }

            if (denNgay.HasValue)
            {
                var mocDenNgay = denNgay.Value.Date.AddDays(1);
                truyVan = truyVan.Where(x => x.NgayLap < mocDenNgay);
            }

            return await truyVan
                .GroupBy(x => new { x.MaLoaiVe, x.TenLoaiVe })
                .Select(g => new ThongKeTheoLoaiVe
                {
                    MaLoaiVe = g.Key.MaLoaiVe,
                    TenLoaiVe = g.Key.TenLoaiVe,
                    SoVeDaBan = g.Sum(x => x.SoVeDaBan),
                    TongThanhTien = g.Sum(x => x.ThanhTien)
                })
                .OrderByDescending(x => x.TongThanhTien)
                .ToListAsync();
        }

        private static IQueryable<HoaDonDuLieu> ApDungBoLocNgay(IQueryable<HoaDonDuLieu> truyVan, DateTime? tuNgay, DateTime? denNgay)
        {
            if (tuNgay.HasValue)
            {
                truyVan = truyVan.Where(x => x.NgayLap >= tuNgay.Value);
            }

            if (denNgay.HasValue)
            {
                var mocDenNgay = denNgay.Value.Date.AddDays(1);
                truyVan = truyVan.Where(x => x.NgayLap < mocDenNgay);
            }

            return truyVan;
        }
    }
}
