namespace PayzeeAPI.Persistence.ReturnHelpers
{
    public class LoginReturn
    {
        
        public Result result { get; set; }
        public bool Fail { get; set; }
        public int StatusCode { get; set; }
        public int Count { get; set; }
        public string ResponseCode { get; set; }
        public string ResponseMessage { get; set; }

        public class Result
        {
            public int userId { get; set; }
            public string token { get; set; }
        }

    }

    
}
