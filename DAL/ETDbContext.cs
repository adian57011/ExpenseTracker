using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ETDbContext:DbContext
    {
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) { }

        //Initialize Table here//
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expenses> Expenses { get; set; }
        public DbSet<Savings> Savings { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
