using Microsoft.EntityFrameworkCore;
using Lab6_CodeFirst.DAL.Entities;
namespace Lab6_CodeFirst.DAL.DataBase
{
    public class PlayerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server = DESKTOP-QJCC82C\\SQLEXPRESS;Database = EFITIDay1;Trusted_Connection = True; MultipleActiveResultSets = true; TrustServerCertificate = true");
        }
        public DbSet<Player> players { get; set; }
    }
}
