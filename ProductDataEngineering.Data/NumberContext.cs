using Microsoft.EntityFrameworkCore;
using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public class NumberContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        public NumberContext(DbContextOptions<NumberContext> options) : base(options)
        {
        }
    }
}
