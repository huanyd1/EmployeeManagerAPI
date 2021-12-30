using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EmployeeManagerAPI.Models.EF
{
    public partial class EMPLOYEE_MANAGERContext : DbContext
    {
        public EMPLOYEE_MANAGERContext()
        {
        }

        public EMPLOYEE_MANAGERContext(DbContextOptions<EMPLOYEE_MANAGERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source= LAPTOP-P6K68FUP\\SQLEXPRESS;Initial Catalog=EMPLOYEE_MANAGER;User ID=sa;Password= 123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.IDDepartment);

                entity.ToTable("Department");

                entity.Property(e => e.IDDepartment).HasComment("Mã Phòng Ban");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Tên Phòng Ban')")
                    .HasComment("Tên Phòng Ban");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IDEmployee);

                entity.ToTable("Employee");

                entity.Property(e => e.IDEmployee).HasComment("Mã Nhân Viên");

                entity.Property(e => e.DataOfJoining)
                    .HasColumnType("date")
                    .HasComment("Ngày Tham Gia");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(N'Tên Nhân Viên')")
                    .HasComment("Tên Nhân Viên");

                entity.Property(e => e.IDDepartment).HasComment("Mã Phòng Ban");

                entity.HasOne(d => d.IDDepartmentNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IDDepartment)
                    .HasConstraintName("FK_Employee_Department");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
