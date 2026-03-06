using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace APICreateUser.Models;

public partial class ApicreateContext : DbContext
{
    public ApicreateContext()
    {
    }

    public ApicreateContext(DbContextOptions<ApicreateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TblUserIp> TblUserIps { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TblUser__1788CC4C755E9C01");

            entity.ToTable("TblUser");

            entity.HasIndex(e => e.EmailId, "UQ__TblUser__7ED91ACE3D594420").IsUnique();

            entity.HasIndex(e => e.UserName, "UQ__TblUser__C9F28456D40DE3B4").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId).HasMaxLength(150);
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<TblUserIp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUserI__3214EC07E86A03AE");

            entity.ToTable("tblUserIP");

            //entity.Property(e => e.CreatedDate)
            //    .HasDefaultValueSql("(getdate())")
            //    .HasColumnType("datetime");
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");

            //entity.HasOne(d => d.User).WithMany(p => p.TblUserIps)
            //    .HasForeignKey(d => d.UserId)
            //    .HasConstraintName("FK__tblUserIP__UserI__3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
