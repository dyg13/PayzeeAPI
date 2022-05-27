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
    public class CustomerCreditCardWriteRepository : WriteRepository<CustomerCreditCard>, ICustomerCreditCardWriteRepository
    {
        public CustomerCreditCardWriteRepository(PayzeeAPIDbContext context) : base(context)
        {
        }
    }
}
