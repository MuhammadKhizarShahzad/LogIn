using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LogIn.Models
{
    public partial class LogInContext : DbContext
    {
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<User> User { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-B6F2RJT\SQLEXPRESS;Database=LogIn;Trusted_Connection=True; User ID=sa; Password=4291210;");
        //}

            public LogInContext(DbContextOptions<LogInContext> MKS):base(MKS)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("varchar(50)");

                entity.Property(e => e.Email).HasColumnType("varchar(50)");

                entity.Property(e => e.Name).HasColumnType("varchar(50)");

                entity.Property(e => e.RolllNumber)
                    .HasColumnName("Rolll_Number")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DiplayName)
                    .HasColumnName("Diplay_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Pasword).HasColumnType("varchar(50)");

                entity.Property(e => e.Role).HasColumnType("varchar(50)");

                entity.Property(e => e.Username).HasColumnType("varchar(50)");
            });
        }
    }
}