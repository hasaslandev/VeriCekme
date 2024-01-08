using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriCekme
{
    public class DatabaseRel:DbContext
    {
        public DbSet<AirCrash> AirCrashes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Veritabanı bağlantı ayarlarınızı burada belirtin
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-M89OB8P;Database=UcakVeri;Trusted_Connection=true;TrustServerCertificate=true;");
        }

    }
}
