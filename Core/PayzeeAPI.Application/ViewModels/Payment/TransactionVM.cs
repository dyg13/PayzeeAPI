using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Application.ViewModels.Payment
{
    public class TransactionVM
    {
        public string TypeId { get; set; }
        public string CardToken { get; set; }
        public bool InserdCart { get; set; }

        public string HashPassword { get; set; }


        public int MemberId { get; set; }
        public string CardNumber { get; set; }
        public string Cvv { get; set; }
        public string ExpiryDateYear { get; set; }
        public string ExpiryDateMonth { get; set; }
        public bool Use3D { get; set; }

        public string UserCode { get; set; }
        public string TxnType { get; set; }
        public string InstallmentCount { get; set; }
        public string Currency { get; set; }
        public string OkUrl { get; set; }
        public string FailUrl { get; set; }
        public string OrderId { get; set; }
        public string TotalAmount { get; set; }
        public string Rnd { get; set; }
        public string Hash { get; set; }

        public string userID { get; set; }


        public long MerchantId { get; set; }
        public string ProductId { get; set; }
        public string Amount { get; set; }

        public string ProductName { get; set; }
        public string CommissionRate { get; set; }




        public string CustomerId { get; set; }
    }
}
