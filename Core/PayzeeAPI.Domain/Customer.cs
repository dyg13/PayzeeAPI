using PayzeeAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Domain
{
    public class Customer: BaseEntity
    {
        public Customer()
        {
            CustomerCreditCards=new HashSet<CustomerCreditCard>();
            Transactions = new HashSet<Transaction>();
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; } = false;
        
        public ICollection<CustomerCreditCard> CustomerCreditCards { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}
