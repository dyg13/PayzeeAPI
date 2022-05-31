using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayzeeAPI.Domain;

namespace PayzeeAPI.Persistence.Helpers
{
    public static class HashCalculator
    {
        public static string CreateHash(Transaction request)
        {

            var apiKey = "K46762HNYV1FV19JYMU8CC8OXMG3F212"; // Bu bilgi size özel olup kayıtlı kullanıcınıza mail olarak gönderilmiştir. 

            var hashString = $"{apiKey}{request.UserCode}{request.Rnd}{request.TxnType}{request.TotalAmount}{request.CustomerId}{request.OrderId}{request.OkUrl}{request.FailUrl}";

            System.Security.Cryptography.SHA512 s512 = System.Security.Cryptography.SHA512.Create();

            System.Text.UnicodeEncoding ByteConverter = new System.Text.UnicodeEncoding();

            byte[] bytes = s512.ComputeHash(ByteConverter.GetBytes(hashString));

            var hash = System.BitConverter.ToString(bytes).Replace("-", "");

            return hash;
        }
    }
}
