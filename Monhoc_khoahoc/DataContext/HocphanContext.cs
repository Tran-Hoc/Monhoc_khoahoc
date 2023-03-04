using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Monhoc_khoahoc.Data;

namespace Monhoc_khoahoc.DataContext;

public partial class HocphanContext : DbContext
{
    public HocphanContext()
    {
    }

    public HocphanContext(DbContextOptions<HocphanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }

    public virtual DbSet<MonHoc> MonHocs { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7MRL7G7\\SQLEXPRESS;Initial Catalog=Hocphan;Integrated Security=True; TrustServerCertificate=True; User ID=sa;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KhoaHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__KhoaHoc__3213E83FB53161F1");
        });

        modelBuilder.Entity<MonHoc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MonHoc__3213E83FE25D1994");

            entity.HasOne(d => d.IdkhoahocNavigation).WithMany(p => p.MonHocs).HasConstraintName("Fk_Monhoc_khoahoc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
