using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayzeeAPI.Application.Repositories;
using PayzeeAPI.Application.ViewModels.Customers;
using PayzeeAPI.Domain;
using PayzeeAPI.Persistence.Helpers.ReturnHelpers;
using PayzeeAPI.Persistence.ReturnHelpers;
using System.Text;

namespace PayzeeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreditCardController : ControllerBase
    {
        private readonly ICustomerCreditCardWriteRepository _customerCreditCardWriteRepository;
        private readonly ICustomerCreditCardReadRepository _customerCreditCardReadRepository;

        private readonly IMapper _mapper;

        public CustomerCreditCardController(ICustomerCreditCardWriteRepository customerCreditCardWriteRepository, ICustomerCreditCardReadRepository customerCreditCardReadRepository, IMapper mapper)
        {
            _customerCreditCardWriteRepository = customerCreditCardWriteRepository;
            _customerCreditCardReadRepository = customerCreditCardReadRepository;
            _mapper = mapper;
        }

        [HttpPut("/DeleteCreditCard")]
        public async Task<IActionResult> DeleteCreditCard(CustomerCreditCardCreateVM createCreditCardVM)
        {
            try
            {

            
            var createCreditCard = _mapper.Map<CustomerCreditCardCreateVM, CustomerCreditCard>(createCreditCardVM);

            var json = JsonConvert.SerializeObject(createCreditCard);
            var url = "https://ppgpayment-test.birlesikodeme.com:20000/api/ppg/Payment/DeleteCustomerCard";
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new())
            {
                var response = await client.PutAsync(url, data);

                if (((int)response.StatusCode) != StatusCodes.Status200OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    DeleteCreditCardReturn deleteCreditCardReturn = JsonConvert.DeserializeObject<DeleteCreditCardReturn>(result);

                    if (deleteCreditCardReturn.isSucceed)

                        return Ok(new { message = deleteCreditCardReturn.message });
                    else
                        return BadRequest(new { message = deleteCreditCardReturn.message });
                }
                else
                    return BadRequest();
            }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }
        }
    }
}
