using Newtonsoft.Json;
using System.Net;

namespace FilmsManagement.WebApi.Errors
{
    public class ErrorResponseModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status_code")]
        public HttpStatusCode HttpStatusCode { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
