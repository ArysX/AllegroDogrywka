using Newtonsoft.Json;

namespace AllegroRestApiTest.Models
{
    class Errors
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("userMessage")]
        public string UserMessage { get; set; }
    }
}
