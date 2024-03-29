using Microsoft.EntityFrameworkCore;
using SOLID.PRINCIPLE.SingleResponsibility.Student;
using SOLID.PRINCIPLE.SingleResponsibility.Teacher;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.PRINCIPLE.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> context) :base(context)
        { }
        public DbSet<StudentEntity> Student { get; set; }
        public DbSet<TeacherEntity> Teacher { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer("Server=DESKTOP-HEQ5CMC\\SQLEXPRESS2014;Database=STDMS;User Id=sa; Password=P@ssw0rd;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //configuring the student entity whith tabale and primary key
            modelBuilder.Entity<StudentEntity>().ToTable("TBL_Student").HasKey(s=>s.id);
            //configuring the teacher entity whith tabale and primary key
            modelBuilder.Entity<TeacherEntity>().ToTable("TBL_Teacher").HasKey(t => t.id);
        }
    }
}
