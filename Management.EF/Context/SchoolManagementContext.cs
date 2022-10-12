using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Management.EF.Models;

namespace Management.EF.Context
{
    public partial class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext()
        {
        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<School> Schools { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string,
//you should move it out of source code. You can avoid scaffolding the connection string
//by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148.
//For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=SchoolManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.DistrictId);

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.Administrator).HasMaxLength(50);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(12);

                entity.Property(e => e.SchoolName).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.DateofBirth).HasColumnType("date");

                entity.Property(e => e.DistrictId).HasColumnName("DistrictID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GradeLevel)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.StreetAddress).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
