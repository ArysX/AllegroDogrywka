using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class ErrorsList
    {
        [JsonProperty("errors")]
        public List<Errors> Errors { get; set; }
    }
}
