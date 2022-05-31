using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Application.ViewModels
{
    public class UserVM
    {
        public string email { get; set; }
        public string lang { get; set; }
        public string password { get; set; }

        public string userType { get; set; }
        public int memberID { get; set; }
        public long merchantId { get; set; }
        public string apiKey { get; set; }
    }
}
