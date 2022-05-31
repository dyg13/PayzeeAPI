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
    [Route("api/[controller]/{action}")]
    public class UserController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        public UserController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }



        [HttpPost]
        public async Task<IActionResult> Login(UserVM userVM)
        //public async Task<IActionResult> Login([FromBody] UserVM user)       

        {
            try
            {


                //userVM.email = "murat.karayilan@dotto.com.tr";
                //userVM.password = @"kU8@iP3@";
                //userVM.ApiKey = "K46762HNYV1FV19JYMU8CC8OXMG3F212";
                //userVM.MemberID = 1;
                //userVM.MerchantId = 215;
                //userVM.UserType = "API_USER" ;

                //                {
                //                    "email": "murat.karayilan@dotto.com.tr",
                //  "lang": "TR",
                //  "password": "kU8@iP3@",
                //  "userType": "API_USER",
                //  "memberID": 1,
                //  "merchantId": 215,
                //  "apiKey": "K46762HNYV1FV19JYMU8CC8OXMG3F212"
                //}

                var json = JsonConvert.SerializeObject(userVM);
                var url = "https://ppgsecurity-test.birlesikodeme.com:55002/api/ppg/Securities/authenticationMerchant";
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                using (HttpClient client = new())
                {
                    var response = await client.PostAsync(url, data);

                    if (((int)response.StatusCode) == StatusCodes.Status200OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();

                        LoginReturn loginReturn = JsonConvert.DeserializeObject<LoginReturn>(result);



                        if (loginReturn != null && !loginReturn.Fail && !string.IsNullOrEmpty(loginReturn.result.token))
                        {
                            string tokenCheck = string.Empty;
                            _memoryCache.TryGetValue(userVM.memberID, out tokenCheck);

                            var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(30));

                            if (string.IsNullOrEmpty(tokenCheck))
                                _memoryCache.Set<string>(userVM.memberID, loginReturn.result.token, cacheEntryOptions);
                            else
                            {
                                _memoryCache.Remove(userVM.memberID);
                                _memoryCache.Set<string>(userVM.memberID, loginReturn.result.token, cacheEntryOptions);
                            }
                        }
                        else
                        {
                            return BadRequest();
                        }

                        return Ok();
                    }
                    else
                    {
                        return StatusCode((int)response.StatusCode);
                    }
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
