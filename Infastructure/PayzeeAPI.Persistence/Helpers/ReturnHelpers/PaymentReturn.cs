using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence.Helpers.ReturnHelpers
{
    public class PaymentReturn
    {
        public string OrderId { get; set; }
        public string Rnd { get; set; }

        public string HostReference { get; set; }

        public string AuthCode { get; set; }

        public string TotalAmount { get; set; }

        public string ResponseHash { get; set; }

        public string ResponseCode { get; set; }

        public string ResponseMessage { get; set; }

        public string CustomerId { get; set; }

        public string ExtraData { get; set; }

        public string InstallmentCount { get; set; }

        public string CardNumber { get; set; }

        public string SaleDate { get; set; }
        public string VPosName { get; set; }
        public string PaymentSystem { get; set; }

    }
}
