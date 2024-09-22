using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ETDbContext:DbContext
    {
        public ETDbContext(DbContextOptions<ETDbContext> options) : base(options) { }
    }


    //Initialize All the Tables Here
}
