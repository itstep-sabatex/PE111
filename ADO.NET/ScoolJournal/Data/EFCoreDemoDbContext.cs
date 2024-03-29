﻿using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoolJournal.Data
{
    public class EFCoreDemoDbContext:DbContext
    {
        public DbSet<Student>  Students { get; set; }
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
        }
    }
}
