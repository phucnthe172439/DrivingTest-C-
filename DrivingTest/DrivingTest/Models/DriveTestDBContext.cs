using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrivingTest.Models
{
    public partial class DriveTestDBContext : DbContext
    {
        public DriveTestDBContext()
        {
        }

        public DriveTestDBContext(DbContextOptions<DriveTestDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Result> Results { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =LAPTOP-K796DCHB\\SQLEXPRESS; database = DriveTestDB;uid=sa;pwd=songngu1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("quizzes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.A).HasColumnName("a");

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.AnswerChar).HasColumnName("answerChar");

                entity.Property(e => e.B).HasColumnName("b");

                entity.Property(e => e.C).HasColumnName("c");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.D).HasColumnName("d");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.IsZeroPoint).HasColumnName("isZeroPoint");

                entity.Property(e => e.Title).HasColumnName("title");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__quizzes__categor__4BAC3F29");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("results");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoryid).HasColumnName("categoryid");

                entity.Property(e => e.Result1).HasColumnName("result");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Categoryid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__results__categor__5165187F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK__results__userid__5070F446");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Roleid).HasColumnName("roleid");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
