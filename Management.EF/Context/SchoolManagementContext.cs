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
        public virtual DbSet<Admins> Admins { get; set; } = null!;
        public virtual DbSet<Courses> Courses { get; set; } = null!;

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
                entity.HasKey(e => e.SchoolId);

                entity.Property(e => e.SchoolId)
                    .HasColumnName("SchoolID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Administrator)
                    .IsRequired()    
                    .HasMaxLength(50);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasMany(e => e.Students)
                    .WithOne(st => st.School) //Navigational Property
                    .HasForeignKey(e => e.SchoolId) //Students have foreign key of SchoolId
                    .OnDelete(DeleteBehavior.Cascade); //If School is deleted, then the remaining Students would be too. 

                entity.HasMany(e => e.Courses)
                    .WithOne(e => e.School)
                    .HasForeignKey(e => e.SchoolId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.SchoolId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DateofBirth)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.SchoolId)
                    .IsRequired()
                    .HasColumnName("SchoolID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property (e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
