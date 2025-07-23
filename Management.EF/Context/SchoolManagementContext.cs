using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Management.EF.Models;

namespace Management.EF.Context
{
    //The DbContext is the primary class that acts as a bridge between your C# application and the database.
    //It manages database connections, entity tracking, query execution, saving data, and transaction management for EF.
    //Think of DbContext as a session with the database that lets you read and write data through your C# entity class.
    public partial class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext()
        {
        }

        public SchoolManagementContext(DbContextOptions<SchoolManagementContext> options)
            : base(options) //The base is a go-to tool when working with inheritance. Basically, it give subclasses the option to use the base class constructor to pass arguments. 
        {
        }

        //DataSets represent a collection for a given entity type that maps to a table in the database.
        //They are similar to a virtual table that allows you to perform CRUD operations on a specific entity type.
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


        //This method is our backstage pass to customizing how our models map to the database, it plays a central role in configuring
        //the model's shapoe, behavior, and relationships before the database schema is generated. 
        //It defines rules for how entities should be mapped to tables, columns, keys, and constraints. This is especially useful when
        //you want to override the default conventions.
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

                //Navigational Properties below
                entity.HasMany(e => e.Students)
                    .WithOne(st => st.School)
                    .HasForeignKey(e => e.SchoolId) //Students have foreign key of SchoolId
                    .OnDelete(DeleteBehavior.Cascade); //If School is deleted, then the remaining Students would be too. 

                entity.HasMany(e => e.Courses)
                    .WithOne(st => st.School)
                    .HasForeignKey(st => st.SchoolId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SchoolId) //Foreign Key 
                    .IsRequired()
                    .HasColumnName("SchoolID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateofBirth)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Grade)
                    .HasMaxLength(15)
                    .IsFixedLength();

                //Navigational Properties
                entity.HasOne(e => e.School)
                    .WithMany(e => e.Students)
                    .HasForeignKey(e => e.SchoolId);

                entity.HasMany(e => e.Courses).WithMany(s => s.Students);
            });

            modelBuilder.Entity<Courses>(entity => 
            {
                entity.HasKey(e => e.CourseId);

                entity.Property(e => e.CourseId)
                    .HasColumnName("CoursesID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SchoolId)
                    .IsRequired()
                    .HasColumnName("SchoolID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Teacher)
                    .IsRequired()
                    .HasMaxLength(50);

                //Navigational Properties
                entity.HasOne(st => st.School)
                    .WithMany(e => e.Courses)
                    .HasForeignKey(st => st.SchoolId);

                entity.HasMany(e => e.Students).WithMany(s => s.Courses);
            });

            modelBuilder.Entity<Admins>(entity => 
            {
                entity.HasKey(e => e.AdminId);

                entity.Property(e => e.AdminId)
                    .HasColumnName("AdminID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password_Hash)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName).HasMaxLength(50);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
