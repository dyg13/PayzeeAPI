using PayzeeAPI.Application.Repositories;
using System.Text.Json;
using PayzeeAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PayzeeAPI.Application.ViewModels.Payment;
using Newtonsoft.Json;
using System.Text;
using PayzeeAPI.Persistence.Helpers.ReturnHelpers;
using System.Net.Http.Headers;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;
using PayzeeAPI.Persistence.Helpers.Extensions;
using PayzeeAPI.Persistence.Helpers;

namespace PayzeeAPI.Api.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly private ITransactionReadRepository _transactionReadRepository;
        readonly private ITransactionWriteRepository _transactionWriteRepository;
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;


        public TransactionController(ITransactionWriteRepository transactionWriteRepository, ITransactionReadRepository transactionReadRepository, IMapper mapper, IMemoryCache memoryCache)
        {
            _transactionWriteRepository = transactionWriteRepository;
            _transactionReadRepository = transactionReadRepository;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }



        [HttpPost]
        public async Task<IActionResult> Pay(Transaction transaction)

        {
            try
            {
                //Transaction transaction = new();


                //transaction.MemberId = 1;
                //transaction.CardNumber = "5101385101385104";
                //transaction.Cvv = "000";
                //transaction.ExpiryDateYear = "22";
                //transaction.ExpiryDateMonth = "12";
                //transaction.MerchantId = 55;
                //transaction.UserCode = "test";
                //transaction.InstallmentCount = "1";
                //transaction.Currency = "949";
                //transaction.OkUrl = "https:/....";
                //transaction.FailUrl = "https:/....";
                //transaction.OrderId = "order4:/..."; //Mükerrer hash olmaması için order değiştiriyorum.
                //transaction.TotalAmount = "100";
                //transaction.Rnd = "123";
                ////transaction.MerchantId = 0001;
                //transaction.MerchantId = 215;

                //transaction.ProductId = "000032";
                //transaction.ProductName = "Bilgisayar";
                //transaction.CommissionRate = "10.00";



                //transaction.Amount = "100";
                //transaction.InserdCart = true;
                //transaction.Use3D = false;
                //transaction.TxnType = "Auth";
                //transaction.HashPassword = "K46762HNYV1FV19JYMU8CC8OXMG3F212";
                //transaction.CustomerId = "1234";

                transaction.Hash = HashCalculator.CreateHash(transaction);



                var json = JsonConvert.SerializeObject(transaction);
                var url = "https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/Payment3d";
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpClient client = new())
                {
                    string userToken = _memoryCache.Get<string>(transaction.MemberId);

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);

                    var response = await client.PostAsync(url, data);

                    if (((int)response.StatusCode) == StatusCodes.Status200OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        string message = result.SpecificHtmlParser(result ?? String.Empty, "ResponseMessage");

                        if (string.Compare(message, "İşlem başarılı.", true) == 0)
                        {
                            return Ok(new { message = message });
                        }
                        else
                        {
                            return BadRequest(new { message = message });
                        }
                    }
                    else
                        return StatusCode((int)response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
