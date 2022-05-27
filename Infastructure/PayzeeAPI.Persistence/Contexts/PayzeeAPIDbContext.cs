using PayzeeAPI.Domain;
using PayzeeAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence.Contexts
{
    public class PayzeeAPIDbContext : DbContext
    {
        public PayzeeAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Transaction> Products { get; set; }
        public DbSet<CustomerCreditCard> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }



        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
