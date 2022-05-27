using PayzeeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PayzeeAPIDbContext>
    {
        public PayzeeAPIDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<PayzeeAPIDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
