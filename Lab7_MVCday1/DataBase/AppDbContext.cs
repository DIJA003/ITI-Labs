using Lab7_MVCday1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Lab7_MVCday1.DataBase
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server = DESKTOP-QJCC82C\\SQLEXPRESS;Database = EFITIDay1;Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = true");
        }
        public DbSet<Player>players { get; set; }

        
    }
}
