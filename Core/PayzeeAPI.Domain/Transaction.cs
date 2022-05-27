using PayzeeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Domain
{
    public class Transaction : BaseEntity
    {
        public string TypeId { get; set; }
        public float Amount { get; set; }
        public string CardToken { get; set; }

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
