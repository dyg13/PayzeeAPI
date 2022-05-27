using PayzeeAPI.Application.Repositories;
using PayzeeAPI.Domain.Common;
using PayzeeAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly PayzeeAPIDbContext _context;
        public ReadRepository(PayzeeAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

      
        public IQueryable<T> GetAll(bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool traking = true)
        {
            var query=Table.Where(method);
            if (!traking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = query.AsNoTracking();
           return await query.FirstOrDefaultAsync(method);

        }

        public async Task<T> GetByIdAsync(string id, bool traking = true)
        {
            var query = Table.AsQueryable();
            if (!traking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
           
        }
    }
}
