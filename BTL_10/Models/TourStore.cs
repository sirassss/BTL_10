using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BTL_10.Models
{
    public partial class TourStore : DbContext
    {
        public TourStore()
            : base("name=TourStore")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<BLOG> BLOGs { get; set; }
        public virtual DbSet<DANHMUCBLOG> DANHMUCBLOGs { get; set; }
        public virtual DbSet<DIEMTHAMQUAN> DIEMTHAMQUANs { get; set; }
        public virtual DbSet<HUONGDANVIEN> HUONGDANVIENs { get; set; }
        public virtual DbSet<KHACH> KHACHes { get; set; }
        public virtual DbSet<KHACHSAN> KHACHSANs { get; set; }
        public virtual DbSet<PHUONGTIEN> PHUONGTIENs { get; set; }
        public virtual DbSet<TOUR> TOURs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TENDN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.LOAITK)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TRANGTHAI)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .HasMany(e => e.BLOGs)
                .WithRequired(e => e.ADMIN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BLOG>()
                .Property(e => e.MABAIVIET)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BLOG>()
                .Property(e => e.MADANHMUCBLOG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BLOG>()
                .Property(e => e.ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUCBLOG>()
                .Property(e => e.MADANHMUCBLOG)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DANHMUCBLOG>()
                .HasMany(e => e.BLOGs)
                .WithRequired(e => e.DANHMUCBLOG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DIEMTHAMQUAN>()
                .Property(e => e.MADD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DIEMTHAMQUAN>()
                .HasMany(e => e.TOURs)
                .WithMany(e => e.DIEMTHAMQUANs)
                .Map(m => m.ToTable("DEN").MapLeftKey("MADD").MapRightKey("MATOUR"));

            modelBuilder.Entity<HUONGDANVIEN>()
                .Property(e => e.MAHDV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HUONGDANVIEN>()
                .Property(e => e.SDT)
                .HasPrecision(13, 0);

            modelBuilder.Entity<HUONGDANVIEN>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.HUONGDANVIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.MAKHACH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.CMND)
                .HasPrecision(15, 0);

            modelBuilder.Entity<KHACH>()
                .Property(e => e.SDT)
                .HasPrecision(15, 0);

            modelBuilder.Entity<KHACH>()
                .HasMany(e => e.TOURs)
                .WithMany(e => e.KHACHes)
                .Map(m => m.ToTable("DANGKY").MapLeftKey("MAKHACH").MapRightKey("MATOUR"));

            modelBuilder.Entity<KHACHSAN>()
                .Property(e => e.MAKS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHSAN>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.KHACHSAN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .Property(e => e.MAPHUONGTIEN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PHUONGTIEN>()
                .HasMany(e => e.TOURs)
                .WithRequired(e => e.PHUONGTIEN)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MATOUR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.TENTOUR)
                .IsFixedLength();

            modelBuilder.Entity<TOUR>()
                .Property(e => e.GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MAHDV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MAKS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TOUR>()
                .Property(e => e.MAPHUONGTIEN)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
