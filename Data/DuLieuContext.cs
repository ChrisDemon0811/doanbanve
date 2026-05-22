using doanbanve.Models;
using doanbanve.Utils;
using Microsoft.EntityFrameworkCore;

namespace doanbanve.Data
{
    public class DuLieuContext : DbContext
    {
        private static IDbContextFactory<DuLieuContext>? boTaoContext;

        public DbSet<NguoiDung> NguoiDung => Set<NguoiDung>();
        public DbSet<LoaiVe> LoaiVe => Set<LoaiVe>();
        public DbSet<Ve> Ve => Set<Ve>();
        public DbSet<VoucherDuLieu> Voucher => Set<VoucherDuLieu>();
        public DbSet<GioHangDuLieu> GioHang => Set<GioHangDuLieu>();
        public DbSet<ChiTietVeDuLieu> ChiTietVe => Set<ChiTietVeDuLieu>();
        public DbSet<ChiTietGioHangDuLieu> ChiTietGioHang => Set<ChiTietGioHangDuLieu>();
        public DbSet<HoaDonDuLieu> HoaDon => Set<HoaDonDuLieu>();
        public DbSet<ChiTietHoaDonDuLieu> ChiTietHoaDon => Set<ChiTietHoaDonDuLieu>();

        public DuLieuContext(DbContextOptions<DuLieuContext> tuyChon) : base(tuyChon)
        {
        }

        public static void CauHinhBoTaoContext(IDbContextFactory<DuLieuContext> boTao)
        {
            boTaoContext = boTao;
        }

        public static DuLieuContext TaoMoi()
        {
            if (boTaoContext != null)
            {
                return boTaoContext.CreateDbContext();
            }

            var tuyChon = new DbContextOptionsBuilder<DuLieuContext>()
                .UseSqlServer(CauHinhHeThong.LayChuoiKetNoi())
                .Options;

            return new DuLieuContext(tuyChon);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung").HasKey(x => x.MaNguoiDung);
            modelBuilder.Entity<NguoiDung>().Property(x => x.NgayDangKy).HasColumnType("datetime");
            modelBuilder.Entity<NguoiDung>().Property(x => x.TaiKhoan).HasMaxLength(100);
            modelBuilder.Entity<NguoiDung>().Property(x => x.MatKhau).HasMaxLength(255);
            modelBuilder.Entity<NguoiDung>().Property(x => x.HoTen).HasMaxLength(100);
            modelBuilder.Entity<NguoiDung>().Property(x => x.Email).HasMaxLength(150);
            modelBuilder.Entity<NguoiDung>().Property(x => x.SoDienThoai).HasMaxLength(20);
            modelBuilder.Entity<NguoiDung>().Property(x => x.VaiTro).HasMaxLength(20);

            modelBuilder.Entity<LoaiVe>().ToTable("LoaiVe").HasKey(x => x.MaLoaiVe);
            modelBuilder.Entity<LoaiVe>().Property(x => x.TenLoaiVe).HasMaxLength(100);
            modelBuilder.Entity<LoaiVe>().Property(x => x.MoTa).HasMaxLength(500);

            modelBuilder.Entity<Ve>().ToTable("Ve").HasKey(x => x.MaVe);
            modelBuilder.Entity<Ve>().Property(x => x.TenVe).HasMaxLength(150);
            modelBuilder.Entity<Ve>().Property(x => x.MoTa).HasMaxLength(500);
            modelBuilder.Entity<Ve>().Property(x => x.AnhVe).HasMaxLength(255);
            modelBuilder.Entity<Ve>().Property(x => x.GiaVe).HasPrecision(18, 2);
            modelBuilder.Entity<Ve>().Property(x => x.GiaNguoiLon).HasPrecision(18, 2);
            modelBuilder.Entity<Ve>().Property(x => x.GiaTreEm).HasPrecision(18, 2);
            modelBuilder.Entity<Ve>().Property(x => x.GiaNguoiCaoTuoi).HasPrecision(18, 2);

            modelBuilder.Entity<VoucherDuLieu>().ToTable("Voucher").HasKey(x => x.MaVoucher);
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.MaGiamGia).HasMaxLength(50);
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.TenVoucher).HasMaxLength(150);
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.KieuGiamGia).HasMaxLength(20);
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.GiaTriGiam).HasPrecision(18, 2);
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.NgayBatDau).HasColumnType("date");
            modelBuilder.Entity<VoucherDuLieu>().Property(x => x.NgayKetThuc).HasColumnType("date");

            modelBuilder.Entity<GioHangDuLieu>().ToTable("GioHang").HasKey(x => x.MaGioHang);
            modelBuilder.Entity<GioHangDuLieu>().Property(x => x.NgayTao).HasColumnType("datetime");

            modelBuilder.Entity<ChiTietVeDuLieu>().ToTable("ChiTietVe").HasKey(x => x.MaChiTietVe);
            modelBuilder.Entity<ChiTietVeDuLieu>().Property(x => x.NgaySuDung).HasColumnType("date");

            modelBuilder.Entity<ChiTietGioHangDuLieu>().ToTable("ChiTietGioHang").HasKey(x => x.MaChiTietGioHang);
            modelBuilder.Entity<ChiTietGioHangDuLieu>().Property(x => x.NgaySuDung).HasColumnType("date");
            modelBuilder.Entity<ChiTietGioHangDuLieu>().Property(x => x.DonGiaNguoiLon).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietGioHangDuLieu>().Property(x => x.DonGiaTreEm).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietGioHangDuLieu>().Property(x => x.DonGiaNguoiCaoTuoi).HasPrecision(18, 2);

            modelBuilder.Entity<HoaDonDuLieu>().ToTable("HoaDon").HasKey(x => x.MaHoaDon);
            modelBuilder.Entity<HoaDonDuLieu>().Property(x => x.NgayLap).HasColumnType("datetime");
            modelBuilder.Entity<HoaDonDuLieu>().Property(x => x.TongTien).HasPrecision(18, 2);
            modelBuilder.Entity<HoaDonDuLieu>().Property(x => x.TienGiam).HasPrecision(18, 2);
            modelBuilder.Entity<HoaDonDuLieu>().Property(x => x.ThanhToan).HasMaxLength(20);
            modelBuilder.Entity<HoaDonDuLieu>().Property(x => x.TrangThai).HasMaxLength(20);

            modelBuilder.Entity<ChiTietHoaDonDuLieu>().ToTable("ChiTietHoaDon").HasKey(x => x.MaChiTietHoaDon);
            modelBuilder.Entity<ChiTietHoaDonDuLieu>().Property(x => x.NgaySuDung).HasColumnType("date");
            modelBuilder.Entity<ChiTietHoaDonDuLieu>().Property(x => x.DonGiaNguoiLon).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietHoaDonDuLieu>().Property(x => x.DonGiaTreEm).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietHoaDonDuLieu>().Property(x => x.DonGiaNguoiCaoTuoi).HasPrecision(18, 2);
            modelBuilder.Entity<ChiTietHoaDonDuLieu>().Property(x => x.ThanhTien).HasPrecision(18, 2);
        }
    }
}
