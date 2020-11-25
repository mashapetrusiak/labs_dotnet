using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _2lab.Models
{
    public partial class ProjectcontractsContext : DbContext
    {
        public ProjectcontractsContext()
        {
        }

        public ProjectcontractsContext(DbContextOptions<ProjectcontractsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Characterization> Characterization { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Fullname> Fullname { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<ProjectInfo> ProjectInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Project contracts;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(10);

                entity.Property(e => e.Home).HasColumnName("home");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Characterization>(entity =>
            {
                entity.Property(e => e.CharacterizationId).HasColumnName("characterization_id");

                entity.Property(e => e.CharacterizationText)
                    .HasColumnName("characterizationText")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.CharacterizationId).HasColumnName("characterization_id");

                entity.Property(e => e.Days).HasColumnName("days");

                entity.Property(e => e.FullnameId).HasColumnName("fullname_id");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Salary).HasColumnName("salary");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Address");

                entity.HasOne(d => d.Characterization)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.CharacterizationId)
                    .HasConstraintName("FK_Employee_Characterization");

                entity.HasOne(d => d.Fullname)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.FullnameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Fullname");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Position");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_ProjectInfo");
            });

            modelBuilder.Entity<Fullname>(entity =>
            {
                entity.Property(e => e.FullnameId).HasColumnName("fullname_id");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasColumnName("firstname")
                    .HasMaxLength(10);

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasColumnName("lastname")
                    .HasMaxLength(10);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasColumnName("position_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectInfo>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.ProjectDescription)
                    .IsRequired()
                    .HasColumnName("projectDescription")
                    .IsUnicode(false);

                entity.Property(e => e.ProjectEnd)
                    .HasColumnName("projectEnd")
                    .HasColumnType("date");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("projectName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStart)
                    .HasColumnName("projectStart")
                    .HasColumnType("date");
            });
        }
    }
}
