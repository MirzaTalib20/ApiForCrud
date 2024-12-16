using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Data.SqlClient;
using yenideneme.Models;
using DocumentFormat.OpenXml.Spreadsheet;
using Users = yenideneme.Models.Users;

namespace yenideneme
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Users> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>();
        }

    }
}
