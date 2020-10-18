using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PROJECTED5.Models
{
    public partial class PROJECTED5Context : DbContext
    {
        public PROJECTED5Context()
        {
        }

        public PROJECTED5Context(DbContextOptions<PROJECTED5Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-CQU8RG9;Database=PROJECTED5;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("ACCOUNT");

                entity.Property(e => e.AccountId)
                    .HasColumnName("accountID")
                    .HasMaxLength(6);

                entity.Property(e => e.PassWord)
                    .HasColumnName("passWord")
                    .HasMaxLength(30);

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasColumnName("userName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.ToTable("CLASS");

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasMaxLength(6);

                entity.Property(e => e.ClassName)
                    .HasColumnName("className")
                    .HasMaxLength(30);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.FinishDay)
                    .HasColumnName("finishDay")
                    .HasColumnType("datetime");

                entity.Property(e => e.LeturersId)
                    .HasColumnName("leturersID")
                    .HasMaxLength(6);

                entity.Property(e => e.StartDay)
                    .HasColumnName("startDay")
                    .HasColumnType("datetime");

                entity.Property(e => e.StudentsId)
                    .HasColumnName("studentsID")
                    .HasMaxLength(6);

                entity.Property(e => e.SubjectsId)
                    .HasColumnName("subjectsID")
                    .HasMaxLength(6);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_CLASS_FACULTY");
            });

            modelBuilder.Entity<Faculty>(entity =>
            {
                entity.ToTable("FACULTY");

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.FacultyName)
                    .HasColumnName("facultyName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Leturers>(entity =>
            {
                entity.ToTable("LETURERS");

                entity.Property(e => e.LeturersId)
                    .HasColumnName("leturersID")
                    .HasMaxLength(6);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.LeturersAddress)
                    .HasColumnName("leturersAddress")
                    .HasMaxLength(100);

                entity.Property(e => e.LeturersDegree)
                    .HasColumnName("leturersDegree")
                    .HasMaxLength(30);

                entity.Property(e => e.LeturersName)
                    .HasColumnName("leturersName")
                    .HasMaxLength(30);

                entity.Property(e => e.LeturersPhone)
                    .HasColumnName("leturersPhone")
                    .HasMaxLength(10);

                entity.Property(e => e.LeturersSpecialized)
                    .HasColumnName("leturersSpecialized")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Leturers)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_LETURERS_FACULTY");
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.ToTable("RECEIPT");

                entity.Property(e => e.ReceiptId)
                    .HasColumnName("receiptID")
                    .HasMaxLength(6);

                entity.Property(e => e.CreatorName)
                    .HasColumnName("creatorName")
                    .HasMaxLength(30);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.MoneyReceiver)
                    .HasColumnName("moneyReceiver")
                    .HasMaxLength(50);

                entity.Property(e => e.Payer)
                    .HasColumnName("payer")
                    .HasMaxLength(30);

                entity.Property(e => e.PaymentAmount).HasColumnName("paymentAmount");

                entity.Property(e => e.PaymentReason)
                    .HasColumnName("paymentReason")
                    .HasMaxLength(100);

                entity.Property(e => e.ReceiptName)
                    .HasColumnName("receiptName")
                    .HasMaxLength(30);

                entity.Property(e => e.StudentsId)
                    .HasColumnName("studentsID")
                    .HasMaxLength(6);

                entity.Property(e => e.SubjectsId)
                    .HasColumnName("subjectsID")
                    .HasMaxLength(6);

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
                entity.ToTable("SCORES");

                entity.Property(e => e.ScoresId)
                    .HasColumnName("scoresID")
                    .HasMaxLength(6);

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasMaxLength(6);

                entity.Property(e => e.ClassName)
                    .HasColumnName("className")
                    .HasMaxLength(30);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.FristPoint).HasColumnName("fristPoint");

                entity.Property(e => e.LeturersId)
                    .HasColumnName("leturersID")
                    .HasMaxLength(6);

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasMaxLength(100);

                entity.Property(e => e.SecondPoint).HasColumnName("secondPoint");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StudentsId)
                    .HasColumnName("studentsID")
                    .HasMaxLength(6);

                entity.HasOne(d => d.Faculty)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.FacultyId)
                    .HasConstraintName("FK_SCORES_FACULTY");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("STUDENTS");

                entity.Property(e => e.StudentsId)
                    .HasColumnName("studentsID")
                    .HasMaxLength(6);

                entity.Property(e => e.ClassId)
                    .HasColumnName("classID")
                    .HasMaxLength(6);

                entity.Property(e => e.ClassName)
                    .HasColumnName("className")
                    .HasMaxLength(30);

                entity.Property(e => e.FacultyId)
                    .HasColumnName("facultyID")
                    .HasMaxLength(6);

                entity.Property(e => e.FristPoint).HasColumnName("fristPoint");

                entity.Property(e => e.StatusPay).HasColumnName("statusPay");

                entity.Property(e => e.StudentsAddress)
                    .HasColumnName("studentsAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.StudentsName)
                    .HasColumnName("studentsName")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_STUDENTS_CLASS");
            });

            modelBuilder.Entity<Subjects>(entity =>
            {
                entity.ToTable("SUBJECTS");

                entity.Property(e => e.SubjectsId)
                    .HasColumnName("subjectsID")
                    .HasMaxLength(6);

                entity.Property(e => e.SubjectsCredit)
                    .HasColumnName("subjectsCredit")
                    .HasMaxLength(2);

                entity.Property(e => e.SubjectsName)
                    .HasColumnName("subjectsName")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
