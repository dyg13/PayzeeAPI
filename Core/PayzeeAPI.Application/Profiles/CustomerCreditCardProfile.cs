using AutoMapper;
using PayzeeAPI.Application.ViewModels.CustomerCreditCards;
using PayzeeAPI.Application.ViewModels.Customers;
using PayzeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Application.Profiles
{
    public class CustomerCreditCardProfile:Profile
    {
        public CustomerCreditCardProfile()
        {
            CreateMap<CustomerCreditCardVM, CustomerCreditCard>().ReverseMap();

        }
    }
}
