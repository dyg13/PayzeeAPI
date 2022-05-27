using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Application.ViewModels.Customers
{
    public class CustomerCreateVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public long IdentityNo { get; set; }
        public bool IdentityNoVerified { get; set; }


    }
}
