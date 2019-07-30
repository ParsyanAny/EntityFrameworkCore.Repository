using Mic.EFC.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Mic.EFC.Repository
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Genders> Genders { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Universities> Universities { get; set; }
        public DbSet<TeacherUniversity> TeacherUniversity { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANY;Database=StudentDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Genders>(entity =>
            {
                entity.ToTable("genders");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(6);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.GenderId).HasColumnName("Gender_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.UniversityId).HasColumnName("University_Id");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students__Gender__300424B4");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__students__Univer__2F10007B");
            });

            modelBuilder.Entity<TeacherUniversity>(entity =>
            {
                entity.HasKey(e => new { e.TeacherId, e.UniversityId });

                entity.ToTable("teacher_university");

                entity.Property(e => e.TeacherId).HasColumnName("Teacher_Id");

                entity.Property(e => e.UniversityId).HasColumnName("University_Id");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherUniversity)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__teacher_u__Teach__2B3F6F97");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.TeacherUniversity)
                    .HasForeignKey(d => d.UniversityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__teacher_u__Unive__2C3393D0");
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.ToTable("teachers");

                entity.Property(e => e.GenderId).HasColumnName("Gender_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__teachers__Gender__286302EC");
            });

            modelBuilder.Entity<Universities>(entity =>
            {
                entity.ToTable("universities");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DestroyDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
