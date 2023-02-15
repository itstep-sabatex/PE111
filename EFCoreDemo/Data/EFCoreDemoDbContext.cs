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
        public DbSet<Models.Student>  Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\serhi\\source\\repos\\itstep-sabatex\\ПВ111\\ADONet\\DataBases\\EFCoreDemo.db");
        }
    }
}
