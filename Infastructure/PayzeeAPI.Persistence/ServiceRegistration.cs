
using PayzeeAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PayzeeAPI.Application.Repositories;
using PayzeeAPI.Persistence.Repositories;

namespace PayzeeAPI.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistanceServices(this IServiceCollection services)
        {

            services.AddDbContext<PayzeeAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<ICustomerCreditCardReadRepository, CustomerCreditCardReadRepository>();
            services.AddScoped<ICustomerCreditCardWriteRepository, CustomerCreditCardWriteRepository>();
            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
            services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();


        }
    }

}
