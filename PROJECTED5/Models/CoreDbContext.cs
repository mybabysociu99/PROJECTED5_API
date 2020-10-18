using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PROJECTED5.Models;

namespace PROJECTED5.Models
{
    public partial class CoreDbContext : DbContext
    {
        public CoreDbContext()
        {
        }

        public CoreDbContext(DbContextOptions<CoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Faculty> Faculty { get; set; }
        public virtual DbSet<Leturers> Leturers { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Scores> Scores { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CQU8RG9;Database=PROJECTED5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_CLASS_FACULTY");
            });

            modelBuilder.Entity<Leturers>(entity =>
            {
                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Leturers)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_LETURERS_FACULTY");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasOne(d => d.Students)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.StudentsId)
                    .HasConstraintName("FK_RECEIPT_STUDENTS");

                entity.HasOne(d => d.Subjects)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.SubjectsId)
                    .HasConstraintName("FK_RECEIPT_SUBJECTS");
            });

            modelBuilder.Entity<Scores>(entity =>
            {
                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_SCORES_FACULTY");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_STUDENTS_CLASS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<PROJECTED5.Models.Account> Account { get; set; }
    }
}
