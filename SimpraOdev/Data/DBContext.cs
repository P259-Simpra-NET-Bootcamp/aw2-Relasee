using Microsoft.EntityFrameworkCore;
using SimpraOdev.Models;

namespace SimpraOdev.Data
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-32GL8Q0\\SQLEXPRESS;database=SimpraOdev;integrated security=true;");
        }
        public DbSet<Staff> Staffs { get; set; }
    }
}
