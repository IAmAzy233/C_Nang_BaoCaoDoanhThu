using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DoAn1_BanFinal.Models
{
    public partial class acomptec_shoDidongCTNDContext : DbContext
    {
        public acomptec_shoDidongCTNDContext()
        {
        }

        public acomptec_shoDidongCTNDContext(DbContextOptions<acomptec_shoDidongCTNDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietdonhang> Chitietdonhang { get; set; }
        public virtual DbSet<Danhmuc> Danhmuc { get; set; }
        public virtual DbSet<Donhang> Donhang { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Quanly> Quanly { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=210.245.90.239;Database=acomptec_shoDidongCTND;User Id=acomptec_group11720;Password=group@11720");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "acomptec_group11720");

            modelBuilder.Entity<Chitietdonhang>(entity =>
            {
                entity.HasKey(e => e.CtDhId)
                    .HasName("PK__CHITIETD__0AEAC87E85ED1189");

                entity.ToTable("CHITIETDONHANG");

                entity.Property(e => e.CtDhId)
                    .HasColumnName("CT_DH_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.CtDhSoluong)
                    .HasColumnName("CT_DH_SOLUONG")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CtDhThanhtien).HasColumnName("CT_DH_THANHTIEN");

                entity.Property(e => e.DhId)
                    .HasColumnName("DH_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SpId)
                    .HasColumnName("SP_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dh)
                    .WithMany(p => p.Chitietdonhang)
                    .HasForeignKey(d => d.DhId)
                    .HasConstraintName("FK_DONHANG");

                entity.HasOne(d => d.Sp)
                    .WithMany(p => p.Chitietdonhang)
                    .HasForeignKey(d => d.SpId)
                    .HasConstraintName("FK_SANPHAM");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.DmId)
                    .HasName("PK__DANHMUC__22B36D3207ED6B56");

                entity.ToTable("DANHMUC");

                entity.Property(e => e.DmId)
                    .HasColumnName("DM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DmTen)
                    .HasColumnName("DM_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Donhang>(entity =>
            {
                entity.HasKey(e => e.DhId)
                    .HasName("PK__DONHANG__1A50AD03D1EAEAEE");

                entity.ToTable("DONHANG");

                entity.Property(e => e.DhId)
                    .HasColumnName("DH_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DhThoigianmua)
                    .HasColumnName("DH_THOIGIANMUA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DhTinhtrangdonhang)
                    .HasColumnName("DH_TINHTRANGDONHANG")
                    .HasMaxLength(30);

                entity.Property(e => e.DhTinhtranggiaohang)
                    .HasColumnName("DH_TINHTRANGGIAOHANG")
                    .HasMaxLength(30);

                entity.Property(e => e.DhTongtien).HasColumnName("DH_TONGTIEN");

                entity.Property(e => e.KhId)
                    .HasColumnName("KH_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Kh)
                    .WithMany(p => p.Donhang)
                    .HasForeignKey(d => d.KhId)
                    .HasConstraintName("FK_KHACHHANG");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.KhId)
                    .HasName("PK__KHACHHAN__2415FB219C1BF6B2");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.KhId)
                    .HasColumnName("KH_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.KhDiachi)
                    .HasColumnName("KH_DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.KhSdt)
                    .HasColumnName("KH_SDT")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.KhTen)
                    .HasColumnName("KH_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Quanly>(entity =>
            {
                entity.HasKey(e => e.QlId)
                    .HasName("PK__QUANLY__8D2CF9EDE380D57E");

                entity.ToTable("QUANLY");

                entity.Property(e => e.QlId)
                    .HasColumnName("QL_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.QlTen)
                    .HasColumnName("QL_TEN")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.SpId)
                    .HasName("PK__SANPHAM__AA24DA23C9EA6D24");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.SpId)
                    .HasColumnName("SP_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DmId)
                    .HasColumnName("DM_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.HaId)
                    .HasColumnName("HA_ID")
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SpChipxuli)
                    .HasColumnName("SP_CHIPXULI")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SpDongia).HasColumnName("SP_DONGIA");

                entity.Property(e => e.SpDophangiai)
                    .HasColumnName("SP_DOPHANGIAI")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpDungluongpin)
                    .HasColumnName("SP_DUNGLUONGPIN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpHangsanxuat)
                    .HasColumnName("SP_HANGSANXUAT")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SpHedieuhanh)
                    .HasColumnName("SP_HEDIEUHANH")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SpHinhanh)
                    .HasColumnName("SP_HINHANH")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.SpKichthuocmanhinh)
                    .HasColumnName("SP_KICHTHUOCMANHINH")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SpRam)
                    .HasColumnName("SP_RAM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpRom)
                    .HasColumnName("SP_ROM")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SpTen)
                    .HasColumnName("SP_TEN")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dm)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.DmId)
                    .HasConstraintName("FK_DANHMUC");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TkTaikhoan)
                    .HasName("PK__TAIKHOAN__EF622467CDE8A1B7");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TkTaikhoan)
                    .HasColumnName("TK_TAIKHOAN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TkMatkhau)
                    .HasColumnName("TK_MATKHAU")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
