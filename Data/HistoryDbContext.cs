using Microsoft.EntityFrameworkCore;
using HistoryAPI.Models;

namespace HistoryAPI.Data
{
    public class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options)
        {
        }

        public DbSet<ThoiKyQuocHieu> ThoiKyQuocHieus { get; set; }
        public DbSet<SuKien> SuKiens { get; set; }
        public DbSet<NhanVat> NhanVats { get; set; }
        public DbSet<CauChuyen> CauChuyens { get; set; }
        public DbSet<LanhTho> LanhThos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình các quan hệ (nếu cần thiết, ví dụ quan hệ nhiều-nhiều)
            // Ví dụ: Cấu hình quan hệ nhiều-nhiều giữa NhanVat và ThoiKyQuocHieu (nếu bạn tạo bảng NhanVat_ThoiKyQuocHieu)
            /*
            modelBuilder.Entity<NhanVat_ThoiKyQuocHieu>()
                .HasKey(nvth => new { nvth.MaNhanVat, nvth.MaTrieuDai });

            modelBuilder.Entity<NhanVat_ThoiKyQuocHieu>()
                .HasOne(nvth => nvth.NhanVat)
                .WithMany(nv => nv.NhanVat_ThoiKyQuocHieus)
                .HasForeignKey(nvth => nvth.MaNhanVat);

            modelBuilder.Entity<NhanVat_ThoiKyQuocHieu>()
                .HasOne(nvth => nvth.ThoiKyQuocHieu)
                .WithMany(th => th.NhanVat_ThoiKyQuocHieus)
                .HasForeignKey(nvth => nvth.MaTrieuDai);
            */

            // Ví dụ: Cấu hình quan hệ nhiều-nhiều giữa SuKien và DiaDanh (nếu bạn tạo bảng SuKien_DiaDanh)
            /*
            modelBuilder.Entity<SuKien_DiaDanh>()
                .HasKey(skdd => new { skdd.MaSuKien, skdd.MaDiaDanh });

            modelBuilder.Entity<SuKien_DiaDanh>()
                .HasOne(skdd => skdd.SuKien)
                .WithMany(sk => sk.SuKien_DiaDanhs)
                .HasForeignKey(skdd => skdd.MaSuKien);

            modelBuilder.Entity<SuKien_DiaDanh>()
                .HasOne(skdd => skdd.DiaDanh)
                .WithMany(dd => dd.SuKien_DiaDanhs)
                .HasForeignKey(skdd => skdd.MaDiaDanh);
            */

            // Ví dụ: Cấu hình quan hệ nhiều-nhiều giữa CauChuyen và NhanVat (nếu bạn tạo bảng CauChuyen_NhanVat)
            /*
            modelBuilder.Entity<CauChuyen_NhanVat>()
                .HasKey(cvnv => new { cvnv.MaCauChuyen, cvnv.MaNhanVat });

            modelBuilder.Entity<CauChuyen_NhanVat>()
                .HasOne(cvnv => cvnv.CauChuyen)
                .WithMany(cv => cv.CauChuyen_NhanVats)
                .HasForeignKey(cvnv => cvnv.MaCauChuyen);

            modelBuilder.Entity<CauChuyen_NhanVat>()
                .HasOne(cvnv => cvnv.NhanVat)
                .WithMany(nv => nv.CauChuyen_NhanVats)
                .HasForeignKey(cvnv => cvnv.MaNhanVat);
            */
        }
    }
}