using PayzeeAPI.Application.Repositories;
using PayzeeAPI.Application.ViewModels.Customers;
using PayzeeAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using AutoMapper;
using PayzeeAPI.Persistence.Helpers.Enums;

namespace PayzeeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMapper mapper)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreateVM customerVM)
        {
            TcKimlikService.KPSPublicSoapClient client=null;

            try
            {
                var customer = _mapper.Map<CustomerCreateVM, Customer>(customerVM);

                customer.StatusId = Enum.GetName<StatusEnum>(StatusEnum.Pasif);

                bool result = await _customerWriteRepository.AddAsync(customer);

                if (result)
                {
                    using ( client = new(TcKimlikService.KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap))
                    {

                        var response = await client.TCKimlikNoDogrulaAsync(customerVM.IdentityNo, customerVM.Name, customerVM.Surname, customerVM.BirthDate.Year);

                        if (response.Body.TCKimlikNoDogrulaResult)
                            customer.StatusId = Enum.GetName<StatusEnum>(StatusEnum.Aktif);
                        _customerWriteRepository.Update(customer);
                    }
                }
                else
                {
                    return StatusCode(500);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                //Do something with exception, şimdilik geçildi, hata veritabanına yazdırılabilir.
                return BadRequest();
            }
            finally
            {
             if(client.State==System.ServiceModel.CommunicationState.Opened)
                    client.Close(); 
            }
        }

    }
}
