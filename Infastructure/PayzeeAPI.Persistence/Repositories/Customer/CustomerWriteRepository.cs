using PayzeeAPI.Application.Repositories;
using PayzeeAPI.Domain;
using PayzeeAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence.Repositories
{
    public class CustomerWriteRepository : WriteRepository<Customer>, ICustomerWriteRepository
    {
        public CustomerWriteRepository(PayzeeAPIDbContext context) : base(context)
        {

        }
    }
}
