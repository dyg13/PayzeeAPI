using PayzeeAPI.Application.Repositories;

using PayzeeAPI.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PayzeeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        readonly private ITransactionReadRepository _transactionReadRepository;
        readonly private ITransactionWriteRepository _transactionWriteRepository;
       
        public TransactionController(ITransactionWriteRepository transactionWriteRepository, ITransactionReadRepository transactionReadRepository)
        {
            _transactionWriteRepository = transactionWriteRepository;
            _transactionReadRepository = transactionReadRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {            
            return Ok(_transactionReadRepository.GetAll()); 

        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(string id)
        { 
            Transaction transaction = await _transactionReadRepository.GetByIdAsync(id);
            return Ok(transaction);
        }      
        }
}
