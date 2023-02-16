using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDemoBaseExist.Data
{
    public class EFCoreDemoDbContext:DbContext
    {
        public DbSet<EFCoreDemo.Models.Student>  Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\serhi\\source\\repos\\itstep-sabatex\\ПВ111\\ADONet\\DataBases\\EFCoreDemo.db");
            //optionsBuilder.LogTo(Console.Write);
        }
    }
}
