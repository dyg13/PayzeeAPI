using PayzeeAPI.Persistence.ReturnHelpers;
using PayzeeAPI.Application.ViewModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Text;


namespace PayzeeAPI.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        public UserController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserVM user)
        {
            try
            {

            
            var json = JsonConvert.SerializeObject(user);
            var url = "https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant";
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpClient client = new())
            {            

            var response = await client.PostAsync(url, data);
            
            if (((int)response.StatusCode) != StatusCodes.Status200OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                LoginReturn loginReturn = JsonConvert.DeserializeObject<LoginReturn>(result);

                if (!string.IsNullOrEmpty(loginReturn.token))
                {
                    string tokenCheck = string.Empty;
                    _memoryCache.TryGetValue(loginReturn.userId, out tokenCheck);
                    
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));

                    if (string.IsNullOrEmpty(tokenCheck))
                        _memoryCache.Set<string>(loginReturn.userId, loginReturn.token, cacheEntryOptions);
                    else
                    {
                        _memoryCache.Remove(loginReturn.userId);
                        _memoryCache.Set<string>(loginReturn.userId, loginReturn.token, cacheEntryOptions);
                    }
                }
                else
                {
                    return BadRequest();
                }

                                return Ok();
            }
            else if (((int)response.StatusCode) != StatusCodes.Status401Unauthorized)
            {
                return Unauthorized();
            }
            }
            return BadRequest();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { }
        }

        

    }
}
