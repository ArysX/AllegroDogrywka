using Newtonsoft.Json;
using System.Collections.Generic;

namespace AllegroRestApiTest.Models
{
    class CategoryParameterDictionary
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("dependsOnValueIds")]
        public List<string> DependsOnValueIds { get; set; }
    }
}
