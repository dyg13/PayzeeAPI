using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Application.ViewModels.CustomerCreditCards
{
    public class CustomerCreditCardVM
    {
        public string CardToken { get; set; }
        public string CardNetwork { get; set; }
        public string CardBrand { get; set; }
        public string CardPan { get; set; }

        public string CustomerId { get; set; }
    }
}
