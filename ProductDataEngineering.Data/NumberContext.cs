using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductDataEngineering.Domain;

namespace ProductDataEngineering.Data
{
    public class NumberContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=..//ProductDataEngineering.Data//numbers.db");
    }
}
