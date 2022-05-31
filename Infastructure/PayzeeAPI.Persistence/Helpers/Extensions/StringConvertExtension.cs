using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayzeeAPI.Persistence.Helpers.Extensions
{
    public static class StringConvertExtension
    {

        public static string SpecificHtmlParser(this String str, string htmlData,string messageFieldName= "ResponseMessage", string basariCode="00")
        {

            var htmlDataArray = htmlData.Split("\r\n");

            var responseMessageData = string.Empty;
            var responseCodeData = string.Empty;

            foreach (var item in htmlDataArray)
            {
                if (item.Contains("ResponseCode"))
                {
                    responseCodeData = item;
                    continue;
                }
                if (item.Contains("ResponseMessage"))
                    responseMessageData = item;
            }

            var responseMessageDataArray = responseMessageData.Split("\"");
            var responseCodeDataArray = responseCodeData.Split("\"");

            //index 5 (code var.)
            //KODDAN KONTROL ETMEK İSTERSEK BUNU KULLANABİLİRİZ:
            //if (!(responseCodeData.Length >= 5 && string.Compare(responseCodeDataArray[5], "00", false) == 0))
            //{

            //}

            //index 3 ve 5
            if (responseMessageDataArray.Length >= 6 && string.Compare(messageFieldName, responseMessageDataArray[3], true) == 0)
            {
                return responseMessageDataArray[5];
            }
            else
            {
                return "Pattern Hatalı..";
            }
        }

    }
}
