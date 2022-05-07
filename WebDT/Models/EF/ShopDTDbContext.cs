using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDT.Models.EF
{
    public partial class ShopDTDbContext : DbContext
    {
        public ShopDTDbContext()
            : base("name=ShopDTDbContext")
        {
        }

        public virtual DbSet<AdminAccount> AdminAccounts { get; set; }
        public virtual DbSet<Danh_Gia> Danh_Gia { get; set; }
        public virtual DbSet<Danh_Muc> Danh_Muc { get; set; }
        public virtual DbSet<Dat_Hang> Dat_Hang { get; set; }
        public virtual DbSet<Dat_Hang_San_Pham> Dat_Hang_San_Pham { get; set; }
        public virtual DbSet<Don_Nhap> Don_Nhap { get; set; }
        public virtual DbSet<Don_Nhap_San_Pham> Don_Nhap_San_Pham { get; set; }
        public virtual DbSet<Gio_Hang> Gio_Hang { get; set; }
        public virtual DbSet<Nguoi_Dung> Nguoi_Dung { get; set; }
        public virtual DbSet<Nha_Cung_Cap> Nha_Cung_Cap { get; set; }
        public virtual DbSet<San_Pham> San_Pham { get; set; }
        public virtual DbSet<Thong_Tin_Gio_Hang> Thong_Tin_Gio_Hang { get; set; }
        public virtual DbSet<Thong_Tin_San_Pham> Thong_Tin_San_Pham { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAccount>()
                .HasMany(e => e.Don_Nhap)
                .WithRequired(e => e.AdminAccount)
                .HasForeignKey(e => e.dn_AdminAccount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Danh_Muc>()
                .HasMany(e => e.San_Pham)
                .WithRequired(e => e.Danh_Muc)
                .HasForeignKey(e => e.sp_dmId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dat_Hang>()
                .Property(e => e.dh_TrangThai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Dat_Hang>()
                .HasMany(e => e.Dat_Hang_San_Pham)
                .WithRequired(e => e.Dat_Hang)
                .HasForeignKey(e => e.dhsp_dhId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Don_Nhap>()
                .HasMany(e => e.Don_Nhap_San_Pham)
                .WithRequired(e => e.Don_Nhap)
                .HasForeignKey(e => e.dnsp_dnId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Gio_Hang>()
                .HasMany(e => e.Thong_Tin_Gio_Hang)
                .WithRequired(e => e.Gio_Hang)
                .HasForeignKey(e => e.ttgh_ghId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_Dung>()
                .HasMany(e => e.Danh_Gia)
                .WithRequired(e => e.Nguoi_Dung)
                .HasForeignKey(e => e.dg_ndID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_Dung>()
                .HasMany(e => e.Dat_Hang)
                .WithRequired(e => e.Nguoi_Dung)
                .HasForeignKey(e => e.dh_ndId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nguoi_Dung>()
                .HasMany(e => e.Gio_Hang)
                .WithRequired(e => e.Nguoi_Dung)
                .HasForeignKey(e => e.gh_ndId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nha_Cung_Cap>()
                .Property(e => e.ncc_Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nha_Cung_Cap>()
                .Property(e => e.ncc_Website)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Nha_Cung_Cap>()
                .HasMany(e => e.Don_Nhap)
                .WithRequired(e => e.Nha_Cung_Cap)
                .HasForeignKey(e => e.dn_nccId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<San_Pham>()
                .HasMany(e => e.Danh_Gia)
                .WithRequired(e => e.San_Pham)
                .HasForeignKey(e => e.dg_spID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<San_Pham>()
                .HasMany(e => e.Thong_Tin_San_Pham)
                .WithRequired(e => e.San_Pham)
                .HasForeignKey(e => e.m_SPId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thong_Tin_San_Pham>()
                .Property(e => e.tt_GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Thong_Tin_San_Pham>()
                .Property(e => e.tt_GiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Thong_Tin_San_Pham>()
                .HasMany(e => e.Dat_Hang_San_Pham)
                .WithRequired(e => e.Thong_Tin_San_Pham)
                .HasForeignKey(e => e.dhsp_spId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thong_Tin_San_Pham>()
                .HasMany(e => e.Don_Nhap_San_Pham)
                .WithRequired(e => e.Thong_Tin_San_Pham)
                .HasForeignKey(e => e.dnsp_spId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Thong_Tin_San_Pham>()
                .HasMany(e => e.Thong_Tin_Gio_Hang)
                .WithRequired(e => e.Thong_Tin_San_Pham)
                .HasForeignKey(e => e.ttgh_spId)
                .WillCascadeOnDelete(false);
        }
    }
}
