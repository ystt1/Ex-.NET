using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeJobTitleLib.DataAccess;

public partial class EmployeeJobTitleContext : DbContext
{
    public EmployeeJobTitleContext()
    {
    }

    public EmployeeJobTitleContext(DbContextOptions<EmployeeJobTitleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dbaccount> Dbaccounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OQQ0EIH;Database=EmployeeJobTitle;Trusted_connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dbaccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__DBAccoun__349DA5864A658C61");

            entity.ToTable("DBAccount");

            entity.Property(e => e.AccountId)
                .HasMaxLength(20)
                .HasColumnName("AccountID");
            entity.Property(e => e.AccountPassword).HasMaxLength(80);
            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF1340A89A9");

            entity.ToTable("Employee");

            entity.Property(e => e.EmployeeId)
                .HasMaxLength(20)
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentName).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(120);
            entity.Property(e => e.JobTitleId)
                .HasMaxLength(20)
                .HasColumnName("JobTitleID");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Employee__JobTit__286302EC");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__JobTitle__35382FC9090F3363");

            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleId)
                .HasMaxLength(20)
                .HasColumnName("JobTitleID");
            entity.Property(e => e.JobTitleDescription).HasMaxLength(250);
            entity.Property(e => e.JobTitleName).HasMaxLength(80);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
