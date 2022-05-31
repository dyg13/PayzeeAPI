using AutoMapper;
using PayzeeAPI.Application.ViewModels.Payment;
using PayzeeAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PayzeeAPI.Application.Profiles
{
    public class TransactionProfile:Profile
    {
        public TransactionProfile()
        {
        CreateMap<TransactionVM, Transaction>().ReverseMap();
        }

    }
}
