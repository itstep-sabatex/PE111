using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemo.Data
{
    public class EFCoreDemoDbContext:DbContext
    {
        public static User DefaultAdmin = new User() {Id=1,Name="FGFFG FFFG" };

        public DbSet<Models.Student>  Students { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<User>  Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\serhi\\source\\repos\\itstep-sabatex\\ПВ111\\ADONet\\DataBases\\EFCoreDemo.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().Ignore(b => b.Surname);
            modelBuilder.Entity<Student>().Property(p=>p.Surname).HasColumnName("Прізвище");
            modelBuilder.HasSequence<int>("StudentId").StartsAt(10).IncrementsBy(4);
            modelBuilder.Entity<User>().HasKey(c => c.Id);
            modelBuilder.Entity<User>().HasIndex(c => c.Name).HasDatabaseName("User_Name_IDX").IsUnique();
            modelBuilder.Entity<User>().HasData(new User[]
            {
                DefaultAdmin
            });
            
            
            //IX_<type name>_<property name>.
        }
    }
}
